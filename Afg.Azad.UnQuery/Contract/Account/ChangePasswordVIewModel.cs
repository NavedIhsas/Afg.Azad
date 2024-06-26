using System.ComponentModel.DataAnnotations;
using _0_FrameWork.Application;

namespace Afg.Azad.UnQuery.Contract.Account
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = Validate.Required)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = Validate.Required)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = Validate.Required)]
        [Compare("NewPassword",ErrorMessage = Validate.PasswordsDoNotMatch)]
        public string ConfirmNewPassword { get; set; }
        public UserInformationQueryModel UserInformation { get; set; }
        public long Id { get; set; }


    }
}