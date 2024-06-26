using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _0_Framework.Application;
using Afg.Azad.UnQuery.Contract;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EfCore;
using Afg.Azad.UnQuery.Contract.CourseGroup;
using Shop.Management.Application.Contract.CourseGroup;

namespace Afg.Azad.UnQuery.Query
{
    public class CourseGroupQuery : ICourseGroupQuery
    {
        private readonly ShopContext _context;
        private readonly ILanguageQuery _languageQuery;
        public CourseGroupQuery(ShopContext context, ILanguageQuery languageQuery)
        {
            _context = context;
            _languageQuery = languageQuery;
        }

        public List<CourseGroupQueryModel> GetAllCourseGroup()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var langId = _languageQuery.GetLanguageId(culture);

            return _context.CourseGroups.Where(x => x.LanguageId == langId).Where(x => !x.IsRemove).Include(x => x.SubGroup).Include(x=>x.Groups).Select(x =>
                new CourseGroupQueryModel
                {
                    Title = x.Title,
                    KeyWords = x.KeyWords,
                    MetaDescription = x.MetaDescription,
                    Slug = x.Slug,
                    SubGroupId = x.SubGroupId,
                    SubGroup = x.SubGroup.Title,
                    Id = x.Id,
                    Picture = x.Picture,
                    PictureTitle = x.PictureTitle,
                    PictureAlt = x.PictureAlt,
                    CreationDate = x.CreationDate,
                    SubGroups = x.Groups,
                    CourseCount = x.Courses.Count
                }).AsNoTracking().OrderBy(x => x.CreationDate).ToList();
        }


        public List<LatestCourseGroupViewModel> LatestCourseGroup()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var langId = _languageQuery.GetLanguageId(culture);
            return _context.CourseGroups.Where(x => x.LanguageId == langId).Where(x => !x.IsRemove && x.SubGroupId==null).OrderByDescending(x => x.CreationDate).Select(x => new LatestCourseGroupViewModel
            {
                Id=x.Id,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                Title = x.Title,
                Slug = x.Slug,
                CourseCount = x.Courses.Count
            }).AsNoTracking().ToList();
        }


        public List<LatestCourseGroupViewModel> GetSixGroup()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var langId = _languageQuery.GetLanguageId(culture);

            return _context.CourseGroups.Where(x => x.LanguageId == langId).Where(x => !x.IsRemove).Where(x => x.SubGroup == null).Select(x =>
                new LatestCourseGroupViewModel
                {
                    Title = x.Title,
                    Slug = x.Slug,
                    CourseCount = x.Courses.Count
                }).Take(6).AsNoTracking().ToList();
        }


        public List<CourseGroupQueryModel> SearchQuery(CourseGroupSearchQuery categories)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var langId = _languageQuery.GetLanguageId(culture);

            var query = _context.CourseGroups.Where(x=>x.LanguageId==langId).Select(x => new CourseGroupQueryModel
            {
                Title = x.Title,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug,
                SubGroupId = x.SubGroupId,
                Id = x.Id,
                CreationDate = x.CreationDate
            }).AsNoTracking().ToList();
            if (!string.IsNullOrWhiteSpace(categories.Title))
                query = query.Where(x => x.Title.Contains(categories.Title)).ToList();

            var orderly = query.OrderByDescending(x => x.CreationDate).ToList();
            return orderly;
        }

    }
}