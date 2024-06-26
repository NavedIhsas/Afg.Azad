using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Domain.Infrastructure;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastructure.ShopAcl.Lang;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EfCore.Repository
{
    public class ArticleCategoryRepository : RepositoryBase<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogContext _context;
        private readonly ILanguage _lang;
        public ArticleCategoryRepository(BlogContext dbContext, BlogContext context, ILanguage lang) : base(dbContext)
        {
            _context = context;
            _lang = lang;
        }

        public EditArticleCategoryViewModel GetDetails(long id)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var longId = _lang.GetLanguageId(culture);
            return _context.ArticleCategories.Where(x=>x.LanguageId==longId).Select(x => new EditArticleCategoryViewModel
            {
                Name = x.Name,
                Id = x.Id
            }).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel search)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var longId = _lang.GetLanguageId(culture);
            var query = _context.ArticleCategories.Where(x => x.LanguageId == longId).Select(x => new ArticleCategoryViewModel
            {
                Name = x.Name,
                Id = x.Id,
                ArticleCount = x.Articles.Count,
                ShowOrder = x.ShowOrder,
                CreationDate = x.CreationDate.ToFarsi()
            }).AsNoTracking().ToList();

            if (!string.IsNullOrWhiteSpace(search.Name))
                query = query.Where(x => x.Name.Contains(search.Name)).ToList();

            var orderly = query.OrderByDescending(x => x.Id).ToList();
            return orderly;
        }

        public List<ArticleCategoryViewModel> SelectList()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var longId = _lang.GetLanguageId(culture);

            return _context.ArticleCategories.Where(x => x.LanguageId == longId).Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public string GetArticleCategoryName(long articleCategoryId)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var longId = _lang.GetLanguageId(culture);

            return _context.ArticleCategories.Where(x => x.LanguageId == longId).Select(x => new { x.Name, x.Id })
                .FirstOrDefault(x => x.Id == articleCategoryId)
                ?.Name;
        }
    }
}