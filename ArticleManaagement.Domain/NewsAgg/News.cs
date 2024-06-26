using System;
using _0_FrameWork.Application;
using System.Collections.Generic;
using System.Linq;
using _0_FrameWork.Domain;
using BlogManagement.Application.Contract.News;
using _0_FrameWork.Domain.Infrastructure;
using BlogManagement.Domain.ArticleAgg;

namespace BlogManagement.Domain.NewsAgg
{
    public class News : EntityBase
    {
        public string Title { get; private set; }
        public string Description2 { get; private set; }
        public string Picture2 { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public long AuthorId { get; private set; }
        public DateTime ModifiedDate { get; private set; }
        public int AccountId { get; private set; }
        public List<NewsPictures> NewsPictures { get; set; }

        public News(string picture2)
        {
            Picture2 = picture2;
        }
        public News(string title, string shortDescription, string description, string picture, string pictureAlt,
            string pictureTitle, string slug, string keywords, string metaDescription, string canonicalAddress, long authorId, string description2, string picture2)
        {
            ModifiedDate = DateTime.Now;
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            AuthorId = authorId;
            Description2 = description2;
            Picture2 = picture2;
        }

        public void Edit(string title, string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, string slug, string keywords, string metaDescription, string canonicalAddress, long authorId, string description2, string picture2)
        {
            ModifiedDate = DateTime.Now;
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            if (!string.IsNullOrWhiteSpace(picture2))
                Picture2 = picture2;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            AuthorId = authorId;
            Description2 = description2;

        }
    }
    public class NewsPictures : ValueObject
    {
        public string Picture { get; set; }
        public int Id { get; set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Picture;
        }
    }

    public interface INewsRepository : IRepository<long, News>
    {
        EditNews GetDetailsNews(long id);
        News GetNewsBy(long id);
        List<NewsViewModel> GetNews();
        List<NewsViewModel> Search(NewsSearchModel searchModel);
        List<NewsViewModel> SelectList();

        List<NewsViewModel> GetLatestNews();
    }

}
