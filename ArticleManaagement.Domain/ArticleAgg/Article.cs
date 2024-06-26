using System;
using System.Collections.Generic;
using System.Linq;
using _0_FrameWork.Domain;
using _0_FrameWork.Domain.Infrastructure;
using BlogManagement.Domain.ArticleCategoryAgg;

namespace BlogManagement.Domain.ArticleAgg
{
    public class Article : EntityBase
    {
        public Article()
        {
            
        }

        public Article(List<ArticlePictures> pictures)
        {
            ArticlePictures=pictures;
            
        }
        public Article(string title, string description, string picture, string pictureTitle, string pictureAtl,
            string slug, string keywords, string canonicalAddress, DateTime? publishDate, long categoryId,
            string metaDescription, string shortDescription, int showOrder, bool isPublish, long bloggerId, string description2)
        {
            Title = title;
            Description = description;
            Picture = picture;
            PictureTitle = pictureTitle;
            PictureAtl = pictureAtl;
            Slug = slug;
            Keywords = keywords;
            CanonicalAddress = canonicalAddress;
            PublishDate = publishDate;
            CategoryId = categoryId;
            MetaDescription = metaDescription;
            ShortDescription = shortDescription;
            ShowOrder = showOrder;
            IsPublish = isPublish;
            BloggerId = bloggerId;
            Description2 = description2;

        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Description2 { get; private set; }
        public string ShortDescription { get; private set; }
        public int ShowOrder { get; private set; }
        public string Picture { get; private set; }
        public string PictureTitle { get; private set; }
        public string PictureAtl { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public long BloggerId { get; private set; }
        public bool IsPublish { get; private set; }
        public DateTime? PublishDate { get; private set; }
        public long CategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }
        public List<ArticlePictures> ArticlePictures { get; set; }

        public void Edit(string title, string description, string picture, string pictureTitle, string pictureAtl,
            string slug, string keywords, string canonicalAddress, DateTime? publishDate, long categoryId,
            string metaDescription, string shortDescription, int showOrder, bool isPublish, long bloggerId,string description2)
        {
            Title = title;
            Description = description;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureTitle = pictureTitle;
            PictureAtl = pictureAtl;
            Slug = slug;
            Keywords = keywords;
            CanonicalAddress = canonicalAddress;
            PublishDate = publishDate;
            CategoryId = categoryId;
            MetaDescription = metaDescription;
            ShortDescription = shortDescription;
            ShowOrder = showOrder;
            IsPublish = isPublish;
            BloggerId = bloggerId;
            Description2 = description2;
        }
    }


    public class ArticlePictures : ValueObject
    {
        public string Picture { get; set; }
        public int Id { get; set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Picture;
        }
    }
}