using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Areas.Administration.Pages.Accounts.Roles
{
    public class CreateModel : PageModel
    {
        private readonly IRoleApplication _role;

        public CreateRoleViewModel Role;

        public CreateModel(IRoleApplication role)
        {
            _role = role;
        }

        [NeedPermission(PermissionPlace.CreateRoles)]
        public void OnGet()
        {
        }

        [NeedPermission(PermissionPlace.CreateRoles)]
        public IActionResult OnPost(CreateRoleViewModel command)
        {
            var create = _role.Create(command);
            return RedirectToPage("Index");
        }
    }
}