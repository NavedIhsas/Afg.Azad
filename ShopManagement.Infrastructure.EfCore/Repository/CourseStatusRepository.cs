using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _0_FrameWork.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Application.Contract.CourseStatus;
using Shop.Management.Application.Contract.Language;
using ShopManagement.Domain.CourseStatusAgg;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class CourseStatusRepository : RepositoryBase<long, CourseStatus>, ICourseStatusRepository
    {
        private readonly ShopContext _context;
        private readonly ILanguageApplication _languageApplication;
        public CourseStatusRepository(ShopContext dbContext, ShopContext context, ILanguageApplication languageApplication) : base(dbContext)
        {
            _context = context;
            _languageApplication = languageApplication;
        }

        public EditCourseStatusViewModel GetDetails(long id)
        {
            return _context.CourseStatus.Select(x => new EditCourseStatusViewModel
            {
                Title = x.Title,
                Id = x.Id
            }).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<CourseStatusViewModel> GetAllCourseStatus()
        {
            var langId = _languageApplication.GetLanguageCulture(CultureInfo.CurrentCulture.Name);
            return _context.CourseStatus.Where(x=>x.LanguageId==langId).Select(x => new CourseStatusViewModel
            {
                Title = x.Title,
                Id = x.Id
            }).AsNoTracking().ToList();
        }

        public List<CourseStatusViewModel> SelectList()
        {
            var langId = _languageApplication.GetLanguageCulture(CultureInfo.CurrentCulture.Name);
            return _context.CourseStatus.Where(x => x.LanguageId == langId).Select(x => new CourseStatusViewModel
            {
                Title = x.Title,
                Id = x.Id
            }).AsNoTracking().ToList();
        }
    }
}