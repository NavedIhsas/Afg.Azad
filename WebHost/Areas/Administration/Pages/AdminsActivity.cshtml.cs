using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using CommentManagement.Application.Contract.HomePhoto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Areas.Administration.Pages
{
    public class TestModel : PageModel
    {

        [NeedPermission(PermissionPlace.AdministrationHomepage)]
        public void OnGet()
        {
           
        }

    }
}
