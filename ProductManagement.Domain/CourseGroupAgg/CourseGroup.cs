﻿using System;
using System.Collections.Generic;
using _0_FrameWork.Domain;
using ShopManagement.Domain.CourseAgg;

namespace ShopManagement.Domain.CourseGroupAgg
{
    public class CourseGroup : EntityBase
    {
        public CourseGroup(string title, string keyWords, string metaDescription, string slug, long? subGroupId,
            string picture, string pictureAlt, string pictureTitle)
        {
            Title = title;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
            SubGroupId = subGroupId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            IsRemove = false;
        }

        public CourseGroup(string title, long? subGroupId, string picture,string singlePicture)
        {
            Title = title;
            SubGroupId = subGroupId;
            if(!string.IsNullOrWhiteSpace(picture)) 
                Picture = picture;

            if (!string.IsNullOrWhiteSpace(singlePicture))
                SinglePicture = singlePicture;
        }
        public string Title { get; private set; }
        public bool IsRemove { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public string Picture { get; private set; }
        public string SinglePicture { get;private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public long? SubGroupId { get; private set; }
        public DateTimeOffset? UpdateTime { get; private set; }
        public List<Course> Courses { get; private set; }
        public CourseGroup SubGroup { get; private set; }
        public List<CourseGroup> Groups { get; set; }


        public void Edit(string title, long? subGroupId, string picture,string singlePicture)
        {
            Title = title;
            SubGroupId = subGroupId;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            if (!string.IsNullOrWhiteSpace(singlePicture))
                SinglePicture = singlePicture;
            UpdateTime = DateTimeOffset.UtcNow;
        }
        public void Edit(string title, string keyWords, string metaDescription, string slug, long? subGroupId,
            string picture, string pictureAlt, string pictureTitle)
        {
            Title = title;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
            SubGroupId = subGroupId;
            if (!string.IsNullOrEmpty(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
        }

        public void Remove()
        {
            IsRemove = true;
        }

        public void Restore()
        {
            IsRemove = false;
        }
    }
}