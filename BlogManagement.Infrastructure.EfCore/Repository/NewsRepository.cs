using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Domain;
using _0_FrameWork.Domain.Infrastructure;
using AccountManagement.Domain.Account.Agg;
using BlogManagement.Application.Contract.News;
using BlogManagement.Domain.NewsAgg;
using BlogManagement.Infrastructure.ShopAcl.Lang;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EfCore.Repository
{
    public class NewsRepository : RepositoryBase<long, News>, INewsRepository
    {
        private readonly BlogContext _context;
        private readonly IAccountRepository _accountRepository;
        private readonly ILanguage _lang;
        public NewsRepository(BlogContext context, IAccountRepository accountRepository, ILanguage lang) : base(context)
        {
            _context = context;
            _accountRepository = accountRepository;
            _lang = lang;
        }

        public EditNews GetDetailsNews(long id)
        {
            return _context.Newses.Select(x => new EditNews
            {
                Id = x.Id,
                CanonicalAddress = x.CanonicalAddress,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                Title = x.Title,
                AuthorId = x.AuthorId,
            }).FirstOrDefault(x => x.Id == id);
        }

        public News GetNewsBy(long id)
        {
            return _context.Newses.Find(id);
        }

        public List<NewsViewModel> GetNews()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var longId = _lang.GetLanguageId(culture);
            return _context.Newses.Where(x=>x.LanguageId==longId).Select(x => new NewsViewModel()
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
        }

        public List<NewsViewModel> Search(NewsSearchModel searchModel)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var longId = _lang.GetLanguageId(culture);

            var query = _context.Newses.Where(x => x.LanguageId == longId).Select(x => new NewsViewModel
            {
                Id = x.Id,
                Picture = x.Picture2,
                CreationDate = x.CreationDate,
                ShortDescription = x.ShortDescription.Substring(0, Math.Min(x.ShortDescription.Length, 50)) + " ...",
                Title = x.Title,
                Slug = x.Slug,
                AuthorId = x.AuthorId,
            }).AsNoTracking().ToList();
            foreach (var user in query)
            {
                var account = _accountRepository.GetUserBy(user.AuthorId);
                user.AuthorName = account.FirstName + account.LastName;
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title)).ToList();

            return query.OrderByDescending(x => x.Id).ToList();
        }

        public List<NewsViewModel> SelectList()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var longId = _lang.GetLanguageId(culture);

            return _context.Newses.Select(x => new NewsViewModel()
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
        }

        public List<NewsViewModel> GetLatestNews()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var longId = _lang.GetLanguageId(culture);

            var news = _context.Newses.Where(x => x.LanguageId == longId).OrderByDescending(x => x.CreationDate).Include(x=>x.NewsPictures).Take(5).AsNoTracking()
                .Select(x => new NewsViewModel()
                {
                    ThumpPic = x.NewsPictures.OrderByDescending(y=>y.Picture).LastOrDefault().Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    CreationDate = x.CreationDate,
                    Picture = x.Picture2,
                    ShortDescription = x.ShortDescription,
                    Slug = x.Slug,
                    Title = x.Title
                }).ToList();
            return news;
        }
    }
}
