using System.Collections.Generic;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using AccountManagement.Domain.Account.Agg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Management.Application.Contract.Course;
using Shop.Management.Application.Contract.CourseGroup;
using Shop.Management.Application.Contract.CourseLevel;
using Shop.Management.Application.Contract.CourseStatus;
using ShopManagement.Domain.UserCoursesAgg;

namespace WebHost.Areas.Administration.Pages.Courses.Course
{
    public class IndexModel : PageModel
    {
        private readonly ICourseApplication _course;
        private readonly ICourseGroupApplication _courseGroup;
        private readonly ICourseLevelApplication _courseLevel;
        private readonly ICourseStatusApplication _courseStatus;
        private readonly ITeacherRepository _teacher;
        private readonly IUserCourseInfoRepository _userCourseInfo;

        public IndexModel(ICourseApplication course, ICourseGroupApplication courseGroup, ICourseStatusApplication courseStatus, ICourseLevelApplication courseLevel, ITeacherRepository teacher, IUserCourseInfoRepository userCourseInfo)
        {
            _course = course;
            _courseGroup = courseGroup;
            _courseStatus = courseStatus;
            _courseLevel = courseLevel;
            _teacher = teacher;
            _userCourseInfo = userCourseInfo;
        }

        public SelectList SelectList;
        public CourseSearchModel SearchModel;
        public List<CourseViewModel> Course;

        [NeedPermission(PermissionPlace.ListCourses)]
        public void OnGet(CourseSearchModel searchModel)
        {
            SelectList = new SelectList(_courseGroup.SelectList(), "Id", "Title");
            Course = _course.Search(searchModel);
        }

        [NeedPermission(PermissionPlace.CreateCourses)]
        public IActionResult OnGetCreate()
        {
            var course = new CreateCourseViewModel()
            {
                CourseGroupSelectList = _courseGroup.SelectList(),
                CourseStatusSelectList = _courseStatus.SelectList(),
                CourseLevelSelectList = _courseLevel.SelectList(),
                TeacherSelectList = _teacher.SelectList(),
            };
            return Partial("./Create", course);
        }

        [NeedPermission(PermissionPlace.CreateCourses)]
        public IActionResult OnPostCreate(CreateCourseViewModel command)
        {
            var result = _course.Create(command);
            if (!result.IsSucceeded)
                return new JsonResult(result.Message);
            return RedirectToPage("Index");
        }

        [NeedPermission(PermissionPlace.EditCourses)]
        public IActionResult OnGetEdit(long id)
        {
            var course = _course.GetDetails(id);
            course.TeacherSelectList = _teacher.SelectList();
            course.CourseStatusSelectList = _courseStatus.SelectList();
            course.CourseLevelSelectList = _courseLevel.SelectList();
            course.CourseGroupSelectList = _courseGroup.SelectList();

            return Partial("./Edit", course);

        }

        [NeedPermission(PermissionPlace.EditCourses)]
        public IActionResult OnPostEdit(EditCourseViewModel command)
        {
           var result= _course.Edit(command);
           return new JsonResult(result);
        }

        public IActionResult OnGetStudents(long id)
        {
            var result = _userCourseInfo.GetList(id);
            return Partial("./Students",result);
        }
    }
}
