using System;
using System.Collections;
using System.Collections.Generic;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.City;
using Afg.Azad.UnQuery.Contract.Account;
using Afg.Azad.UnQuery.Contract.Comment;
using AutoMapper;
using Shop.Management.Application.Contract.CourseEpisode;
using Shop.Management.Application.Contract.ToBeLearn;
using Shop.Management.Application.Contract.UserCourse;
using ShopManagement.Domain.OrderDetailAgg;
using ShopManagement.Domain.ToBeLearn;

namespace Afg.Azad.UnQuery.Contract.Course
{

    public class RegisterCourseQueryModel
    {

        public string Name { get; set; }
        public double Price { get; set; }
        public string Code { get; set; }
        public string UpdateDate { get; set; }
        public string TeacherName { get; set; }
        public string CourseLevel { get; set; }
        public string CourseStatus { get; set; }
        public long? TeacherId { get; set; }
        public UserInformationQueryModel User { get; set; }
        public long Id { get; set; }
        public List<ProvinceDto> Province { get; set; }
        public List<CityDto> Cities { get; set; }
        public long CityId { get; set; }
        public string Slug { get; set; }
    }
    public class CourseQueryModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string File { get; set; }
        public double Price { get; set; }
        public string Code { get; set; }
        public string UpdateDate { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string CourseGroupSlug { get; set; }
        public string PictureTitle { get; set; }
        public List<string> Keywords { get; set; }
        public string KeyWords { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }
        public string PosterImg { get; set; }
        public string CourseGroup { get; set; }
        public string TeacherName { get; set; }
        public string TeacherBio { get; set; }
        public string TeacherResume { get; set; }
        public string TeacherSkills { get; set; }
        public string TeacherAvatar { get; set; }

        // ToDo check this for: reference form here to domain
        public List<CommentManagement.Domain.CourseCommentAgg.Comment> CommentList { get; set; }

        public List<UserCourseViewModel> UserCourse { get; set; }
        public List<CourseQueryModel> CourseTeacher { get; set; }
        public int CourseTeacherCount { get; set; }
        public long CourseGroupId { get; set; }
        public long Id { get; set; }
        public string CourseLevel { get; set; }
        public int? VisitCount { get; set; }
        public string CourseStatus { get; set; }
        public List<CourseEpisodeViewModel> EpisodeCourse { get; set; }
        public List<CommentQueryModel> Comments { get; set; }
        public DateTime CreationDate { get; internal set; }
        public int EpisodeCount { get; internal set; }
        public long? TeacherId { get; internal set; }
        public string CanonicalAddress { get; set; }
        public List<ToBeLearn> ToBeLearn { get; set; }
        public int ToBeLearnCount { get; set; }
        public TimeSpan Time { get; set; }
        public int UserCourseCount { get; set; }
        public CourseQueryModel SimilarCourse { get; set; }
        public List<NeedToLearn> NeedToLearn { get; set; }
    }

    public class GetCourseGroupViewModel
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public long CourseGroupId { get; set; }
        public string PictureTitle { get; set; }
        public string PictureAlt { get; set; }
        public string Slug { get; set; }
        public double Price { get; set; }
        public string Level { get; set; }
        public TimeSpan TotalTime { get; set; }
        public List<UserCourseViewModel> UserCourse { get; set; }
        public long Id { get; internal set; }
    }

    public class LatestCourseViewModel
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public double Price { get; set; }
        public long CourseGroupId { get; set; }
        public string ShortDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public TimeSpan TotalTime { get; set; }
        public List<UserCourseViewModel> UserCourse { get; set; }
        public string Level { get; set; }
        public TeacherViewModel Teacher { get; set; }
    }

    public class GetSimilarCourseViewModel
    {
        public string Name { get; set; }
        public long? TeacherId { get; set; }
        public string Picture { get; set; }
        public string PictureTitle { get; set; }
        public string PictureAlt { get; set; }
        public long CourseGroupId { get; set; }
        public string Slug { get; set; }
        public string Level { get; set; }
        public double Price { get; set; }
        public int UserCourseCount { get; set; }
        public TimeSpan TotalTime { get; set; }
        public List<UserCourseViewModel> UserCourse { get; set; }
        public TeacherViewModel Teacher { get; set; }
        public long Id { get; internal set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }

    public class GetPopularCourseViewModel
    {
        public string Name { get; set; }
        public long? TeacherId { get; set; }
        public string Picture { get; set; }
        public string PictureTitle { get; set; }
        public string PictureAlt { get; set; }
        public long CourseGroupId { get; set; }
        public string Slug { get; set; }
        public string Level { get; set; }
        public double Price { get; set; }
        public int UserCourseCount { get; set; }
        public TimeSpan TotalTime { get; set; }
        public List<UserCourseViewModel> UserCourse { get; set; }
        public TeacherViewModel Teacher { get; set; }
        public long Id { get; internal set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }

    public class GetAllCourseQueryModel
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public long? LevelId { get; set; }
        public long Id { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string File { get; set; }
        public double Price { get; set; }
        public string Code { get; set; }
        public string UpdateDate { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string KeyWords { get; set; }
        public List<string> Keywords { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }
        public string CourseGroup { get; set; }
        public long CourseGroupId { get; set; }
        public long? SubGroupId { get; set; }
        public string TeacherName { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public TimeSpan TotalTime { get; set; }
        public DateTime CreationDate { get; internal set; }
        public TeacherViewModel Teacher { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<UserCourseViewModel> UserCourse { get; set; }
        public List<CommentManagement.Domain.CourseCommentAgg.Comment> Comments { get; set; }
        public long? TeacherId { get; internal set; }
        public List<GetAllCourseQueryModel> Courses { get; set; }

        public List<bool> Visits { get; set; }
        public List<ToBeLearnDto> ToBeLearns { get; set; }
        public List<NeedToLearnDto> NeedToLearn { get; set; }
    }

    public class VisitViewModel
    {
        public int Type { get; set; }
        public long OwnerId { get; set; }
        public int NumberOfVisit { get; set; }
        public long Id { get; set; }
        public List<GetAllCourseQueryModel> Courses { get; set; }
    }

    public class CoursePaginationViewModel
    {
        public CoursePaginationViewModel()
        {
            Courses = new List<GetAllCourseQueryModel>();
        }

        public List<GetAllCourseQueryModel> Courses { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}