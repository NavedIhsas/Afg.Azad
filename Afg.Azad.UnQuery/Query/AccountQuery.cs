using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using _0_Framework.Application;
using _0_FrameWork.Application;
using AccountManagement.Domain.Account.Agg;
using AccountManagement.Domain.ProvinceAgg;
using AccountManagement.Infrastructure.EfCore;
using Afg.Azad.UnQuery.Contract.Account;
using Afg.Azad.UnQuery.Contract.ContactUs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;
using Shop.Management.Application.Contract.UserCourse;
using ShopManagement.Domain.CourseAgg;
using ShopManagement.Infrastructure.EfCore;

namespace Afg.Azad.UnQuery.Query
{
    public class AccountQuery : IAccountQuery
    {
        private readonly AccountContext _context;
        private readonly IFileUploader _fileUploader;
        private readonly ILogger<AccountQuery> _logger;
        private readonly ICourseRepository _courseRepository;
        private readonly IPasswordHasher _hasher;
        private readonly IUserCourseInfoApplication _userCourseRegisterApplication;
        public AccountQuery(AccountContext context, IFileUploader fileUploader, ILogger<AccountQuery> logger, ICourseRepository courseRepository, IPasswordHasher hasher, IUserCourseInfoApplication userCourseRegisterApplication)
        {
            _context = context;
            _fileUploader = fileUploader;
            _logger = logger;
            _courseRepository = courseRepository;
            _hasher = hasher;
            _userCourseRegisterApplication = userCourseRegisterApplication;
        }

        public UserInformationQueryModel UserInformation(string email)
        {

            var rr = _context.Accounts.Where(x => x.Email == email).Select(x => new UserInformationQueryModel
            {
                Firstname = x.FirstName,
                Email = x.Email,
                Phone = x.Phone,
                //Skill = MapTeacher(x.Teachers),
                City = x.City.Name,
                Province = x.City.Province.Name,
                RoleName = x.Role.Name,
                AvatarName = x.Avatar,
                Gander = x.Gander,
                Id = x.Id,
                Area = x.Area,
                Lastname = x.LastName,
                AboutMe = x.AboutMe,
                BirthDate = x.BirthDate.ToFarsi()
            }).Single();
            return rr;
        }

        public List<ProvinceViewModel> ProvinceSelectList()
        {
            return _context.Provinces.Select(x => new ProvinceViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).AsNoTracking().ToList();
        }

        public List<CityViewModel> CitySelectList()
        {
            return _context.Cities.Select(x => new CityViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<SelectListItem> GetCitiesFormProvince(long provinceId)
        {
            var city = _context.Cities.Where(g => g.ProvinceId == provinceId)
                .Select(g => new SelectListItem()
                {
                    Text = g.Name,
                    Value = g.Id.ToString()
                }).ToList();
            return city;
        }

        private static string MapTeacher(IEnumerable<Teacher> teachers)
        {
            return teachers.Select(x => x.Skills).FirstOrDefault();
        }

        public EditProfileQueryModel GetDetails(string email)
        {

            return _context.Accounts.Where(x => x.Email == email).Include(x => x.City).ThenInclude(x => x.Province).Select(x => new EditProfileQueryModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Area = x.Area,
                Email = x.Email,
                Phone = x.Phone,
                Password = x.Password,
                Id = x.Id,
                Gander = x.Gander,
                RoleId = x.RoleId,
                ActiveCode = x.ActiveCode,
                AvatarName = x.Avatar,
                CityId = x.CityId,
                BirthDate = x.BirthDate.ToFarsi().ToPersianNumber(),
                ProvinceId = x.City.Province.Id,
                AboutMe = x.AboutMe
            }).FirstOrDefault();
        }

        public OperationResult EditProfile(EditProfileQueryModel command)
        {
            var result = new OperationResult();

            try
            {
                var user = _context.Accounts.Find(command.Id);
                var imgName = "";

                if (command.Avatar != null)
                {
                    if (!command.Avatar.IsImage())
                        return result.Failed(ApplicationMessage.IsNotImage);

                    imgName = _fileUploader.Uploader(command.Avatar, "UserAvatar");
                    //delete current avatar
                    var currentFile = $"wwwroot/FileUploader/{user?.Avatar}";
                    if (File.Exists(currentFile))
                        File.Delete(currentFile);

                }
                try
                {
                    command.BirthDate.ToGeorgianDateTime();
                }
                catch (Exception e)
                {
                    _logger.LogError($"message: {e.Message}, Data: {command.BirthDate},Inner Exception: {e.InnerException}");
                    return result.Failed(ApplicationMessage.InvalidBirthDate);
                }

                if (user == null) return result.Failed(ApplicationMessage.RecordNotFount);
                user.Edit(command.FirstName.ToPascalCase(), command.LastName.ToPascalCase(), command.Email, command.Phone, imgName, command.RoleId, command.CityId, command.Gander, command.BirthDate.ToGeorgianDateTime(), command.Area, command.AboutMe);

                _context.Accounts.Update(user);
                _context.SaveChanges();
                return result.Succeeded(ApplicationMessage.OperationDone);
            }
            catch (Exception e)
            {
                _logger.LogError($"Message: {e.Message}, Data:{command},Inner Exception: {e.InnerException}");
                return result.Failed(ApplicationMessage.ServerError);
            }
        }

        public OperationResult ChangePassword(string email, ChangePasswordViewModel command)
        {
            var result = new OperationResult();
            var user = _context.Accounts.FirstOrDefault(x => x.Email == email);
            if (user == null) return result.Failed(ApplicationMessage.ServerError);

            var (verified, _) = _hasher.Check(user.Password, command.OldPassword);
            if (!verified) return result.Failed(ApplicationMessage.IncorrectPassword);
            var hash = _hasher.Hash(command.NewPassword);
            user.ChangePassword(hash);
            _context.Update(user);
            _context.SaveChanges();
            return result.Succeeded(ApplicationMessage.OperationDone);

        }

        public OperationResult RegisterCourse(UserInformationQueryModel user, long courseId)
        {
            var operation = new OperationResult();
            var thisUser = _context.Accounts.SingleOrDefault(x => x.Email == user.Email);
            if (thisUser == null) return operation.Failed(ApplicationMessage.ServerError);


           
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                try
                {
                    user.BirthDate.ToGeorgianDateTime();
                }
                catch
                { return operation.Failed(ApplicationMessage.BirthDate); }

                var userInCourse = _courseRepository.GetUserCourseBy(courseId);
                if (userInCourse.Any(x => x.AccountId == thisUser.Id))
                    return operation.Failed(ApplicationMessage.AlreadyRegisteredInCourse);
                

                var userCourse = _courseRepository.CreateUserCourse(courseId, thisUser.Id);
                if (!userCourse.IsSucceeded)
                    return operation.Failed(ApplicationMessage.ServerError);

                var result = _userCourseRegisterApplication.Create(new CreateUserCourseInfo()
                {
                    PersonalPhoto = user.Photo,
                    AccountId = thisUser.Id,
                    CourseId = courseId,
                    FatherName = user.FatherName,
                    NationalCode = user.NationalCode,
                    NationalPhoto = user.NationalPhoto,
                    //BirthDate = user.BirthDate,
                    CityId = user.CityId,
                    UserCourseId = userCourse.Data.Id,
                    Area = user.Area,
                    Description = user.Description,
                    Mobile = user.Phone,
                    Gender = user.Gander,
                });

                if (!result.IsSucceeded)
                    return operation.Failed(ApplicationMessage.ServerError);

                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                _logger.LogError($"Message: هنگام ثبت نام در کورس خطای زیر رخ داده است : {e}", "Data:" + e.Data);
                return operation.Failed(ApplicationMessage.ServerError);
            }

            return operation.Succeeded();
        }

        public OperationResult ContactUs(CreateContactUs command)
        {
            return new OperationResult();
        }

    }
}
