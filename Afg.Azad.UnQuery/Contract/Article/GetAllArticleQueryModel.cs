﻿using System;
using System.Collections.Generic;
using AccountManagement.Domain.Account.Agg;
using BlogManagement.Application.Contract.News;

namespace Afg.Azad.UnQuery.Contract.Article
{
    public class GetAllArticleQueryModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public string PictureTitle { get; set; }
        public string PictureAtl { get; set; }
        public string ArticleCategory { get; set; }
        public long BloggerId { get; set; }
        public long CategoryId { get; set; }

        public string BloggerName { get; set; }
        public string Slug { get; set; }
        public string Keywords { get; set; }
        public List<string> KeyWords { get; set; }
        public string MetaDescription { get; set; }
        public DateTime CreationDate { get; internal set; }
        public List<Teacher> Teachers { get; set; }
        public List<NewsViewModel> News { get; set; }
        public long Id { get; internal set; }
        public List<CommentManagement.Domain.CourseCommentAgg.Comment> Comments { get; internal set; }
        public int? VisitCount { get; internal set; }
    }

    public class PaginationArticlesViewModel
    {
        public PaginationArticlesViewModel()
        {
            Articles = new List<GetAllArticleQueryModel>();
        }

        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public List<GetAllArticleQueryModel> Articles { get; set; }
    }




    public class PaginationNewsViewModel
    {
        public PaginationNewsViewModel()
        {
            News = new List<GetAllNewsQueryModel>();
        }

        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public List<GetAllNewsQueryModel> News { get; set; }
    }



    public class GetAllNewsQueryModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public string PictureTitle { get; set; }
        public string PictureAtl { get; set; }
        public string ArticleCategory { get; set; }
        public long BloggerId { get; set; }
        public string BloggerName { get; set; }
        public string Slug { get; set; }
        public string Keywords { get; set; }
        public List<string> KeyWords { get; set; }
        public string MetaDescription { get; set; }
        public DateTime CreationDate { get; internal set; }
        public List<Teacher> Teachers { get; set; }
        public long Id { get; internal set; }
        public List<CommentManagement.Domain.CourseCommentAgg.Comment> Comments { get; internal set; }
        public int? VisitCount { get; internal set; }
    }

   
}