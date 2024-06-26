using _0_FrameWork.Application;
using AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Domain;
using ShopManagement.Infrastructure.EfCore;

namespace WebHost.Pages
{

    [ValidateReCaptcha(ErrorMessage = ApplicationMessage.ConfirmNotRobot)]
    public class ContactUsModel : PageModel
    {
        private readonly ShopContext _shopContext;

        public ContactUsModel(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        [BindProperty]
        public Contact Contact { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var recaptcha = ModelState["Recaptcha"];
            if (recaptcha is { ValidationState: ModelValidationState.Invalid })
            {
               var message= recaptcha.Errors.FirstOrDefault()?.ErrorMessage;
               return new JsonResult(message);
            }


            _shopContext.Contacts.Add(Contact);
            _shopContext.SaveChanges();
            return new JsonResult(true);
        }
    }
}
