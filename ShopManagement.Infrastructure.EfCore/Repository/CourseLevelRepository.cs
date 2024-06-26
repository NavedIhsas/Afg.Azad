using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _0_FrameWork.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Application.Contract.CourseLevel;
using Shop.Management.Application.Contract.Language;
using ShopManagement.Domain.CourseLevelAgg;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class CourseLevelRepository : RepositoryBase<long, CourseLevel>, ICourseLevelRepository
    {
        private readonly ShopContext _context;
        private readonly ILanguageApplication _languageApplication;
        public CourseLevelRepository(ShopContext dbContext, ShopContext context, ILanguageApplication languageApplication) : base(dbContext)
        {
            _context = context;
            _languageApplication = languageApplication;
        }

        public EditCourseLevelViewModel GetDetails(long id)
        {
            return _context.CourseLevels.Select(x => new EditCourseLevelViewModel
            {
                Title = x.Title,
                Id = x.Id
            }).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<CourseLevelViewModel> GetAllCourseLevel()
        {
            var langId = _languageApplication.GetLanguageCulture(CultureInfo.CurrentCulture.Name);
            return _context.CourseLevels.Where(x=>x.LanguageId==langId).Select(x => new CourseLevelViewModel
            {
                Title = x.Title,
                Id = x.Id
            }).AsNoTracking().ToList();
        }

        public List<CourseLevelViewModel> SelectList()
        {
            var langId = _languageApplication.GetLanguageCulture(CultureInfo.CurrentCulture.Name);
            return _context.CourseLevels.Where(x => x.LanguageId == langId).Select(x => new CourseLevelViewModel
            {
                Title = x.Title,
                Id = x.Id
            }).AsNoTracking().ToList();
        }
    }
}