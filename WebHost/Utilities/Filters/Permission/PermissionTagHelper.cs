using _0_FrameWork.Application;
using AccountManagement.Infrastructure.EfCore;
using Microsoft.AspNetCore.Razor.TagHelpers;
using ShopManagement.Infrastructure.EfCore;

namespace WebHost.Utilities.Filters.Permission
{
    [HtmlTargetElement(Attributes = "Permission")]
    public class PermissionTagHelper : TagHelper
    {
        private readonly IAuthHelper _authHelper;
        private readonly AccountContext _context;

        public PermissionTagHelper(IAuthHelper authHelper, AccountContext context)
        {
            _authHelper = authHelper;
            _context = context;
        }

        public int Permission { get; set; }
        public int Role { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!_authHelper.IsAuthenticated())
            {
                output.SuppressOutput();
                return;
            }

            var roleId = _authHelper.CurrentAccountInfo().RoleId;
            if (roleId !=RoleType.NoAuthorize)
            {
                var permissions = _context.Roles.FirstOrDefault(x => x.Id == roleId)?.Permissions.Select(x => x.Code);
                if (permissions == null)
                {
                    output.SuppressOutput();
                    return;
                }
                if (permissions.All(x => x != Permission))
                {
                    output.SuppressOutput();
                    return;
                }
            }
            base.Process(context, output);
        }
    }
}