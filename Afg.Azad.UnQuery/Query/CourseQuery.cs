using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.Account.Agg;
using AccountManagement.Infrastructure.EfCore;
using Afg.Azad.UnQuery.Contract;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Infrastructure.EfCore;
using CommentManagement.Domain.VisitAgg;
using CommentManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Application.Contract.CourseEpisode;
using Shop.Management.Application.Contract.UserCourse;
using ShopManagement.Domain.CourseEpisodeAgg;
using ShopManagement.Domain.UserCoursesAgg;
using ShopManagement.Infrastructure.EfCore;
using Afg.Azad.UnQuery.Contract.Course;
using Afg.Azad.UnQuery.Contract.Comment;
using Shop.Management.Application.Contract.Course;
using Shop.Management.Application.Contract.ToBeLearn;
using ShopManagement.Domain.CourseLevelAgg;
using ShopManagement.Domain.ToBeLearn;
using AngleSharp.Dom;

namespace Afg.Azad.UnQuery.Query
{
    // ReSharper disable  CommentTypo
    public class CourseQuery : ICourseQuery
    {
        private readonly AccountContext _account;
        private readonly IAccountRepository _accountRepository;
        private readonly BlogContext _article;
        private readonly CommentContext _comment;
        private readonly ILanguageQuery _languageQuery;
        private readonly ShopContext _context;
        private readonly IVisitRepository _visit;


        public CourseQuery(ShopContext context, CommentContext comment, AccountContext account,
            IAccountRepository accountRepository, IVisitRepository visit, BlogContext article, ILanguageQuery languageQuery)
        {
            _context = context;
            _comment = comment;
            _account = account;
            _accountRepository = accountRepository;
            _visit = visit;
            _article = article;
            _languageQuery = languageQuery;
        }

        public CoursePaginationViewModel GetAllCourse(CourseQuerySearchModel searchQuery, string search,
            int pageId = 1)
        {

            var culture = CultureInfo.CurrentCulture.Name;
            var langId = _languageQuery.GetLanguageId(culture);
            var query = _context.Courses.Where(x => x.LanguageId == langId).Where(x => x.LanguageId == langId)
                .Include(x => x.UserCourses)
                .Include(x => x.CourseLevel)
                .Include(x => x.CourseEpisodes).Include(x => x.CourseGroup).Include(x => x.OrderDetails)
                .Include(course => course.ToBeLearns).Include(course => course.NeedToLearns)
                .OrderByDescending(x=>x.CreationDate).AsNoTracking()
                .AsEnumerable().Select(x => new GetAllCourseQueryModel
                {
                    Name = x.Name,
                    Description = x.Description,
                    ShortDescription = x.ShortDescription,
                    File = x.File,
                    Teacher = MapTeacher(x.TeacherId),
                    Price = x.Price,
                    Code = x.Code,
                    UpdateDate = x.UpdateDate.ToFarsi(),
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    KeyWords = x.KeyWords,
                    MetaDescription = x.MetaDescription,
                    Slug = x.Slug,
                    Id = x.Id,
                    ToBeLearns = MapToBeLearn(x.ToBeLearns),
                    NeedToLearn = MapNeedToLearn(x.NeedToLearns),
                    Level = x.CourseLevel?.Title,
                    LevelId = x.CourseLevelId,
                    CourseGroup = x.CourseGroup.Title,
                    TeacherId = x.TeacherId,
                    UserCourse = MapUserCourse(x.UserCourses),
                    CreationDate = x.CreationDate,
                    CourseGroupId = x.CourseGroupId,
                    SubGroupId = x.CourseGroup.SubGroupId,
                    OrderDetails = x.OrderDetails,
                    TotalTime = new TimeSpan(x.CourseEpisodes.Sum(t => t.Time.Ticks))
                }).ToList();

            foreach (var item in query)
            {

                //color
                if (searchQuery.CategoryId != null && searchQuery.CategoryId.Any())
                    query = query.Where(x => searchQuery.CategoryId.Contains(x.CourseGroupId)).ToList();

                if (searchQuery.TeacherId != null && searchQuery.TeacherId.Any())
                    query = query.Where(x => searchQuery.TeacherId.Contains(x.TeacherId)).ToList();

                if (searchQuery.LevelId != null && searchQuery.LevelId.Any())
                    query = query.Where(x => searchQuery.LevelId.Contains(x.LevelId)).ToList();

                if (searchQuery.SubGroupId != 0)
                    query = query.Where(x => x.CourseGroupId == searchQuery.SubGroupId || x.SubGroupId == searchQuery.SubGroupId).ToList();

                //get comment list
                var comments = _comment.Comments.Where(x => x.OwnerRecordId == item.Id && x.Type == ThisType.Course)
                    .ToList();
                item.Comments = comments;

                //get teacher account
                //var teacher = _account.Teachers.Include(x => x.Account).FirstOrDefault(x => x.Id == item.TeacherId);
                //if (teacher == null) continue;
                //item.TeacherName = teacher.Account.FirstName;

                //tag
                if (!string.IsNullOrWhiteSpace(item.KeyWords))
                {
                    var tag = new GetAllCourseQueryModel
                    {
                        Keywords = item.KeyWords.Split("-").Take(8).ToList()
                    };
                    item.Keywords = tag.Keywords;
                }
            }

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(x => x.Name.ToLower().Trim().Contains(search.ToLower().Trim())
                                         || x.CourseGroup.ToLower().Trim().Contains(search.ToLower().Trim())
                                         || x.ShortDescription.ToLower().Trim()
                                             .Contains(search.ToLower().Trim())).ToList();


            //search by name or short description
            if (!string.IsNullOrWhiteSpace(searchQuery.Search))
                query = query.Where(x => x.Name.ToLower().Trim().Contains(searchQuery.Search.ToLower().Trim())
                                         || x.KeyWords.ToLower().Trim().Contains(searchQuery.Search.ToLower().Trim()) ||
                                         x.ShortDescription.ToLower().Trim()
                                             .Contains(searchQuery.Search.ToLower().Trim())).ToList();

            //sort by
            if (!string.IsNullOrWhiteSpace(searchQuery.Filter))
                query = searchQuery.Filter switch
                {
                    "maxPrice" => query.OrderByDescending(x => x.Price).ToList(),
                    "newest" => query.OrderByDescending(x => x.CreationDate).ToList(),
                    "minPrice" => query.OrderBy(x => x.Price != 0).ToList(),
                    "price" => query.Where(x => x.Price > 0).ToList(),
                    "popular" => query.OrderByDescending(x => x.OrderDetails.Count).Take(4).ToList(),
                    "free" => query.Where(x => x.Price == 0).ToList(),
                    "all" => query,
                    _ => query
                };


            //paging
            const int take = 12;
            var skip = (pageId - 1) * take;

            var list = new CoursePaginationViewModel
            {
                CurrentPage = pageId,
                PageCount = (int)Math.Ceiling(query.Count / (double)take),
                Courses = query.Skip(skip).Take(take).ToList()
            };

            return list;
        }

        private static List<ToBeLearnDto> MapToBeLearn(IEnumerable<ToBeLearn> argToBeLearns)
        {
            return argToBeLearns.Select(x => new ToBeLearnDto()
            {
                Title = x.Title
            }).ToList();
        }
        private static List<NeedToLearnDto> MapNeedToLearn(IEnumerable<NeedToLearn> needToLearn)
        {
            return needToLearn.Select(x => new NeedToLearnDto()
            {
                Title = x.Title
            }).ToList();
        }


        public List<GetCourseGroupViewModel> GetCourseGroup(string slug)
        {
            var langId = _languageQuery.GetLanguageId(CultureInfo.CurrentCulture.Name);

            var course = _context.Courses.Where(x => x.LanguageId == langId)
                .Include(x => x.UserCourses)
                .Include(x => x.CourseEpisodes).Include(x => x.CourseGroup).Include(x => x.OrderDetails).AsNoTracking()
                .Where(x => x.CourseGroup.Slug == slug)
                .AsEnumerable().Select(x => new GetCourseGroupViewModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    CourseGroupId = x.CourseGroupId,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    Id = x.Id,
                    UserCourse = MapUserCourse(x.UserCourses),
                    TotalTime = new TimeSpan(x.CourseEpisodes.Sum(t => t.Time.Ticks))
                }).ToList();

            return course;
        }

        public List<LatestCourseViewModel> LatestCourses()
        {
            var langId = _languageQuery.GetLanguageId(CultureInfo.CurrentCulture.Name);
            var course = _context.Courses.Where(x => x.LanguageId == langId).Include(x => x.CourseEpisodes).Include(x => x.CourseLevel).Include(x => x.UserCourses).OrderByDescending(x => x.CreationDate).AsNoTracking().Take(12)
                
                .AsEnumerable().Select(x => new LatestCourseViewModel
                {
                    Name = x.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    Teacher = MapTeacher(x.TeacherId),
                    Price = x.Price,
                    Level = x.CourseLevel?.Title,
                    CreationDate = x.CreationDate,
                    UserCourse = MapUserCourse(x.UserCourses),
                    TotalTime = new TimeSpan(x.CourseEpisodes.Sum(t => t.Time.Ticks))
                }).ToList();

            return course;
        }

        public List<GetPopularCourseViewModel> PopularCourses()
        {
            var langId = _languageQuery.GetLanguageId(CultureInfo.CurrentCulture.Name);
            var popular = _context.Courses.Where(x => x.LanguageId == langId).Include(x => x.CourseEpisodes)
                .Include(x => x.UserCourses)
                .Include(x => x.OrderDetails)
                .Include(x => x.CourseLevel)
                .OrderByDescending(x => x.OrderDetails.Count).Take(8)
                .AsNoTracking().AsEnumerable().Select(x => new GetPopularCourseViewModel
                {
                    TeacherId = x.TeacherId,
                    Name = x.Name,
                    Price = x.Price,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    UserCourseCount = x.UserCourses.Count,
                    Level = x.CourseLevel?.Title,
                    CourseGroupId = x.CourseGroupId,
                    Id = x.Id,
                    Teacher = MapTeacher(x.TeacherId),
                    OrderDetails = x.OrderDetails,
                    UserCourse = MapUserCourse(x.UserCourses),
                    TotalTime = new TimeSpan(x.CourseEpisodes.Sum(t => t.Time.Ticks))
                }).ToList();

            return popular;
        }

        public List<GetSimilarCourseViewModel> SimilarCourses(string slug)
        {
            var unSlug = slug.Replace("-", " ");
            var langId = _languageQuery.GetLanguageId(CultureInfo.CurrentCulture.Name);
            var popular = _context.Courses.Where(x => x.LanguageId == langId).Include(x => x.CourseEpisodes)
                .Where(x => (x.Slug != slug) && (x.Name.Contains(unSlug)))
                .Include(x => x.UserCourses)
                .Include(x => x.OrderDetails)
                .Include(x => x.CourseLevel)
                .OrderByDescending(x => x.OrderDetails.Count).Take(6)
                .AsNoTracking().AsEnumerable().Select(x => new GetSimilarCourseViewModel
                {
                    TeacherId = x.TeacherId,
                    Name = x.Name,
                    Price = x.Price,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    UserCourseCount = x.UserCourses.Count,
                    Level = x.CourseLevel?.Title,
                    CourseGroupId = x.CourseGroupId,
                    Id = x.Id,
                    Teacher = MapTeacher(x.TeacherId),
                    OrderDetails = x.OrderDetails,
                    UserCourse = MapUserCourse(x.UserCourses),
                    TotalTime = new TimeSpan(x.CourseEpisodes.Sum(t => t.Time.Ticks))
                }).ToList();

            return popular;
        }

        private TeacherViewModel MapTeacher(long? teacherId)
        {

            if (teacherId == null) return new TeacherViewModel();
            var teacher = _account.Teachers.Include(x => x.Account).Single(x => x.Id == teacherId);
            var model = new TeacherViewModel
            {
                AccountName = teacher.Account.FirstName + " " + teacher.Account.LastName,
                Photo = teacher.Account.Avatar
            };
            return model;

        }

        public List<TeacherViewModel> TeacherList()
        {
            var list = _account.Teachers.Where(x => x.Type == ThisType.Teacher).Include(x => x.Account).AsNoTracking().AsEnumerable().Select(x => new TeacherViewModel()
            {
                Id = x.Id,
                AccountName = x.Account.FirstName,
                CourseCount = MapCourseCount(x.Id),
            }).ToList();
            return list;
        }

        private int MapCourseCount(long id)
        {
            var langId = _languageQuery.GetLanguageId(CultureInfo.CurrentCulture.Name);
            return _context.Courses.Where(x => x.LanguageId == langId).Count(x => x.TeacherId == id);
        }


        public List<CourseLevel> GetLevel()
        {
            return _context.CourseLevels.Include(x => x.Courses).AsNoTracking().ToList();
        }

        public CourseQueryModel GetCourseBySlug(string slug, string ipAddress)
        {
            var langId = _languageQuery.GetLanguageId(CultureInfo.CurrentCulture.Name);
            var course = _context.Courses.Where(x => x.LanguageId == langId).Include(x => x.CourseLevel).Include(x => x.CourseStatus)
                .Include(x => x.CourseGroup).Include(x => x.UserCourses)
                .Include(x => x.CourseEpisodes)
                .Include(x => x.ToBeLearns).Include(course => course.NeedToLearns)
                .AsNoTracking()
                .AsEnumerable()
                .Select(x => new CourseQueryModel
                {
                    NeedToLearn = x.NeedToLearns,
                    ToBeLearn = x.ToBeLearns,
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ShortDescription = x.ShortDescription,
                    File = x.File,
                    Price = x.Price,
                    Code = x.Code,
                    UpdateDate = x.UpdateDate.ToFarsi(),
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    KeyWords = x.KeyWords,
                    MetaDescription = x.MetaDescription,
                    Slug = x.Slug,
                    CourseGroupId = x.CourseGroupId,
                    TeacherId = x.TeacherId,
                    PosterImg = x.DemoVideoPoster,
                    CourseGroupSlug = x.CourseGroup.Slug,
                    CreationDate = x.CreationDate,
                    CourseGroup = x.CourseGroup.Title,
                    CourseStatus = x.CourseStatus?.Title,
                    CourseLevel = x.CourseLevel?.Title,
                    UserCourse = MapUserCourse(x.UserCourses),
                    EpisodeCourse = MapEpisodeCourse(x.CourseEpisodes),
                    EpisodeCount = x.CourseEpisodes.Count,
                    UserCourseCount = x.UserCourses.Count,
                    ToBeLearnCount = x.ToBeLearns.Count,
                    Time = new TimeSpan(x.CourseEpisodes.Sum(t => t.Time.Ticks))

                }).FirstOrDefault(x => x.Slug == slug);
            if (course == null) return null;

         

            #region Teacher

            if (course.TeacherId.HasValue)
            {
                var teacher = _account.Teachers.Include(x => x.Account).FirstOrDefault(x => x.Id == course.TeacherId);
                course.TeacherBio = teacher?.Bio;
                course.TeacherName = teacher?.Account.FirstName + " " + teacher?.Account.LastName;
                course.TeacherResume = teacher?.Resumes;
                course.TeacherSkills = teacher?.Skills;
                course.TeacherAvatar = teacher?.Account.Avatar;
                //barrase kon k en rahe dorst ast ya na?
                course.CourseTeacher = _context.Courses.Where(x => x.LanguageId == langId).Where(x => x.TeacherId == teacher.Id)
                    .Select(x => new { x.Name, x.Slug })
                    .Select(x => new CourseQueryModel { Name = x.Name, Slug = x.Slug }).ToList();
                course.CourseTeacherCount = course.CourseTeacher.Count;
            }
            #endregion

            #region Comment

            var comment = _comment.Comments
                .OrderByDescending(x => x.CreationDate).Where(x => x.Type == ThisType.Course).Where(x => x.IsConfirmed)
                .Where(x => x.OwnerRecordId == course.Id)
                .Select(x => new CommentQueryModel
                {
                    Id=x.Id,
                    Title = x.Title,
                    Name = x.Name,
                    Email = x.Email,
                    Message = x.Message,
                    Picture = x.Picture,
                    CreateDateTime = x.CreationDate,
                }).AsNoTracking().ToList();

            course.Comments = comment;
            #endregion


            //Keywords
            if (string.IsNullOrWhiteSpace(course.KeyWords)) return course;
            var keywords = new CourseQueryModel
            {
                Keywords = course.KeyWords.Split("-").ToList()
            };
            course.Keywords = keywords.Keywords;

            return course;
        }

        public bool UserInCourse(string email, long courseId)
        {
            var userId = _account.Accounts.SingleOrDefault(x => x.Email == email)?.Id;
            return _context.UserCourses.Any(x => x.AccountId == userId && x.CourseId == courseId);
        }

        public CourseEpisode GetEpisodeFile(long episodeId)
        {
            return _context.CourseEpisodes.FirstOrDefault(x => x.Id == episodeId);
        }

        public List<Account> GetAllUsers()
        {
            return _account.Accounts.AsNoTracking().ToList();
        }

        public double GetTotalMinutesEpisodeVideos()
        {
            return _context.CourseEpisodes.AsNoTracking().ToList().Sum(c => Convert.ToInt32(c.Time.Minutes));
        }

        public List<Article> GetAllArticle()
        {
            return _article.Articles.AsNoTracking().ToList();
        }

        public List<Teacher> GetAllTeacher()
        {
            return _account.Teachers.AsNoTracking().ToList();
        }
        public List<LastCourseFooter> FooterCourse()
        {
            var langId = _languageQuery.GetLanguageId(CultureInfo.CurrentCulture.Name);
            return _context.Courses.Where(x => x.LanguageId == langId).OrderByDescending(x => x.CreationDate).Take(8).Select(x => new LastCourseFooter()
            {
                CourseName = x.Name,
                CourseSlug = x.Slug
            }).ToList();
        }

        public List<LastCourseGroupFooter> FooterCourseGroup()
        {
            return _context.CourseGroups.Where(x=>!x.IsRemove).OrderByDescending(x => x.CreationDate).Take(8).Select(x => new { x.Title, x.Id }).Select(x => new LastCourseGroupFooter() { Title = x.Title, Id = x.Id })
                .ToList();
        }

        public List<UserCourseViewModel> GetUserCourseBy(string email)
        {
            var userId = _accountRepository.GetUserIdBy(email);
            var userCourse = _context.UserCourses.Where(x => x.AccountId == userId).Select(x =>
                new UserCourseViewModel
                {
                    AccountId = x.AccountId,
                    CourseId = x.CourseId
                }).ToList();

            foreach (var item in userCourse)
            {
                var langId = _languageQuery.GetLanguageId(CultureInfo.CurrentCulture.Name);
                var course = _context.Courses.Find(item.CourseId);
                item.CourseName = course.Name;
                item.CourseSlug = course.Slug;
                item.CourseImg = course.Picture;
                item.TeacherName = MapTeacher(course.TeacherId);
            }

            return userCourse;
        }

        public List<UserCourseViewModel> GetUserCourseBy(int courseId)
        {
            var userCourse = _context.UserCourses.Where(x => x.CourseId == courseId).Select(x =>
                new UserCourseViewModel
                {
                    AccountId = x.AccountId,
                    CourseId = x.CourseId
                }).ToList();
            return userCourse;
        }

        public List<CourseViewModel> AutoCompleteSearch(string search)
        {
            var langId = _languageQuery.GetLanguageId(CultureInfo.CurrentCulture.Name);
            return _context.Courses.Where(x => x.LanguageId == langId).Select(x => new { x.Name, x.Slug }).Where(x => x.Name.Contains(search)).AsNoTracking().Take(6).Select(x => new CourseViewModel()
            {
                Name = x.Name,
                Slug = x.Slug
            }).ToList();
        }

        #region Mapping Single Course

        private static List<UserCourseViewModel> MapUserCourse(IEnumerable<UserCourse> userCourses)
        {
            return userCourses.Select(x => new UserCourseViewModel
            {
                CourseId = x.CourseId,
                AccountId = x.AccountId
            }).ToList();
        }


        private void MapChildren(CommentQueryModel parent)
        {
            var subComment = _comment.Comments
                .Where(x => x.Type == 1).Where(x => x.ParentId == parent.Id)
                .Where(x => x.IsConfirmed)
                .Select(x => new CommentQueryModel
                {
                    Name = x.Name,
                    Email = x.Email,
                    Message = x.Message,
                    OwnerRecordId = x.OwnerRecordId,
                    Id = x.Id,
                    Picture = x.Picture,
                    ParentId = x.ParentId,
                    CreateDateTime = x.CreationDate,
                    ParentName = x.Parent.Name,
                    CreationDate = x.CreationDate.ToFarsi()
                }).AsNoTracking().ToList();

            foreach (var item in subComment)
            {
                MapChildren(item);
                parent.SubComment.Add(item);
            }
        }

        private static List<CourseEpisodeViewModel> MapEpisodeCourse(IEnumerable<CourseEpisode> courseEpisodes)
        {
            return courseEpisodes.Select(x => new CourseEpisodeViewModel
            {
                FileName = x.FileName,
                Time = x.Time,
                Title = x.Title,
                IsFree = x.IsFree,
                CourseId = x.CourseId,
                Id = x.Id
            }).ToList();
        }

        #endregion
    }
}