using Shop.Management.Application.Contract.CourseGroup;
using System.Collections.Generic;

namespace Afg.Azad.UnQuery.Contract.CourseGroup
{
    public interface ICourseGroupQuery
    {
        List<CourseGroupQueryModel> GetAllCourseGroup();
        List<CourseGroupQueryModel> SearchQuery(CourseGroupSearchQuery categories);
        List<LatestCourseGroupViewModel> LatestCourseGroup();
        List<LatestCourseGroupViewModel> GetSixGroup();
    }
}