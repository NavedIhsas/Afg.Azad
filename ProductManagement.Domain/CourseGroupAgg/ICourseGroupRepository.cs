﻿using System.Collections.Generic;
using _0_FrameWork.Domain;
using Shop.Management.Application.Contract.CourseGroup;

namespace ShopManagement.Domain.CourseGroupAgg
{
    public interface ICourseGroupRepository : IRepository<long, CourseGroup>
    {
        EditCourseGroupViewModel GetDetails(long id);
        List<CourseGroupViewModel> Search(CourseGroupSearchModel searchModel);
        List<CourseGroupViewModel> SelectList();
        string GetSlug(long id);
        List<CourseGroupViewModel> GetAll();
        int? CourseCount(long id);
    }
}