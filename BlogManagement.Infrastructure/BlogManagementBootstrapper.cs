using _0_FrameWork.Domain.Infrastructure;
using BlogManagement.Application;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastructure.EfCore;
using BlogManagement.Infrastructure.EfCore.Repository;
using BlogManagement.Infrastructure.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Afg.Azad.UnQuery.Contract.Article;
using Afg.Azad.UnQuery.Contract.ArticleCategory;
using Afg.Azad.UnQuery.Query;
using BlogManagement.Application.Contract.News;
using BlogManagement.Domain.NewsAgg;
using BlogManagement.Infrastructure.ShopAcl.Lang;

namespace BlogManagement.Infrastructure
{
    public class BlogManagementBootstrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddScoped<IArticleCategoryRepository, ArticleCategoryRepository>();
            service.AddScoped<IArticleCategoryApplication, ArticleCategoryApplication>();

            service.AddScoped<IArticleRepository, ArticleRepository>();
            service.AddScoped<IArticleApplication, ArticleApplication>();

            service.AddScoped<IArticleQuery, ArticleQuery>();
            service.AddScoped<IArticleCategoryQuery, ArticleCategoryQuery>();

            service.AddScoped<IPermissionExposer, BlogPermissionExposer>();
            service.AddScoped<INewsApplication, NewsApplication>();
            service.AddScoped<INewsRepository, NewsRepository>();
            service.AddScoped<INewsQuery, NewsQuery>();
            service.AddScoped<ILanguage, Language>();

            service.AddDbContext<BlogContext>(option => { option.UseSqlServer(connectionString); });
        }
    }
}