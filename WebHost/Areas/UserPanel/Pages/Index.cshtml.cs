using _0_FrameWork.Application;
using AccountManagement.Application.Contract.City;
using AccountManagement.Domain.Account.Agg;
using Afg.Azad.UnQuery.Contract.Account;
using Afg.Azad.UnQuery.Contract.Comment;
using Afg.Azad.UnQuery.Contract.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Shop.Management.Application.Contract.UserCourse;

namespace WebHost.Areas.UserPanel.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IAccountQuery _user;
        private readonly ICityApplication _city;
        [BindProperty] public EditProfileQueryModel Edit { get; set; }
        public List<UserCourseViewModel> UserCourse;
        public UserInformationQueryModel Information;

        [BindProperty]
        public ChangePasswordViewModel ChangePassword { get; set; }
        public IndexModel(IAccountQuery user, ICityApplication city)
        {
            _user = user;
            _city = city;
        }

        public void OnGet()
        {
            var currentUser = User.Identity?.Name;
            Edit= _user.GetDetails(currentUser);
            Edit.UserInformation = _user.UserInformation(currentUser);
            Edit.CityProvince = _city.GetProvinceCity(Edit.ProvinceId ?? 0);
            Edit.ProvinceSelectList = _user.ProvinceSelectList();
            //Information = _user.UserInformation(User.Identity?.Name);
            //UserCourse = _course.GetUserCourseBy(User.Identity?.Name);
        }

        public IActionResult OnPost(EditProfileQueryModel edit)
        {
          var result=  _user.EditProfile(Edit);
          return new JsonResult(result);
        }
        public IActionResult OnGetEdit()
        {
            var currentUser = User.Identity?.Name;
            var user = _user.GetDetails(currentUser);
            user.UserInformation = _user.UserInformation(currentUser);
            user.CityProvince =  _city.GetProvinceCity(user.ProvinceId??0);

            user.ProvinceSelectList = _user.ProvinceSelectList();
            return Partial("EditProfile", user);
        }

        public IActionResult OnPostEdit()
        {
            _user.EditProfile(Edit);
            return Redirect("/UserPanel/DashBoard");
        }
        
        public JsonResult OnGetChangeSubGroup(long id)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.AddRange(_user.GetCitiesFormProvince(id));
            return new JsonResult((new SelectList(list, "Value", "Text")));
        }

        public IActionResult OnGetGetCiy(long id)
        {
            var city = _city.GetProvinceCity(id);
            return new JsonResult(city);
        }

     

        public IActionResult OnPostChangePassword()
        {
            var password = _user.ChangePassword(User.Identity?.Name, ChangePassword);
            return new JsonResult(password);
        }
    }
}