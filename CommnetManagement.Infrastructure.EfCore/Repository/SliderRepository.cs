using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using CommentManagement.Application.Contract.HomePhoto;
using CommentManagement.Domain.SliderAgg;
using Microsoft.EntityFrameworkCore;

namespace CommentManagement.Infrastructure.EfCore.Repository
{
    public class SliderRepository : RepositoryBase<long, Slider>, ISliderRepository
    {
        private readonly CommentContext _context;

        public SliderRepository(CommentContext dbContext, CommentContext context) : base(dbContext)
        {
            _context = context;
        }

        public List<SliderViewModel> GetAll()
        {
            return _context.Sliders.Where(x => x.Type == ThisType.SlideText).Select(x => new SliderViewModel
            {
                Title = x.Title,
                ShortTitle = x.ShortTitle,
                CreationDate = x.CreationDate,
                Id = x.Id
            }).AsNoTracking().OrderByDescending(x => x.CreationDate).ToList();
        }
        public List<SliderViewModel> GetPhotos()
        {
            return _context.Sliders.Where(x => x.Type == ThisType.Slide).Select(x => new SliderViewModel
            {
                CreationDate = x.CreationDate,
                PictureStringFormat = x.Picture,
                Id = x.Id
            }).AsNoTracking().OrderByDescending(x => x.CreationDate).ToList();
        }

        public SliderViewModel GetDetails(long id)
        {
            return _context.Sliders.Select(x => new SliderViewModel
            {
                PictureStringFormat = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ButtonText = x.ButtonText,
                CreationDate = x.CreationDate,
                Id = x.Id,
                Title = x.Title,
                ShortTitle = x.ShortTitle
            }).FirstOrDefault(x => x.Id == id);
        }

        public void RemoveSlides()
        {
            var remove = _context.Sliders.Where(x => x.Type == ThisType.Slide).OrderByDescending(x => x.CreationDate).Skip(4).ToList();
            _context.Sliders.RemoveRange(remove);
            _context.SaveChanges();
        }

        public OperationResult RemoveSlides(long slideId)
        {
            var result = new OperationResult();
            if (_context.Sliders.Count(x => x.Type==ThisType.Slide) <= 1)
                return result.Failed("وجود حداقل یک عکس در اسلایدر الزامی میباشد");
            var remove = _context.Sliders.Find(slideId);
            if (remove == null)
                return result.Failed("عملیات با خطا مواجه شد");
            _context.Sliders.RemoveRange(remove);
            _context.SaveChanges();
            return result.Succeeded();

        }
    }
}