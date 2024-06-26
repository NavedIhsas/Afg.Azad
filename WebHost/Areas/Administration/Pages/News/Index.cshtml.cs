using BlogManagement.Application.Contract.News;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Areas.Administration.Pages.News
{
    public class IndexModel : PageModel
    {
        public NewsSearchModel SearchModel;
        public List<NewsViewModel> News;

        private readonly INewsApplication _service;

        public IndexModel(INewsApplication service)
        {
            _service = service;
        }

       // [NeedsPermission(PermissionPlace.ListNews)]
        public void OnGet(NewsSearchModel searchModel)
        {
            News = _service.Search(searchModel);
        }
    }
}
