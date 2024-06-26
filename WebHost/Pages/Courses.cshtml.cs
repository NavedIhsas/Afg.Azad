using AccountManagement.Application.Contract.Account;
using Afg.Azad.UnQuery.Contract.Course;
using Afg.Azad.UnQuery.Contract.CourseGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Domain.CourseLevelAgg;

namespace WebHost.Pages
{
    public class CoursesModel : PageModel
    {
        private readonly ICourseQuery _course;
        private readonly ICourseGroupQuery _group;
        public CoursePaginationViewModel Course;
        public List<LatestCourseGroupViewModel> CourseGroups;
        public List<LatestCourseViewModel> LatestCourse;
        public CourseQuerySearchModel SearchModel;
        public List<TeacherViewModel> Teachers;
        public List<CourseLevel> CourseLevels;
        public CoursesModel(ICourseQuery course, ICourseGroupQuery group)
        {
            _course = course;
            _group = group;
        }

        public void OnGet(CourseQuerySearchModel searchModel, string search, int pageId = 1)
        {

            ViewData["Category"] = searchModel.CategoryId;
            ViewData["Teacher"] = searchModel.TeacherId;
            ViewData["Level"] = searchModel.LevelId;
            Course = _course.GetAllCourse(searchModel,search, pageId);
            CourseGroups = _group.LatestCourseGroup();
            //  LatestCourse = _course.LatestCourses();
            Teachers = _course.TeacherList();
            CourseLevels = _course.GetLevel();
        }
    }
}
