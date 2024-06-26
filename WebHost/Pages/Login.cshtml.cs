using _0_FrameWork.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.Account.Agg;
using AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Pages
{
    [IgnoreAntiforgeryToken]
    [ValidateReCaptcha(ErrorMessage = ApplicationMessage.ConfirmNotRobot)]
    public class LoginModel(IConfiguration configuration, HttpClient httpClient,IAccountApplication account,IAuthHelper authHelper,IAccountRepository accountRepository) : PageModel
    {
        [BindProperty]
        public LoginViewModel Login { get; set; }

        [BindProperty]
        public RegisterUserViewModel Register { get; set; }
        [ViewData]
        public string Message { get; set; }
        [ViewData] public string Success { get; set; }

        [ViewData]
        public string ReturnUrl { get; set; }
       
        public void OnGet(string returnUrl = "/", string message = "")
        {
            if (message == "confirmEmail")
            {
                ViewData["Success"] = true;
                Message = "Your email has been successfully confirmed.";
            }
            else
            {
                Message = message;
                ReturnUrl = returnUrl;
            }
            
        }

        public async Task<IActionResult> OnPostRegisterAsync(string returnUrl = "/")
        {
            var register = await account.Create(Register);
            if (!register.IsSucceeded)
            {
                ReturnUrl = returnUrl;
                return new JsonResult(register);
            }
            ViewData["IsSuccess"] = true;
            return new JsonResult(register);

            if (string.IsNullOrWhiteSpace(returnUrl)) return RedirectToPage("/");
            var uri = new Uri(authHelper.GetCurrentDomainUrl() + returnUrl);
            return Redirect(uri.AbsoluteUri);

        }

        //Logout
        public IActionResult OnGetLogout()
        {
            account.Logout();
            return RedirectToPage("/Index");
        }


        //Confirm email
        public IActionResult OnGetConfirmEmail(string id)
        {
            var user = accountRepository.EmailConfirm(id);
            //if (user == false) return NotFound();
            return RedirectToAction("",new {Message="confirmEmail"});
        }


       /// <summary>
       /// forget password
       /// </summary>
       /// <returns></returns>
        public IActionResult OnGetForgotPassword()
        {
            return Partial("ForgotPassword", new ForgotPasswordViewModel());
        }


        public async Task<IActionResult> OnPostForgotPassword(ForgotPasswordViewModel command)
        {
            var user = await account.ForgotPassword(command);
            return new JsonResult(user);
        }


        //reset password
        public IActionResult OnGetResetPassword(string id)
        {
            var user = accountRepository.GetUserByActiveCode(id);
            if (user == null) return NotFound();
            return Partial("ResetPassword", new ResetPasswordViewModel() { ActiveCode = id });
        }
        public IActionResult OnPostResetPassword(ResetPasswordViewModel command)
        {
            var user = account.ResetPassword(command);
            return new JsonResult(user.Result);
        }


       

        public IActionResult OnPost(string returnUrl = "/")
        {
            var recaptcha = ModelState["Recaptcha"];
            if (recaptcha is { ValidationState: ModelValidationState.Invalid })
            {
                ViewData["RobotLogin"] = recaptcha.Errors.FirstOrDefault()?.ErrorMessage;
                return Page();
            }

            var user = account.Login(Login);
            if (!user.IsSucceeded)
            {
                ReturnUrl = returnUrl;
                ViewData["errorMessage"] = user.Message;
                return Page();
            }
            var uri = new Uri(authHelper.GetCurrentDomainUrl()+ returnUrl);
            return Redirect(uri.AbsoluteUri);
           
        }


        public class reCaptchaResponse
        {
            public bool Success { get; set; }
            public string[] ErrorCodes { get; set; }
        }
    }
}