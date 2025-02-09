﻿using System.Collections.Generic;
using _0_FrameWork.Application;
using Shop.Management.Application.Contract.UserCourse;

namespace Shop.Management.Application.Contract.Course
{
    public interface ICourseApplication
    {
        OperationResult Create(CreateCourseViewModel command);
        OperationResult Edit(EditCourseViewModel command);
        EditCourseViewModel GetDetails(long id);
        List<CourseViewModel> Search(CourseSearchModel searchModel);
        List<CourseViewModel> SelectCourses();
        List<UserCourseViewModel> GetUserCourseBy(long courseId);
    }
}