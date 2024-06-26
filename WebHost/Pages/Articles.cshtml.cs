using System.Collections.Generic;
using AccountManagement.Domain.Account.Agg;
using Afg.Azad.UnQuery.Contract.Article;
using Afg.Azad.UnQuery.Contract.ArticleCategory;
using BlogManagement.Application.Contract.News;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Pages
{
    public class ArticlesModel : PageModel
    {
        private readonly IArticleQuery _article;
        private readonly ITeacherRepository _blogger;
        private readonly IArticleCategoryQuery _category;
        private readonly INewsApplication _newsApplication;
        public List<Teacher> Blogger;
        public List<ArticleCategoryQueryModel> Category;
        public PaginationArticlesViewModel List;
        public List<NewsViewModel> News;
        public SearchArticleQueryModel Search;

        public ArticlesModel(IArticleQuery article, IArticleCategoryQuery category, ITeacherRepository blogger, INewsApplication newsApplication)
        {
            _article = article;
            _category = category;
            _blogger = blogger;
            _newsApplication = newsApplication;
        }

        public void OnGet(SearchArticleQueryModel search, List<long> bloggerId, List<string> categories,long category, int pageId = 1)
        {
            List = _article.GetAllArticles(search, bloggerId, categories,category, pageId);
            Category = _category.GetAll();
            News = _newsApplication.GetLatestNews();
        }
    }
}