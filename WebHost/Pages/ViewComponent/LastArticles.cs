using Afg.Azad.UnQuery.Contract.Article;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.Pages.ViewComponent
{
    public class LastArticles: Microsoft.AspNetCore.Mvc.ViewComponent
        
    {
        private readonly IArticleQuery _article;

        public LastArticles(IArticleQuery article)
        {
            _article = article;
        }

        public IViewComponentResult Invoke()
        {
            var article = _article.LatestArticle();
            return View("Default", article);
        }
    }
}
