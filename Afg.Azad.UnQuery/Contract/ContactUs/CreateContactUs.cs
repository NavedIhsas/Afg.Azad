using System.ComponentModel.DataAnnotations;
using _0_FrameWork.Application;

namespace Afg.Azad.UnQuery.Contract.ContactUs
{
    public class CreateContactUs
    {
        [Required(ErrorMessage = Validate.Required),MaxLength(100,ErrorMessage = Validate.MaxLength)]
        public string Name { get; set; }
        [Required(ErrorMessage = Validate.Required),EmailAddress(ErrorMessage ="ایمیل معتبر نیست"),MaxLength(50,ErrorMessage = Validate.MaxLength)]
        public string Email { get; set; }
        [Required(ErrorMessage = Validate.Required),MaxLength(1000,ErrorMessage = Validate.MaxLength)]
        public string Message { get; set; }
    }
}
