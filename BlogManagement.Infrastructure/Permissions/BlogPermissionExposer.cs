using System.Collections.Generic;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using AccountManagement.Domain.RoleAgg;

namespace BlogManagement.Infrastructure.Permissions
{
    public class BlogPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            // ReSharper disable  StringLiteralTypo
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Articles", new List<PermissionDto>
                    {
                        new(PermissionPlace.ListArticles, "لیست مقاله ها"),
                        new(PermissionPlace.SearchArticles, "جستجو"),
                        new(PermissionPlace.CreateArticles, "ایجاد مقاله"),
                        new(PermissionPlace.EditListArticles, "ویرایش مقاله")
                    }
                },
                {
                    "ArticleCategories", new List<PermissionDto>
                    {
                        new(PermissionPlace.ListArticleCategories, "لیست گرو ها"),
                        new(PermissionPlace.SearchArticleCategories, "جستجو"),
                        new(PermissionPlace.CreateArticleCategories, "ایجاد گروه"),
                        new(PermissionPlace.EditArticleCategories, "ویرایش گروه")
                    }
                },
                {
                    "News", new List<PermissionDto>
                    {
                        new(PermissionPlace.ListNews, "جستجو"),
                        new(PermissionPlace.CreateNews, "ایجاد خبر"),
                        new(PermissionPlace.EditNews, "ویرایش خبر")
                    }
                }
            };
        }
    }
}