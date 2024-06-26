using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Domain.Quiz;

namespace WebHost.Pages
{
    public class QuizResultModel : PageModel
    {
        public UserResult Result;
        public void OnGet()
        {
            var result = TempData["errorsList"] as UserResult;
            Result = result;
        }
    }
}
