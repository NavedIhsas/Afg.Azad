using _0_FrameWork.Application;
using Afg.Azad.UnQuery.Contract.Comment;
using Afg.Azad.UnQuery.Contract.Course;
using CommentManagement.Domain.SliderAgg;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Pages
{
    [IgnoreAntiforgeryToken]
    public class IndexModel(ICommentQuery comment, ICourseQuery course) : PageModel
    {
        public List<Slider> Slider;
        public Slider Text;
        public void OnGet()
        {
            Slider = comment.GetThreeSlider();
            Text = comment.GetTextSlide();
        }

        public JsonResult OnPostAutocompleteSearch(string prefix)
        {
            return new JsonResult(course.AutoCompleteSearch(prefix).Select(x => new { x.Name, x.Slug }));
        }


        public IActionResult OnPostSetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}