using CommentManagement.Application.Contract.HomePhoto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Areas.Administration.Pages.Slider
{
    public class GalleryModel : PageModel
    {
        private readonly ISliderApplication _application;

        public List<SliderViewModel> List;

        public GalleryModel(ISliderApplication application)
        {
            _application = application;
        }

        public void OnGet()
        {
          List= _application.GetPhotos();
        }

        public JsonResult OnPost(long slideId)
        {
            return new JsonResult(_application.RemoveSlides(slideId));
        }
    }
}
