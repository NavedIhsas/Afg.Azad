﻿using System;
using System.Collections.Generic;
using CommentManagement.Domain.VisitAgg;

namespace Afg.Azad.UnQuery.Contract.Forum.Question
{
    public class QuestionQueryModel
    {
        public long Id { get; set; }
        public long? AccountId { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string CourseName { get; set; }
        public long CourseId { get; set; }
        public int NumberOfVisit { get; set; }
        public string CourseSlug { get; set; }
        public int AnswerCount { get; set; }
        public AnswerPagination Pagination { get; set; }
        public DateTime CreationDate { get; set; }
    }
}