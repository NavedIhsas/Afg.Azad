using _0_FrameWork.Application;
using AccountManagement.Application.Contract.City;
using AccountManagement.Domain.Account.Agg;
using Afg.Azad.UnQuery.Contract.Account;
using Afg.Azad.UnQuery.Contract.Comment;
using Afg.Azad.UnQuery.Contract.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Shop.Management.Application.Contract.UserCourse;

namespace WebHost.Areas.UserPanel.Pages
{
    [Authorize]
    public class MyCourseModel : PageModel
    {
       
        private readonly ICourseQuery _course;
        private readonly IAuthHelper _authHelper;

        public MyCourseModel(ICourseQuery course, IAuthHelper authHelper)
        {
            _course = course;
            _authHelper = authHelper;
        }

        public List<UserCourseViewModel> List;
        public void OnGet()
        {
            var email = _authHelper.CurrentAccountInfo().Email;
            List = _course.GetUserCourseBy(email);
        }

    }
}