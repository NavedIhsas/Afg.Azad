using AccountManagement.Domain.Account.Agg;
using Afg.Azad.UnQuery.Contract.Article;
using Afg.Azad.UnQuery.Contract.ArticleCategory;
using BlogManagement.Application.Contract.News;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Pages
{
    public class NewsModel : PageModel
    {
        private readonly INewsQuery _news;
      
        public List<ArticleCategoryQueryModel> Category;
        public PaginationNewsViewModel List;
        public List<NewsViewModel> News;
        public SearchArticleQueryModel Search;

        public NewsModel(INewsQuery article)
        {
            _news = article;
           
        }

        public void OnGet(int pageId = 1)
        {
            List = _news.GetAllNews(pageId);
        }
    }
}
