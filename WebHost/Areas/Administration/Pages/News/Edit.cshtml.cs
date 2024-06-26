using BlogManagement.Application.Contract.News;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Areas.Administration.Pages.News
{
    public class EditModel : PageModel
    {
        public EditNews Command;

        private readonly INewsApplication _service;

        public EditModel(INewsApplication service)
        {
            _service = service;
        }


       // [NeedsPermission(PermissionPlace.EditNews)]
        public void OnGet(long id)
        {
            Command = _service.GetDetailsNews(id);
        }

       // [NeedsPermission(PermissionPlace.EditNews)]
        public IActionResult OnPost(EditNews command)
        {
            var result = _service.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}
