using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Application.Contract.CourseGroup;
using Shop.Management.Application.Contract.Language;
using ShopManagement.Domain.CourseGroupAgg;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Image = SixLabors.ImageSharp.Image;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class CourseGroupRepository : RepositoryBase<long, CourseGroup>, ICourseGroupRepository
    {
        private readonly ShopContext _context;
        private string _singlePictureFileName = "";
        private readonly ILanguageApplication _languageApplication;

        public CourseGroupRepository(ShopContext dbContext, ShopContext context, ILanguageApplication languageApplication) : base(dbContext)
        {
            _context = context;
            _languageApplication = languageApplication;
        }

        public EditCourseGroupViewModel GetDetails(long id)
        {
            var getDetails = _context.CourseGroups.Where(x => x.IsRemove == false).Select(x => new EditCourseGroupViewModel
            {
                Title = x.Title,
                IsRemove = x.IsRemove,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug,
                Id = x.Id,
                PictureName = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                SubGroupId = x.SubGroupId
            }).AsNoTracking().FirstOrDefault(x => x.Id == id);
            return getDetails;
        }

        public List<CourseGroupViewModel> Search(CourseGroupSearchModel searchModel)
        {
            var langId = _languageApplication.GetLanguageCulture(CultureInfo.CurrentCulture.Name);
            var query = _context.CourseGroups.Where(x => x.LanguageId == langId)
                .Where(x => x.SubGroupId == null).Where(x => x.IsRemove == false)
                .Select(x => new CourseGroupViewModel
                {
                    Picture = x.Picture,
                    Id = x.Id,
                    Title = x.Title,
                    IsRemove = x.IsRemove,
                    CreationDate = x.CreationDate.ToFarsi(),
                    SubGroupId = x.SubGroup.Id,
                    CourseCount = 0
                }).ToList();


            foreach (var item in query)
                BindSubGroup(item);

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title)).ToList();

            var orderly = query.OrderByDescending(x => x.CreationDate).ToList();
            return orderly;
        }

        public CourseGroupViewModel MapPicture()
        {
            if (!string.IsNullOrWhiteSpace(_singlePictureFileName))
                return null;

            CourseGroupViewModel result = null;
            var filePath = "wwwroot/FileUploader/CourseGroup";
            var di = new DirectoryInfo(filePath);
            var allFiles = di.GetFiles().OrderByDescending(x => x.CreationTime).Take(10);
            foreach (var fileInfo in allFiles)
            {
                //BUG
                var path = File.OpenRead(filePath + "/" + fileInfo.Name);
                if (!path.CanRead)
                    return new CourseGroupViewModel();

                using var getSize = Image.Load(path);
               
                if (getSize.Width != 300 || getSize.Height != 350) continue;
                _singlePictureFileName = fileInfo.Name;

                result = _context.CourseGroups.OrderByDescending(x => x.CreationDate).Select(x => new CourseGroupViewModel()
                {
                    Title = x.Title,
                    Picture = x.Picture,
                    CourseCount = x.Courses.Count,
                }).LastOrDefault(x => x.Picture.Contains("CourseGroup/" + fileInfo.Name));
                break;
            }

            return result;
        }
        public List<CourseGroupViewModel> SelectList()
        {
            var langId = _languageApplication.GetLanguageCulture(CultureInfo.CurrentCulture.Name);
            var list = new List<CourseGroupViewModel>();
            foreach (var model in _context.CourseGroups.Where(x => x.LanguageId == langId).Where(x => x.IsRemove == false).Select(x => new CourseGroupViewModel { Title = x.Title, Id = x.Id }).AsNoTracking()) list.Add(model);
            return list;
        }

        public string GetSlug(long id)
        {
            return _context.CourseGroups.Where(x => x.IsRemove == false).Select(x => new { x.Slug, x.Id }).FirstOrDefault(x => x.Id == id)?.Slug;
        }

        public void BindSubGroup(CourseGroupViewModel parent)
        {
            var langId = _languageApplication.GetLanguageCulture(CultureInfo.CurrentCulture.Name);
            var sub = _context.CourseGroups.Where(x => x.IsRemove == false)
                .Include(x => x.SubGroup)
                .Where(x => x.SubGroupId == parent.Id)
                .Where(x => x.LanguageId == langId)
                .Select(x => new CourseGroupViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsRemove = x.IsRemove,
                    CreationDate = x.CreationDate.ToFarsi(),
                    SubGroupId = x.SubGroupId
                }).AsNoTracking().ToList();

            foreach (var item in sub)
            {
                BindSubGroup(item);
                parent.Sub.Add(item);
            }
        }

        public List<CourseGroupViewModel> GetAll()
        {
            var langId = _languageApplication.GetLanguageCulture(CultureInfo.CurrentCulture.Name);

            var result = _context.CourseGroups.Where(x => x.LanguageId == langId).Where
                    (x => x.SubGroupId == null || x.SubGroupId == x.Id).Where(x => !x.IsRemove).OrderByDescending(x =>x.UpdateTime).ThenByDescending(x=>x.CreationDate)
                .Where(x=>!string.IsNullOrWhiteSpace(x.Picture) || !string.IsNullOrWhiteSpace(x.SinglePicture))
                .Select(x => new { x.Id, x.Courses, x.Picture, x.Title ,x.SinglePicture}).AsNoTracking().AsEnumerable().Select(x => new CourseGroupViewModel()
                {
                    Title = x.Title,
                    Picture = x.Picture,
                    SinglePicture = x.SinglePicture ,
                    Id = x.Id,
                    CourseCount = x.Courses.Count,
                }).ToList();
            return result;
        }

        public int? CourseCount(long id)

        {
            return _context.CourseGroups.Include(x => x.Courses).FirstOrDefault(x => x.Id == id)?.Courses.Count;
        }

    }
}