using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using AccountManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shop.Management.Application.Contract.Course;
using Shop.Management.Application.Contract.Language;
using Shop.Management.Application.Contract.ToBeLearn;
using Shop.Management.Application.Contract.UserCourse;
using ShopManagement.Domain.CourseAgg;
using ShopManagement.Domain.ToBeLearn;
using ShopManagement.Domain.UserCoursesAgg;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class CourseRepository : RepositoryBase<long, Course>, ICourseRepository
    {
        private readonly ShopContext _context;
        private readonly AccountContext _teacher;
        private readonly ILogger<CourseRepository> _logger;
        private readonly ILanguageApplication _languageApplication;
        public CourseRepository(ShopContext dbContext, ShopContext context, AccountContext teacher, ILogger<CourseRepository> logger, ILanguageApplication languageApplication) : base(dbContext)
        {
            _context = context;
            _teacher = teacher;
            _logger = logger;
            _languageApplication = languageApplication;
        }

        public OperationResult<UserCourse> CreateUserCourse(long courseId, long userId)
        {
            var operation = new OperationResult<UserCourse>();
            try
            {
                var add = new UserCourse(userId, courseId);
                _context.UserCourses.Add(add);
                _context.SaveChanges();
                return operation.Succeeded(add);
            }
            catch (Exception e)
            {
                _logger.LogError($"هنگام ثبت کاربر در یک کورس خطای زیر رخ داده است {e}", "Data:" + e.Data);
                return operation.Failed(ApplicationMessage.ServerError);
            }
        }
        public EditCourseViewModel GetDetails(long id)
        {
            var course = _context.Courses.Include(x => x.ToBeLearns).Include(x => x.NeedToLearns).Select(x => new EditCourseViewModel
            {
                Name = x.Name,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                FileName = x.File,
                Price = x.Price,
                Code = x.Code,
                PictureName = x.Picture,
                StringDemoPoster = x.DemoVideoPoster,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug,
                ToBeLearn = string.Join(",", x.ToBeLearns.Select(t => t.Title)),
                NeedToLean = string.Join(",", x.NeedToLearns.Select(t => t.Title)),
                CourseGroupId = x.CourseGroupId,
                CourseLevelId = x.CourseLevelId,
                CourseStatusId = x.CourseStatusId,
                Id = x.Id,
                CanonicalAddress = x.CanonicalAddress,
                TeacherId = x.TeacherId
            }).FirstOrDefault(x => x.Id == id);

            return course;
        }

        public List<CourseViewModel> Search(CourseSearchModel searchModel)
        {
            var langId = _languageApplication.GetLanguageCulture(CultureInfo.CurrentCulture.Name);
            var query = _context.Courses.Where(x=>x.LanguageId==langId).Include(x => x.CourseGroup).Select(x => new CourseViewModel
            {
                Name = x.Name,
                Picture = x.Picture,
                Code = x.Code,
                CourseGroupId = x.CourseGroup.Id,
                Id = x.Id,
                CourseGroup = x.CourseGroup.Title,
                UpdateDate = x.UpdateDate.ToFarsi(),
                CreationDate = x.CreationDate.ToFarsi(),
                Price = x.Price,
                TeacherId = x.TeacherId,
                Slug = x.Slug
            }).AsNoTracking().ToList();

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name.Trim())).ToList();

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code.Trim())).ToList();

            if (searchModel.CourseGroupId > 0)
                query = query.Where(x => x.CourseGroupId == searchModel.CourseGroupId).ToList();


            var teacherName = _teacher.Teachers.Include(x => x.Account).Select(x => new { x.Id, FullName = x.Account.FirstName })
                .ToList();

            foreach (var item in query)
                item.TeacherName = teacherName.FirstOrDefault(x => x.Id == item.TeacherId)?.FullName;


            var orderly = query.OrderByDescending(x => x.Id).ToList();
            return orderly;
        }

        public List<CourseViewModel> SelectCourses()
        {
            var langId = _languageApplication.GetLanguageCulture(CultureInfo.CurrentCulture.Name);
            return _context.Courses.Select(x => new CourseViewModel
            {
                Title = x.Name,
                Name = x.Name,
                Id = x.Id
            }).AsNoTracking().ToList();
        }

        public Course GetCourseBy(long courseId)
        {
            var course = _context.Courses.Find(courseId);
            return course;
        }

        public List<UserCourseViewModel> GetUserCourseBy(long courseId)
        {
            var userCourse = _context.UserCourses.Where(x => x.CourseId == courseId).Select(x =>
                new UserCourseViewModel
                {
                    AccountId = x.AccountId,
                    CourseId = x.CourseId
                }).ToList();
            return userCourse;
        }

        public string GetCourseSlugBy(long courseId)
        {
            return _context.Courses?.Find(courseId)?.Slug;
        }
    }
}