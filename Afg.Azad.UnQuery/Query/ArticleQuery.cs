using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Application;
using AccountManagement.Domain.Account.Agg;
using AccountManagement.Infrastructure.EfCore;
using Afg.Azad.UnQuery.Contract;
using Afg.Azad.UnQuery.Contract.Article;
using Afg.Azad.UnQuery.Contract.Comment;
using BlogManagement.Application.Contract.News;
using BlogManagement.Infrastructure.EfCore;
using BlogManagement.Infrastructure.ShopAcl.Lang;
using CommentManagement.Domain.VisitAgg;
using CommentManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Afg.Azad.UnQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly CommentContext _comment;
        private readonly BlogContext _context;
        private readonly ITeacherRepository _teacher;
        private readonly INewsApplication _newsApplication;
        private readonly ILanguageQuery _lang;
        public ArticleQuery(BlogContext context, CommentContext comment, 
            ITeacherRepository teacher, INewsApplication newsApplication, ILanguageQuery lang)
        {
            _context = context;
            _comment = comment;
            _teacher = teacher;
            _newsApplication = newsApplication;
            _lang = lang;
        }

        public List<LatestArticleQueryModel> LatestArticle()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var langId = _lang.GetLanguageId(culture);

            var article =  _context.Articles.Where(x=>x.LanguageId==langId).Where(x=>x.LanguageId==langId).OrderByDescending(x => x.CreationDate).Where(x => x.IsPublish).Select(x=>new
            {
                x.Picture,x.PictureAtl,x.PictureTitle,x.ShortDescription
                ,x.CreationDate,x.Slug,x.Title,x.Id
            }).Take(4).Select(x => new LatestArticleQueryModel
            {
                Id=x.Id,
                Title = x.Title,
                Picture = x.Picture,
                PictureAtl = x.PictureAtl,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate,
                Slug = x.Slug,
            }).AsNoTracking().ToList();

            //foreach (var item in article)
            //{
            //    var comments = _comment.Comments.Where(x => x.OwnerRecordId == item.Id && x.Type == ThisType.Article)
            //        .ToList();

            //    item.Comments = comments;

            //    var blogger = _account.Teachers.Include(x => x.Account).FirstOrDefault(x => x.Id == item.BloggerId);
            //    if (blogger == null) continue;
            //    item.BloggerName = blogger.Account.FirstName;

            //    item.VisitCount = _visit.GetNumberOfVisit(ThisType.Article, item.Id);
            //}

            return article;
        }

        public PaginationArticlesViewModel GetAllArticles(SearchArticleQueryModel search, List<long> bloggerId,
            List<string> categories,long category, int pageId = 1)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var langId = _lang.GetLanguageId(culture);

            var query =  _context.Articles.Where(x=>x.LanguageId==langId)
                .Where(x => x.IsPublish).Include(x => x.ArticleCategory)
                .Select(x => new GetAllArticleQueryModel
                {
                    Title = x.Title,
                    Picture = x.Picture,
                    PictureAtl = x.PictureAtl,
                    PictureTitle = x.PictureTitle,
                    ShortDescription = x.ShortDescription,
                    CreationDate = x.CreationDate,
                    Slug = x.Slug,
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    BloggerId = x.BloggerId,
                    Keywords = x.Keywords,
                    ArticleCategory = x.ArticleCategory.Name,
                    MetaDescription = x.MetaDescription
                }).AsNoTracking().OrderByDescending(x => x.CreationDate).AsQueryable();


            foreach (var item in query)
            {
                item.KeyWords = item.Keywords.Split("-").ToList();
                item.News = _newsApplication.GetLatestNews();
            }

            //---search---//
            if (!string.IsNullOrEmpty(search.Title))
                query = query.Where(x =>
                        x.Title.ToLower().Contains(search.Title.ToLower().Trim()) ||
                        x.ShortDescription.ToLower().Contains(search.Title.ToLower().Trim()) ||
                        x.Keywords.ToLower().Contains(search.Title.ToLower().Trim()));
                   

          

            //filter by category
            if (categories.Count != 0)
                foreach (var group in categories)
                    query = query.Where(x => x.ArticleCategory.Contains(group));

            if (category != 0)
                query = query.Where(x => x.CategoryId.Equals(category));

            //---paging---//
            const int take =12;
            var skip = (pageId - 1) * take;

            var list = new PaginationArticlesViewModel
            {
                CurrentPage = pageId,
                PageCount = (int)Math.Ceiling(query.Count() / (double)take),
                Articles = query.Skip(skip).Take(take).ToList()
            };
            return list;
        }

        public SinglePageArticleQueryModel GetSingleArticleBy(string slug, string ipAddress)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var langId = _lang.GetLanguageId(culture);

            var article =  _context.Articles.Where(x=>x.LanguageId==langId).Include(x=>x.ArticlePictures).Include(x => x.ArticleCategory).Select(x => new SinglePageArticleQueryModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Description2 = x.Description2,
                ShortDescription = x.ShortDescription,
                ShowOrder = x.ShowOrder,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                PictureAtl = x.PictureAtl,
                Slug = x.Slug,
                CreationDate = x.CreationDate,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                CanonicalAddress = x.CanonicalAddress,
                BloggerId = x.BloggerId,
                IsPublish = x.IsPublish,
                Pictures=x.ArticlePictures.OrderByDescending(i=>i.Id).Take(2).ToList(),
                PublishDate = x.PublishDate.ToFarsi(),
                CategoryName = x.ArticleCategory.Name
            }).AsNoTracking().FirstOrDefault(x => x.Slug == slug);

            if (article == null) return null;

            #region Comment

            //start-Comment//
            article.Comments = _comment.Comments.Where(x => x.Type == ThisType.Article && x.ParentId == null)
                .Where(x => x.OwnerRecordId == article.Id)
                .OrderByDescending(x => x.CreationDate)
                .Select(x => new CommentQueryModel
                {
                    Name = x.Name,
                    Email = x.Email,
                    Message = x.Message,
                    Id = x.Id,
                    ParentName = x.Parent.Name,
                    ParentId = x.ParentId,
                    Picture = x.Picture,
                    CreateDateTime = x.CreationDate,
                    CreationDate = x.CreationDate.ToFarsi(),
                    OwnerRecordId = x.OwnerRecordId
                }).AsNoTracking().ToList();
         
            #endregion

            #region Blogger

            //start-blogger//
            var blogger = _teacher.GetBloggerBy(article.BloggerId);
            if (blogger == null) return article;
            article.BloggerName = blogger.Account.FirstName;
            article.BloggerBio = blogger.Bio;
            article.BloggerResume = blogger.Resumes;
            article.BloggerSkills = blogger.Skills;
            article.BloggerPicture = blogger.Account.Avatar;
            #endregion

            var key = new SinglePageArticleQueryModel
            {
                KeyWords = article.Keywords.Split("-").ToList()
            };
            article.KeyWords = key.KeyWords;
            return article;
        }

        private void MapChildren(CommentQueryModel parent)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var langId = _lang.GetLanguageId(culture);

            var sub = _comment.Comments.Where(x=>x.LanguageId==langId)
                .OrderByDescending(x => x.CreationDate)
                .Where(x => x.Type == ThisType.Article && x.ParentId == parent.Id)
                .Select(x => new CommentQueryModel
                {
                    Name = x.Name,
                    Email = x.Email,
                    Message = x.Message,
                    Id = x.Id,
                    ParentName = x.Parent.Name,
                    ParentId = x.ParentId,
                    Picture = x.Picture,
                    CreateDateTime = x.CreationDate,
                    CreationDate = x.CreationDate.ToFarsi(),
                    OwnerRecordId = x.OwnerRecordId
                }).ToList();

            foreach (var item in sub)
            {
                MapChildren(item);
                parent.SubComment.Add(item);
            }
        }
    }
}