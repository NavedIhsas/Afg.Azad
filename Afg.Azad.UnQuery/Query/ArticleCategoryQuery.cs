using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Afg.Azad.UnQuery.Contract;
using Afg.Azad.UnQuery.Contract.ArticleCategory;
using BlogManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Afg.Azad.UnQuery.Query
{
    public class ArticleCategoryQuery : IArticleCategoryQuery
    {
        private readonly BlogContext _context;
        private readonly ILanguageQuery _languageQuery;
        public ArticleCategoryQuery(BlogContext context, ILanguageQuery languageQuery)
        {
            _context = context;
            _languageQuery = languageQuery;
        }

        public List<ArticleCategoryQueryModel> GetAll()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var langId = _languageQuery.GetLanguageId(culture);

            return _context.ArticleCategories.Where(x=>x.LanguageId==langId).Select(x => new ArticleCategoryQueryModel
            {
                Name = x.Name,
                Id = x.Id,
                ArticlesCount = x.Articles.Count
            }).AsNoTracking().ToList();
        } 
        
        public List<ArticleCategoryQueryModel> GetTen()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var langId = _languageQuery.GetLanguageId(culture);

            return _context.ArticleCategories.Where(x => x.LanguageId == langId).OrderByDescending(x=>x.CreationDate).Take(10).Select(x => new ArticleCategoryQueryModel
            {
                Name = x.Name,
                Id = x.Id,
                ArticlesCount = x.Articles.Count
            }).AsNoTracking().ToList();
        }
    }
}