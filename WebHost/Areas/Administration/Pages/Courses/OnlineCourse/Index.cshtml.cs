using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Management.Application.Contract.Course;
using Shop.Management.Application.Contract.CourseEpisode;
using Shop.Management.Application.Contract.OnlineCourse;
using ShopManagement.Domain.CourseAgg;

namespace WebHost.Areas.Administration.Pages.Courses.OnlineCourse
{
    public class IndexModel : PageModel
    {
        private readonly IOnlineCourseApplication _application;
        private readonly ICourseApplication _courseApplication;
        public IndexModel(IOnlineCourseApplication application, ICourseApplication courseApplication)
        {
            _application = application;
            _courseApplication = courseApplication;
        }

        public List<OnlineCourseViewModel> List;
        [NeedPermission(PermissionPlace.ListOnlineCourse)]
        public void OnGet()
        {
          List=  _application.List();
        }

        [NeedPermission(PermissionPlace.CreateOnlineCourse)]
        public IActionResult OnGetCreate()
        {
            var select = new CreateOnlineCourse()
            {
                CoursesSelectList = _courseApplication.SelectCourses(),
            };
            return Partial("./Create", select);
        }

        public JsonResult OnPostCreate(CreateOnlineCourse command)
        {
            var create = _application.Create(command);
            return new JsonResult(create);
        }


        [NeedPermission(PermissionPlace.EditOnlineCourse)]
        public IActionResult OnGetEdit(long id)
        {
            var getDetails = _application.GetDetails(id);
            getDetails.CoursesSelectList = _courseApplication.SelectCourses();
            return Partial("./Edit", getDetails);
        }
        public JsonResult OnPostEdit(EditOnlineCourse command)
        {
            var edit = _application.Edit(command);
            return new JsonResult(edit);
        }

    }
}
