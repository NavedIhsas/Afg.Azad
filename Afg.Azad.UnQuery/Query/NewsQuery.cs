using _0_FrameWork.Application;
using AccountManagement.Domain.Account.Agg;
using Afg.Azad.UnQuery.Contract.Comment;
using BlogManagement.Infrastructure.EfCore;
using CommentManagement.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _0_Framework.Application;
using Afg.Azad.UnQuery.Contract;
using Afg.Azad.UnQuery.Contract.Article;
using Microsoft.EntityFrameworkCore;

namespace Afg.Azad.UnQuery.Query
{
    public class NewsQuery : INewsQuery
    {
        private readonly CommentContext _comment;
        private readonly BlogContext _context;
        private readonly ITeacherRepository _teacher;
        private readonly ILanguageQuery _languageQuery;
        public NewsQuery(CommentContext comment, BlogContext context, ITeacherRepository teacher, ILanguageQuery languageQuery)
        {
            _comment = comment;
            _context = context;
            _teacher = teacher;
            _languageQuery = languageQuery;
        }

        public List<LatestNewsQueryModel> LatestNews()
        {
            var langId = _languageQuery.GetLanguageId(CultureInfo.CurrentCulture.Name);
            var News = _context.Newses.Where(x=>x.LanguageId==langId).OrderByDescending(x => x.CreationDate).Select(x => new
            {
                x.Picture,
                x.PictureAlt,
                x.PictureTitle,
                x.ShortDescription
                ,
                x.CreationDate,
                x.Slug,
                x.Title,
                x.Id
            }).Take(4).Select(x => new LatestNewsQueryModel
            {
                Id = x.Id,
                Title = x.Title,
                Picture = x.Picture,
                PictureAtl = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate,
                Slug = x.Slug,
            }).AsNoTracking().ToList();

            return News;
        }

        public PaginationNewsViewModel GetAllNews( int pageId = 1)
        {
            var langId = _languageQuery.GetLanguageId(CultureInfo.CurrentCulture.Name);
            var query = _context.Newses.Where(x => x.LanguageId == langId)
                .Select(x => new GetAllNewsQueryModel
                {
                    Title = x.Title,
                    Picture = x.Picture2,
                    PictureAtl = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    ShortDescription = x.ShortDescription,
                    CreationDate = x.CreationDate,
                    Slug = x.Slug,
                }).AsNoTracking().OrderByDescending(x => x.CreationDate).AsQueryable();

            //---paging---//
            const int take =9;
            var skip = (pageId - 1) * take;

            var list = new PaginationNewsViewModel
            {
                CurrentPage = pageId,
                PageCount = (int)Math.Ceiling(query.Count() / (double)take),
                News = query.Skip(skip).Take(take).ToList()
            };
            return list;
        }

        public SinglePageNewsQueryModel GetSingleNewsBy(string slug, string ipAddress)
        {
            var News = _context.Newses.Include(x => x.NewsPictures).Select(x => new SinglePageNewsQueryModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                PictureAtl = x.PictureAlt,
                Slug = x.Slug,
                CreationDate = x.CreationDate,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                CanonicalAddress = x.CanonicalAddress,
                BloggerId = x.AuthorId,
                Pictures = x.NewsPictures.OrderByDescending(i=>i.Id).Take(2).ToList(),
            }).AsNoTracking().FirstOrDefault(x => x.Slug == slug);

            if (News == null) return null;
            News.KeyWordsList = News.Keywords.Split("-").ToList();

            #region Comment

            //start-Comment//
            News.Comments = _comment.Comments.Where(x => x.Type == ThisType.News && x.ParentId == null)
                .Where(x => x.OwnerRecordId == News.Id)
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
            var blogger = _teacher.GetBloggerBy(News.BloggerId);
            if (blogger == null) return News;
            News.BloggerName = blogger.Account.FirstName;
            News.BloggerBio = blogger.Bio;
            News.BloggerResume = blogger.Resumes;
            News.BloggerSkills = blogger.Skills;
            News.BloggerPicture = blogger.Account.Avatar;
            #endregion

            return News;
        }
    }
}
