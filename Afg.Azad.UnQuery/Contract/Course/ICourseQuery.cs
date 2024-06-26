using System.Collections.Generic;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.Account.Agg;
using Shop.Management.Application.Contract.Course;
using Shop.Management.Application.Contract.UserCourse;
using ShopManagement.Domain.CourseEpisodeAgg;
using ShopManagement.Domain.CourseLevelAgg;

namespace Afg.Azad.UnQuery.Contract.Course
{
    public interface ICourseQuery
    {
        CoursePaginationViewModel GetAllCourse(CourseQuerySearchModel searchQuery,string search, int pageId = 1);
        List<GetCourseGroupViewModel> GetCourseGroup(string slug);
        List<LatestCourseViewModel> LatestCourses();
        List<GetPopularCourseViewModel> PopularCourses();
        List<TeacherViewModel> TeacherList();
        List<CourseLevel> GetLevel();
        CourseQueryModel GetCourseBySlug(string slug, string ipAddress);
        bool UserInCourse(string email, long courseId);
        CourseEpisode GetEpisodeFile(long episodeId);
        List<AccountManagement.Domain.Account.Agg.Account> GetAllUsers();
        double GetTotalMinutesEpisodeVideos();
        List<BlogManagement.Domain.ArticleAgg.Article> GetAllArticle();
        List<Teacher> GetAllTeacher();
        List<UserCourseViewModel> GetUserCourseBy(string email);
        List<GetSimilarCourseViewModel> SimilarCourses(string slug);
        List<LastCourseFooter> FooterCourse();
        List<LastCourseGroupFooter> FooterCourseGroup();
        List<UserCourseViewModel> GetUserCourseBy(int courseId);

        List<CourseViewModel> AutoCompleteSearch(string search);
    }
}