﻿using System.Collections.Generic;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Management.Application.Contract.Course;
using Shop.Management.Application.Contract.CourseEpisode;

namespace WebHost.Areas.Administration.Pages.Courses.CourseEpisode
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        private readonly ICourseEpisodeApplication _application;
        private readonly ICourseApplication _course;
        public IndexModel(ICourseEpisodeApplication application, ICourseApplication course)
        {
            _application = application;
            _course = course;
        }
        [TempData] public string Message { get; set; }
        public List<CourseEpisodeViewModel> List;
        public CourseEpisodeSearchModel SearchModel;
        public SelectList CourseSelectList;
        
        [NeedPermission(PermissionPlace.ListCourseEpisodes)]
        public void OnGet(CourseEpisodeSearchModel searchModel)
        {
            CourseSelectList = new SelectList(_course.SelectCourses(), "Id", "Name");
            List = _application.Search(searchModel);
        }

        [NeedPermission(PermissionPlace.CreateCourseEpisodes)]
        public IActionResult OnGetCreate()
        {
            var select = new CreateCourseEpisodeViewModel()
            {
                CoursesSelectList = _course.SelectCourses(),
            };
            return Partial("./Create", select);
        }

        public JsonResult OnPostCreate(CreateCourseEpisodeViewModel command)
        {
            var create = _application.Create(command);
            return new JsonResult(create);
        }


        [NeedPermission(PermissionPlace.EditCourseEpisodes)]
        public IActionResult OnGetEdit(long id)
        {
            var getDetails = _application.GetDetails(id);
            getDetails.CoursesSelectList = _course.SelectCourses();
            return Partial("./Edit", getDetails);
        }
        public JsonResult OnPostEdit(EditCourseEpisodeViewModel command)
        {
            var edit = _application.Edit(command);
            return new JsonResult(edit);
        }

       

    }
}
