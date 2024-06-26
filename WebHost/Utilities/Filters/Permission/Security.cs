using System.Reflection;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.Account.Agg;
using AccountManagement.Domain.RoleAgg;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebHost.Utilities.Filters.Permission
{
    public class Security : IPageFilter
    {
        private readonly IPermissionExpose _permission;
        private readonly IAuthHelper _authHelper;
        private readonly IAccountRepository _accountRepository;
        public Security(IAuthHelper authHelper, IPermissionExpose permission, IAccountRepository accountRepository)
        {
            _authHelper = authHelper;
            _permission = permission;
            _accountRepository = accountRepository;
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (!_authHelper.IsAuthenticated()) return;
            var areaName = context.ActionDescriptor.AreaName;
            if (areaName is not "Administration")return;
            
            var handlerPermission =
                (NeedPermissionAttribute)context.HandlerMethod?.MethodInfo.GetCustomAttribute(
                    typeof(NeedPermissionAttribute));

            if (handlerPermission == null) return;

            var currentAccount = _authHelper.CurrentAccountInfo();

            var user = _accountRepository.GetUserBy(currentAccount.AccountId);

            var permission = _permission.Expose(user.RoleId);

            var checkValue = permission.Any(x => x.Key == handlerPermission.Permission);

            if (!checkValue && user.RoleId != RoleType.NoAuthorize)
                context.HttpContext.Response.Redirect("/Error?handler=AccessDenied");

        }
        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {

        }
    }
}
