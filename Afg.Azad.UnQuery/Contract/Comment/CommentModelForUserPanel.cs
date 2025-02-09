﻿using Afg.Azad.UnQuery.Contract.Account;

namespace Afg.Azad.UnQuery.Contract.Comment
{
    public class CommentModelForUserPanel
    {
        public string Message { get; set; }
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string CreationDate { get; set; }
        public string CourseName { get; set; }
        public long OwnerRecordId { get; set; }
        public string ArticleName { get; set; }
        public string CourseSlug { get; set; }
        public string ArticleSlug { get; set; }
        public int Type { get; set; }
        public string Title { get; set; }
        public string NewsSlug { get; set; }
        public string NewsName { get; set; }
    }
}