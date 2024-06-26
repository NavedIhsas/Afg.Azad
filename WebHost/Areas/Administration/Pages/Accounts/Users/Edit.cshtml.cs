using System.Collections.Generic;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.Account.Agg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Areas.Administration.Pages.Accounts.Users
{
    public class EditModel : PageModel
    {

        private readonly IAccountApplication _application;
        private readonly IRoleApplication _role;
        [TempData]
        public string Message { get; set; }
        public EditModel(IAccountApplication application, IRoleApplication role)
        {
            _application = application;
            _role = role;
        }

        public EditAccountViewModel Edit;

        [NeedPermission(PermissionPlace.EditUsers)]
        public void OnGet(long id)
        {
            Edit = _application.GetDetails(id);
            Edit.SelectList = _role.GetAll();
        }
        public IActionResult OnPost(EditAccountViewModel edit)
        {
            var post = _application.Edit(edit);
            if (!post.IsSucceeded)
            {
                Message = post.Message;
                Edit = _application.GetDetails(edit.Id);
                Edit.SelectList = _role.GetAll();
                return Page();
            }
            return RedirectToPage("Index");
        }

    }
}
