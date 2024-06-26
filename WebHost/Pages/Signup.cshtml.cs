using System.Threading.Tasks;
using _0_FrameWork.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.Account.Agg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Pages
{
    public class SignupModel : PageModel
    {
        [ViewData] public string Message { get; set; }
        [ViewData] public string Success { get; set; }
        [ViewData] public string ReturnUrl { get; set; }

        [BindProperty]
        public RegisterUserViewModel Register { get; set; }
        private readonly IAccountApplication _account;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthHelper _authHelper;

        public SignupModel(IAccountApplication account, IAccountRepository accountRepository, IAuthHelper authHelper)
        {
            _account = account;
            _accountRepository = accountRepository;
            _authHelper = authHelper;
        }

        //Register
        public IActionResult OnGet(string returnUrl="")
        {
            return RedirectToPage("/Login");
            ReturnUrl = returnUrl;
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl="/")
        {
            if (!ModelState.IsValid)
            {
                ReturnUrl = returnUrl;
                return Page();
            }
            var register = await _account.Create(Register);
            if (!register.IsSucceeded)
            {
                ReturnUrl = returnUrl;
                ViewData["ExistEmail"] = register.Message;
                return Page();
            }
            ViewData["IsSuccess"] = true;
            if (string.IsNullOrWhiteSpace(returnUrl)) return RedirectToPage("/");
            var uri = new Uri(_authHelper.GetCurrentDomainUrl() + returnUrl);
            return Redirect(uri.AbsoluteUri);

        }

        //Logout
        public IActionResult OnGetLogout()
        {
            _account.Logout();
            return RedirectToPage("/Index");
        }


        //Confirm email
        public IActionResult OnGetConfirmEmail(string id)
        {
            var user = _accountRepository.EmailConfirm(id);
            if (user == false) return NotFound();
            return Partial("SuccessEmailConfirmed");
        }


        //forgot password
        public IActionResult OnGetForgotPassword()
        {
            return Partial("ForgotPassword", new ForgotPasswordViewModel());
        }


        public async Task<IActionResult> OnPostForgotPassword(ForgotPasswordViewModel command)
        {
            var user = await _account.ForgotPassword(command);
            return new JsonResult(user);
        }


        //reset password
        public IActionResult OnGetResetPassword(string id)
        {
            var user = _accountRepository.GetUserByActiveCode(id);
            if (user == null) return NotFound();
            return Partial("ResetPassword", new ResetPasswordViewModel() { ActiveCode = id });
        }
        public IActionResult OnPostResetPassword(ResetPasswordViewModel command)
        {
            var user = _account.ResetPassword(command);
            if (!user.Result.IsSucceeded) return NotFound();
            return new JsonResult(user.Result);
        }
    }
}