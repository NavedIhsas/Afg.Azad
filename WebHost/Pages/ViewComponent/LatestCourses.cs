using Afg.Azad.UnQuery.Contract.Course;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.Pages.ViewComponent
{
    public class LatestCourses:Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly ICourseQuery _course;

        public LatestCourses(ICourseQuery course)
        {
            _course = course;
        }

        public IViewComponentResult Invoke()
        {
          var course=  _course.LatestCourses();
          return View("Default",course);
        }
    }
}
