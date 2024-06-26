using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Domain.Infrastructure;
using AccountManagement.Domain.Account.Agg;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Infrastructure.ShopAcl.Lang;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EfCore.Repository
{
    public class ArticleRepository : RepositoryBase<long, Article>, IArticleRepository
    {
        private readonly ITeacherRepository _blogger;
        private readonly BlogContext _context;
        private readonly ILanguage _lang;

        public ArticleRepository(BlogContext dbContext, BlogContext context, ITeacherRepository blogger, ILanguage lang) :
            base(dbContext)
        {
            _context = context;
            _blogger = blogger;
            _lang = lang;
        }

        public EditArticleViewModel GetDetails(long id)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var longId = _lang.GetLanguageId(culture);
            return _context.Articles.Where(x=>x.LanguageId==longId).Select(x => new EditArticleViewModel
            {
                Title = x.Title,
                Description = x.Description,
                PictureTitle = x.PictureTitle,
                PictureAtl = x.PictureAtl,
                Slug = x.Slug,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                CanonicalAddress = x.CanonicalAddress,
                PublishDate = x.PublishDate,
                Description2 = x.Description2,
                CategoryId = x.CategoryId,
                Id = x.Id,
                ShowOrder = x.ShowOrder,
                ShortDescription = x.ShortDescription,
                IsPublish = x.IsPublish,
                PictureName = x.Picture,
                BloggerId = x.BloggerId
            }).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel search)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var longId = _lang.GetLanguageId(culture);
            var query = _context.Articles.Where(x => x.LanguageId == longId).Select(x => new ArticleViewModel
            {
                Title = x.Title,
                Picture = x.Picture,
                PublishDate = x.PublishDate.ToFarsi(),
                CategoryId = x.CategoryId,
                CategoryName = x.ArticleCategory.Name,
                Id = x.Id,
                IsPublish = x.IsPublish,
                BloggerId = x.BloggerId,
                Slug = x.Slug,
                CreationDate = x.CreationDate.ToFarsi()
            }).AsNoTracking().ToList();

            foreach (var item in query)
            {
                var blogger = _blogger.GetBloggerBy(item.BloggerId);
                if (blogger == null) continue;
                item.BloggerName = blogger.Account.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(search.Title))
                query = query.Where(x => x.Title.Contains(search.Title)).ToList();

            if (search.CategoryId > 0)
                query = query.Where(x => x.CategoryId == search.CategoryId).ToList();

            var orderly = query.OrderByDescending(x => x.Id).ToList();
            return orderly;
        }

        public bool? GetPublishStatus(long articleId)
        {
            return _context.Articles.Select(x => new { x.Id, x.IsPublish }).FirstOrDefault(x => x.Id == articleId)?
                .IsPublish;
        }

        public DateTime? GetPublishDate(long articleId)
        {
            var publishDate = _context.Articles.Select(x => new { x.Id, x.PublishDate })
                .FirstOrDefault(x => x.Id == articleId)?
                .PublishDate;
            return publishDate ?? null;
        }

        public Article GetArticleBy(long articleId)
        {
            return _context.Articles.Find(articleId);
        }

        public List<ArticleViewModel> GetSelectList()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var longId = _lang.GetLanguageId(culture);

            var list=  _context.Articles.Where(x => x.LanguageId == longId).Select(x=>new{x.Id,x.Title}).Select(x=>new ArticleViewModel()
          {
              Id=x.Id,
              Title=x.Title,
          }).ToList();
          return list;
        }
    }
}