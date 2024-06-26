using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_FrameWork.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.Account.Agg;
using AccountManagement.Infrastructure.ShopAcl.Lang;
using CommentManagement.Domain.Notification.Agg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly INotificationRepository _notification;
        private readonly IRazorPartialToStringRenderer _renderer;
        private readonly IAccountRepository _repository;
        private readonly ITeacherRepository _teacher;
        private readonly IAuthHelper _authHelper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ILogger<AccountApplication> _logger;
        public AccountApplication(IAccountRepository repository, IFileUploader fileUploader,
            ITeacherRepository teacher, INotificationRepository notification, IRazorPartialToStringRenderer renderer, ILogger<AccountApplication> logger, IAuthHelper authHelper, IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _fileUploader = fileUploader;
            _teacher = teacher;
            _notification = notification;
            _renderer = renderer;
            _logger = logger;
            _authHelper = authHelper;
            _passwordHasher = passwordHasher;
        }

        public async Task<OperationResult> Create(RegisterUserViewModel command)
        {
            var operation = new OperationResult();
           
            try
            {
                //check for IsExist
                if (_repository.IsExist(x => x.Email == command.Email.FixEmail()))
                    return operation.Failed(ApplicationMessage.DuplicatedEmailAddress);

                //check for IsExist
                if (_repository.IsExist(x => x.FirstName == command.FirstName.ToPascalCase() && x.LastName == command.LastName.ToPascalCase()))
                    return operation.Failed(ApplicationMessage.DuplicatedUser);


                var fileName = "";
                if (command.Avatar != null)
                {
                    if (command.Avatar.IsImage())
                        fileName = _fileUploader.Uploader(command.Avatar, "UserAvatar");
                }

                var unHashPass = command.Password;
                command.Password = _passwordHasher.Hash(command.Password);
                //register user
                if (command.RoleId == RoleType.Teacher)
                {
                    var create = new Account(command.FirstName.ToPascalCase(), command.LastName.ToPascalCase(), command.Email.FixEmail(), command.Phone,
                        command.Password, fileName,
                        command.RoleId, NameGenerator.UniqCode(), new List<Teacher>
                        {
                            new("", "", "", command.Id, ThisType.Teacher)
                        });
                    _repository.Create(create);
                }
                else if (command.RoleId == RoleType.Blogger)
                {
                    var create = new Account(command.FirstName.ToPascalCase(), command.LastName.ToPascalCase(), command.Email.FixEmail(), command.Phone,
                        command.Password, fileName,
                        command.RoleId, NameGenerator.UniqCode(), new List<Teacher>
                        {
                            new("", "", "", command.Id, ThisType.Blogger)
                        });
                    _repository.Create(create);
                }
                else
                {
                    var create = new Account(command.FirstName.ToPascalCase(), command.LastName.ToPascalCase(), command.Email.FixEmail(), command.Phone,
                        command.Password, fileName,
                        command.RoleId, NameGenerator.UniqCode(), command.Area, command.AboutMe);
                    _repository.Create(create);
                    var domainUrl = _authHelper.GetCurrentDomainUrl();
                    var model = new SendActivityEmailModel(create.FirstName + " " + create.LastName, domainUrl, create.ActiveCode);
                    var body = await _renderer.RenderPartialToStringAsync("_SentActivityEmail", model);
                    try
                    {
                        SendEmail.Send(create.Email, "تائید ایمیل", body);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError($"ایمیل ثبت نام ارسال نشد:{e}", e.Data);
                    }
                }

                //create notification
                var notification = new Notification($"کاربری جدید با نام ({command.FirstName}) در سایت ثبت نام کرد",
                    ThisType.Account, command.Id);
                _notification.Create(notification);
                _notification.SaveChanges();
                _repository.SaveChanges();
             
                Login(new LoginViewModel()
                {
                    Email = command.Email,
                    Password = unHashPass,
                    RememberMe = true,
                });

                return operation.Succeeded("ثبت نام شما با موفقیت انجام شد");
            }
            catch (Exception e)
            {
                _logger.LogError($"Data:{e.Data},Exception:{e},Message:{e.Message}");
                return operation.Failed(ApplicationMessage.ServerError);
            }
        }


        public OperationResult Edit(EditAccountViewModel command)
        {
            var operation = new OperationResult();

            try
            {
                if (_repository.IsExist(x => x.Email == command.Email.FixEmail() && x.Id != command.Id))
                    return operation.Failed(ApplicationMessage.DuplicatedRecord);

                //check for IsExist
                if (_repository.IsExist(x => (x.FirstName == command.FirstName.ToPascalCase() && x.LastName == command.LastName.ToPascalCase()) && x.Id != command.Id))
                    return operation.Failed(ApplicationMessage.DuplicatedUser);
                if (command.Password != null)
                    command.Password = _passwordHasher.Hash(command.Password);
                var getUser = _repository.GetById(command.Id);

                var currentUserRoleId = _authHelper.CurrentAccountInfo().RoleId;
                if (currentUserRoleId != RoleType.NoAuthorize && currentUserRoleId != RoleType.Manager)
                {
                    if (getUser.RoleId == RoleType.Manager)
                        return operation.Failed("شما اجازه تغییر نقش به مدیر سایت را ندارید");
                }

                var fileName = "UserAvatar/" + command.Avatar?.FileName;
                if (command.Avatar != null)
                {
                    //check for image
                    if (command.Avatar.IsImage())
                    {
                        //delete image
                        var deletePath = $"wwwroot/FileUploader/UserAvatar/{getUser.Avatar}";
                        if (File.Exists(deletePath))
                            File.Delete(deletePath);

                        //resize to 315 X 315
                        #region 315 X 315
                        var image = Image.FromStream(command.Avatar.OpenReadStream());
                        var resized = new Bitmap(image, new Size(315, 315));

                        using var imageStream = new MemoryStream();
                        resized.Save(imageStream, ImageFormat.Jpeg);
                        var imageBytes = imageStream.ToArray();

                        var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/FileUploader/", fileName);
                        using var streamImg = new FileStream(
                            path, FileMode.Create, FileAccess.Write, FileShare.Write, 4096);
                        streamImg.Write(imageBytes, 0, imageBytes.Length);
                        #endregion
                    }

                }



                if (getUser == null) return operation.Failed(ApplicationMessage.RecordNotFount);

                switch (command.RoleId)
                {
                    case RoleType.Blogger:
                        getUser.Edit(command.FirstName.ToPascalCase(), command.LastName.ToPascalCase(), command.Email.FixEmail(), command.Phone, fileName,
                            command.RoleId, new List<Teacher>
                            {
                            new("", "", "", command.Id, ThisType.Blogger)
                            }, command.ActiveCode, command.Area, 0);
                        _repository.Update(getUser);
                        break;

                    case RoleType.Teacher:
                        getUser.Edit(command.FirstName.ToPascalCase(), command.LastName.ToPascalCase(), command.Email.FixEmail(), command.Phone, fileName,
                            command.RoleId, new List<Teacher>
                            {
                            new("", "", "", command.Id, ThisType.Teacher)
                            }, command.ActiveCode, command.Area, 0);
                        _repository.Update(getUser);
                        break;

                    default:
                        getUser.Edit(command.FirstName.ToPascalCase(), command.LastName.ToPascalCase(), command.Email.FixEmail(), command.Phone, fileName,
                            command.RoleId, command.ProvinceId, command.Gander, command.BirthDate, command.Area, command.AboutMe);
                        _repository.Update(getUser);
                        break;
                }

                _repository.SaveChanges();
                _teacher.SaveChanges();
                if (getUser.RoleId != command.RoleId)
                {
                    //ToDo Re-Login
                }
                return operation.Succeeded();
            }
            catch (Exception e)
            {
                _logger.LogError($"Data:{e.Data},Exception:{e},Message:{e.Message}");
                return operation.Failed(ApplicationMessage.ServerError);
            }

        }


        public OperationResult Active(long id)
        {
            var operation = new OperationResult();

            var getUser = _repository.GetById(id);
            if (getUser == null) return operation.Failed(ApplicationMessage.RecordNotFount);

            getUser.Active(id);
            _repository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult DeActive(long id)
        {
            var operation = new OperationResult();

            var getUser = _repository.GetById(id);

            if (getUser == null) return operation.Failed(ApplicationMessage.RecordNotFount);
            getUser.DeActive(id);
            _repository.SaveChanges();
            return operation.Succeeded();
        }


        public OperationResult ChangePassword(ChangePasswordViewModel command)
        {
            var operation = new OperationResult();
            try
            {

                var getUser = _repository.GetById(command.Id);
                if (getUser == null) return operation.Failed(ApplicationMessage.RecordNotFount);

                var check = _passwordHasher.Check(getUser.Password, command.OldPassword);
                if (!check.Verified) return operation.Failed(ApplicationMessage.PasswordNotFount);

                getUser.ChangePassword(command.NewPassword);
                _repository.SaveChanges();
                return operation.Succeeded();
            }
            catch (Exception e)
            {
                _logger.LogError($"Data:{e.Data},Exception:{e},Message:{e.Message}");
                return operation.Failed(ApplicationMessage.ServerError);
            }

        }

        public OperationResult EditTeacher(EditTeacherViewModel edit)
        {
            var operation = new OperationResult();

            try
            {
                var getUser = _teacher.GetById(edit.Id);
                if (getUser == null) return operation.Failed(ApplicationMessage.RecordNotFount);

                getUser.Edit(edit.Skills, edit.Bio, edit.Resumes, edit.AccountId, edit.Type);
                _teacher.Update(getUser);
                _teacher.SaveChanges();
                return operation.Succeeded();
            }
            catch (Exception e)
            {
                _logger.LogError($"Data:{e.Data},Exception:{e},Message:{e.Message}");
                return operation.Failed(ApplicationMessage.ServerError);
            }
        }

        public async Task<OperationResult> ForgotPassword(ForgotPasswordViewModel command)
        {
            
            var result = new OperationResult();
            var user = _repository.GetUserBy(command.Email.FixEmail());
            if (user == null) return result.Failed(ApplicationMessage.RecordNotFount);
            if (!user.IsActive) return result.Failed(ApplicationMessage.AccountInactive);

            command.ActiveCode = user.ActiveCode;
            var currentUrl = _authHelper.GetCurrentDomainUrl();
            command.CurrentUrl = currentUrl;
            var emailBody = _renderer.RenderPartialToStringAsync("_ResetPassword", command);
            SendEmail.Send(command.Email, "Recovery Password", await emailBody);
            return result.Succeeded(ApplicationMessage.ResetPasswordEmailSent);
        }

        public Task<OperationResult> ResetPassword(ResetPasswordViewModel command)
        {
            var result = new OperationResult();
            var user = _repository.GetUserByActiveCode(command.ActiveCode);
            if (user == null) return Task.FromResult(result.Failed(ApplicationMessage.ServerError));
            command.Password = _passwordHasher.Hash(command.Password);
            user.ChangePassword(command.Password);
            user.ChangeActiveCode(user.Id);
            _repository.Update(user);
            _repository.SaveChanges();
            return Task.FromResult(result.Succeeded(ApplicationMessage.PasswordChangedSuccessfully));
        }

        public OperationResult Login(LoginViewModel command)
        {
            return _repository.Login(command);
        }

        public long GetUserIdBy(string email)
        {
            return _repository.GetUserIdBy(email);
        }
        /// <summary>
        /// دریافت ایمیل کابر بر اساس شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ایمیل آدرس کاربر</returns>
        public string GetUserEmailIdBy(long id)
        {
            return _repository.GetById(id).Email;
        }
        public List<AccountViewModel> ShowBlockedUser()
        {
            return _repository.ShowBlockedUser();
        }

        public EditTeacherViewModel GetTeacherDetails(long id)
        {
            return _teacher.GetTeacherDetails(id);
        }

        public BlockUserViewModel GetUserForUnblock(long id)
        {
            return _repository.GetUserForUnblock(id);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _repository.Search(searchModel);
        }

        public EditAccountViewModel GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }

        public BlockUserViewModel GetUserForBlock(long id)
        {
            return _repository.GetUserForBlock(id);
        }

        public void ConfirmUnblockUser(long id)
        {
            _repository.ConfirmUnblockUser(id);
        }

        public void Logout()
        {
            _repository.Logout();
        }
    }
}