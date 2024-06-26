using _0_FrameWork.Application;
using BlogManagement.Application.Contract.News;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Areas.Administration.Pages.News
{
    public class CreateModel : PageModel
    {
        public CreateNews Command;

        private readonly IAuthHelper _authHelper;
        private readonly INewsApplication _service;

        public CreateModel(IAuthHelper authHelper, INewsApplication service)
        {
            _authHelper = authHelper;
            _service = service;
        }

       // [NeedsPermission(PermissionPlace.CreateNews)]
        public void OnGet()
        {
        }

        public IActionResult OnPost(CreateNews command)
        {
            if (!ModelState.IsValid) return Page();
            var userEmail = _authHelper.CurrentAccountInfo().Email;
            command.AuthorId = _authHelper.CurrentAccountInfo().AccountId;
            var result = _service.Create(command, userEmail);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");
            else return new JsonResult(result.Message);
        }
    }
}
