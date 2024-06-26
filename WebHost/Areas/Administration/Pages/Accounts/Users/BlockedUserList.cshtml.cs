using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.RoleAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Areas.Administration.Pages.Accounts.Users
{
    public class BlockedUserListModel : PageModel
    {

        private readonly IAccountApplication _application;
        private readonly IRoleApplication _role;
        public BlockedUserListModel(IAccountApplication application, IRoleApplication role)
        {
            _application = application;
            _role = role;
        }

        public List<AccountViewModel> List;

        [NeedPermission(PermissionPlace.BlockUsers)]
        public void OnGet()
        {
            List = _application.ShowBlockedUser();
        }
    }
}
