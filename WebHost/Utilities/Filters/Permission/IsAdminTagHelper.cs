using _0_FrameWork.Application;
using AccountManagement.Infrastructure.EfCore;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebHost.Utilities.Filters.Permission;

[HtmlTargetElement(Attributes = "Admin")]
public class RoleIdTagHelper : TagHelper
{
    private readonly IAuthHelper _authHelper;
    private readonly AccountContext _context;
    public RoleIdTagHelper(IAuthHelper authHelper, AccountContext context)
    {
        _authHelper = authHelper;
        _context = context;
    }
    public int RoleId { get; set; }
    public int Admin { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (!_authHelper.IsAuthenticated())
        {
            output.SuppressOutput();
            return;
        }

        RoleId = Admin;
        var role = _context.Roles.Find(RoleId);
        if (role==null)
        {
            output.SuppressOutput(); return;
        }

        if (RoleId == RoleType.User && !role.Permissions.Any())
        {
            output.SuppressOutput(); return;
        }

        base.Process(context, output);
    }
}