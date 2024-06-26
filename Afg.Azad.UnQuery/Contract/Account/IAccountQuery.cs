using System.Collections.Generic;
using _0_FrameWork.Application;
using Afg.Azad.UnQuery.Contract.ContactUs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Afg.Azad.UnQuery.Contract.Account
{
    public interface IAccountQuery
    {
        EditProfileQueryModel GetDetails(string email);
        OperationResult EditProfile(EditProfileQueryModel command);
        UserInformationQueryModel UserInformation(string email);
        List<ProvinceViewModel> ProvinceSelectList();
        List<CityViewModel> CitySelectList();
        List<SelectListItem> GetCitiesFormProvince(long provinceId);

        OperationResult ChangePassword(string email,ChangePasswordViewModel command);
        OperationResult RegisterCourse(UserInformationQueryModel user,long courseId);
        OperationResult ContactUs(CreateContactUs command);
    }
}