using System.Collections.Generic;
using _0_FrameWork.Application;
using _0_FrameWork.Domain;
using Shop.Management.Application.Contract.Course;
using Shop.Management.Application.Contract.UserCourse;
using ShopManagement.Domain.UserCoursesAgg;

namespace ShopManagement.Domain.CourseAgg
{
    public interface ICourseRepository : IRepository<long, Course>
    {
        EditCourseViewModel GetDetails(long id);
        List<CourseViewModel> Search(CourseSearchModel searchModel);
        List<CourseViewModel> SelectCourses();
        Course GetCourseBy(long courseId);
        string GetCourseSlugBy(long courseId);
        OperationResult<UserCourse> CreateUserCourse(long courseId, long userId);
        List<UserCourseViewModel> GetUserCourseBy(long courseId);
    }
}