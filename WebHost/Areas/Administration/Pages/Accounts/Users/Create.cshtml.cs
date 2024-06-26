using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebHost.Areas.Administration.Pages.Accounts.Users
{
    public class CreateModel : PageModel
    {

        private readonly IAccountApplication _application;
        private readonly IRoleApplication _role;
        public CreateModel(IAccountApplication application, IRoleApplication role)
        {
            _application = application;
            _role = role;
        }

        public RegisterUserViewModel Command;
        public SelectList SelectList;

        [NeedPermission(PermissionPlace.CreateUsers)]
        public void OnGet()
        {
            SelectList = new SelectList(_role.GetAll(), "Id", "Name");
        }

        public async Task<IActionResult> OnPost(RegisterUserViewModel command)
        {
            var create = await _application.Create(command);
            return new JsonResult(create);
        }

    }
}
