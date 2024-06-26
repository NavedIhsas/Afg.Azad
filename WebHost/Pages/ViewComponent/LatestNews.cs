using BlogManagement.Application.Contract.News;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.Pages.ViewComponent
{
    public class LatestNews:Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly INewsApplication _news;

        public LatestNews(INewsApplication news)
        {
            _news = news;
        }

        public IViewComponentResult Invoke()
        {
           var news= _news.GetLatestNews();
            return View("Default",news);
        }
    }
}
