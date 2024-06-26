using System.Collections.Generic;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebHost.Areas.Administration.Pages.Accounts.Users
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private readonly IAccountApplication _application;
        private readonly IRoleApplication _role;
        public IndexModel(IAccountApplication application, IRoleApplication role, ILogger<IndexModel> logger)
        {
            _application = application;
            _role = role;
            _logger = logger;
        }
        [TempData] public string Message { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }

        public List<AccountViewModel> List;
        public AccountSearchModel SearchModel;
        public SelectList SelectList;

        [NeedPermission(PermissionPlace.ListUsers)]
        public void OnGet(AccountSearchModel searchModel)
        {
            List = _application.Search(searchModel);
            SelectList = new SelectList(_role.GetAll(), "Id", "Name");
        }

        [NeedPermission(PermissionPlace.CreateUsers)]
        public IActionResult OnGetCreate()
        {
            var select = new RegisterUserViewModel()
            {
                SelectList = _role.GetAll(),
            };
            return Partial("./Create", select);
        }

        [NeedPermission(PermissionPlace.CreateUsers)]
        public JsonResult OnPostCreate(RegisterUserViewModel command)
        {
            try
            {
                var create = _application.Create(command);
                return new JsonResult(create);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [NeedPermission(PermissionPlace.ChangePasswordUsers)]
        public IActionResult OnGetChangePassword(long id)
        {
            var password = new ChangePasswordViewModel()
            {
                Id = id,
            };
            return Partial("./ChangePassword", password);
        }

      [NeedPermission(PermissionPlace.ChangePasswordUsers)]
        public JsonResult OnPostChangePassword(ChangePasswordViewModel change)
        {
            var password = _application.ChangePassword(change);
            return new JsonResult(password);
        }


        [NeedPermission(PermissionPlace.ListBlockedUsers)]
        public IActionResult OnGetBlockedUserList()
        {
            var user = _application.ShowBlockedUser();
            return Partial("BlockedUserList", user);
        }

        [NeedPermission(PermissionPlace.BlockUsers)]
        public IActionResult OnGetBlockUser(long id)
        {
            var user = _application.GetUserForBlock(id);
            return Partial("BlockUser", user);
        }

        [NeedPermission(PermissionPlace.BlockUsers)]
        public IActionResult OnGetConfirmBlockUser(long id)
        {
            var getDetails = _application.DeActive(id);

            if (getDetails.IsSucceeded)
                return RedirectToPage("./Index");
            Message = getDetails.Message;
            return RedirectToPage("./Index");
        }

        [NeedPermission(PermissionPlace.UnBlockUsers)]
        public IActionResult OnGetUnblockUser(long id)
        {
            var user = _application.GetUserForUnblock(id);
            return Partial("UnblockUser", user);
        }

        public IActionResult OnGetConfirmUnblockUser(long id)
        {
            _application.ConfirmUnblockUser(id);
            return RedirectToPage("./BlockedUserList");

        }

        public IActionResult OnPostSendEmail(string[] emails, string subject, string body)
        {
            if (emails == null || emails.Length == 0)
                return RedirectToPage("Index", new { msg = "NoSelectUser" });

            try
            {
                foreach (var email in emails)
                    SendEmail.Send(email,subject,body);
                
                return new JsonResult("ایمیل با موفقیت ارسال شد");
            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message} and {e.InnerException}");
                return new JsonResult("ارسال ایمیل با شکست مواجه شد");
            }

        }

    }
}
