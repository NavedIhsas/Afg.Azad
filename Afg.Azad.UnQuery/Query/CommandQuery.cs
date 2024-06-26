using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Application;
using BlogManagement.Domain.ArticleAgg;
using CommentManagement.Domain.CourseCommentAgg;
using CommentManagement.Domain.SliderAgg;
using CommentManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.CourseAgg;
using Afg.Azad.UnQuery.Contract.Comment;
using Afg.Azad.UnQuery.Contract;
using System.Globalization;
using BlogManagement.Domain.NewsAgg;

namespace Afg.Azad.UnQuery.Query
{
    public class CommandQuery : ICommentQuery
    {
        private readonly IArticleRepository _article;
        private readonly CommentContext _context;
        private readonly ICourseRepository _course;
        private readonly INewsRepository _news;
        private readonly ILanguageQuery _languageQuery;

        public CommandQuery(CommentContext context, ICourseRepository course, IArticleRepository article, ILanguageQuery languageQuery, INewsRepository news)
        {
            _context = context;
            _course = course;
            _article = article;
            _languageQuery = languageQuery;
            _news = news;
        }

        public List<CommentQueryModel> GetAllCommentCourse()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var langId = _languageQuery.GetLanguageId(culture);

            return  _context.Comments.Where(x=>x.LanguageId==langId).Where(x=>x.LanguageId==langId)
                .Include(x => x.Children).ThenInclude(x => x.Parent)
                .Where(x => x.Type == ThisType.Course).Select(x => new CommentQueryModel
                {
                    Id = x.Parent.Id,
                    Name = x.Parent.Name,
                    Message = x.Parent.Message,
                    Email = x.Parent.Email,
                    ParentId = x.Parent.ParentId,
                    ParentName = x.Parent.Parent.Name,
                    OwnerRecordId = x.Parent.OwnerRecordId,
                    SubComment = MapChildren(x.Children),
                    CreationDate = x.Parent.CreationDate.ToFarsi()
                }).AsNoTracking().ToList();
        }

        public List<Comment> GetAll()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var langId = _languageQuery.GetLanguageId(culture);

            return _context.Comments.Where(x=>x.LanguageId==langId).AsNoTracking().ToList();
        }

        public List<CommentModelForUserPanel> GetUserComment(string email)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var langId = _languageQuery.GetLanguageId(culture);

            var comment =  _context.Comments.Where(x=>x.LanguageId==langId).Where(x => x.Email == email)
                .Where(x => x.IsConfirmed).Select(x => new CommentModelForUserPanel
                {
                    Title = x.Title,
                    Message = x.Message,
                    CreationDate = x.CreationDate.ToFarsi(),
                    ParentId = x.ParentId,
                    Id = x.Id,
                    Type = x.Type,
                    OwnerRecordId = x.OwnerRecordId
                }).ToList();
            foreach (var item in comment)
                if (item.Type == ThisType.Course)
                {
                    var course = _course.GetCourseBy(item.OwnerRecordId);
                    item.CourseName = course.Name;
                    item.CourseSlug = course.Slug;
                }
                else if(item.Type==ThisType.Article)
                {
                    var article = _article.GetArticleBy(item.OwnerRecordId);
                    item.ArticleSlug = article.Slug;
                    item.ArticleName = article.Title;
                }
                else
                {
                    var news = _news.GetNewsBy(item.OwnerRecordId);
                    item.NewsName = news.Title;
                    item.NewsSlug = news.Slug;

                }

            return comment;
        }

        public OperationResult Create(CommentQueryModel command)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var langId = _languageQuery.GetLanguageId(culture);

            var operation = new OperationResult();
            var comment =  _context.Comments.Where(x=>x.LanguageId==langId).Select(x => new CommentQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Message = x.Message,
                Email = x.Email
            }).AsNoTracking();

            return operation.Succeeded("نظر شما با موفقیت ثبت شد");
        }

        public List<Slider> GetThreeSlider()
        {
               return  _context.Sliders.Where(x => x.Type == ThisType.Slide).OrderByDescending(x => x.CreationDate).Take(4).ToList();
        }
        public Slider GetTextSlide()
        {
            return _context.Sliders.Where(x => x.Type == ThisType.SlideText).OrderBy(x => x.CreationDate).LastOrDefault();
        }

        private static List<CommentQueryModel> MapChildren(IEnumerable<Comment> children)
        {
            return children.Select(x => new CommentQueryModel
            {
                Name = x.Name,
                Message = x.Message,
                Email = x.Email,
                ParentId = x.ParentId,
                ParentName = x.Parent.Name
            }).ToList();
        }
    }
}