﻿using Afg.Azad.UnQuery.Contract.Course;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.Pages.ViewComponent
{
    public class PopularCourseViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly ICourseQuery _courseQuery;

        public PopularCourseViewComponent(ICourseQuery courseQuery)
        {
            _courseQuery = courseQuery;
        }

        public IViewComponentResult Invoke()
        {
            var popularCourse = _courseQuery.PopularCourses();
            return View("Default", popularCourse);
        }
    }
}