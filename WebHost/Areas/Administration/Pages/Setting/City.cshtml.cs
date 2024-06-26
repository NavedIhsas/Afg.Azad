using AccountManagement.Application.Contract.City;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Areas.Administration.Pages.Setting
{
    public class CityModel : PageModel
    {
        private readonly ICityApplication _cityApplication;

        public CityModel(ICityApplication cityApplication)
        {
            _cityApplication = cityApplication;
        }

        public CreateCity City;
        public CitySearchModel SearchModel;
        public List<CityDto> List;
        public void OnGet(CitySearchModel searchModel)
        {
            List= _cityApplication.GetAllCity(searchModel);
        }
        
        public IActionResult OnGetCreate()
        {
            var city = new CreateCity()
            {
                ProvinceList = _cityApplication.GetProvince(),
            };
            return Partial("./CreateCity", city);
        }  
        public IActionResult OnPostCreate(string city,long provinceId)
        {
          var result=  _cityApplication.CreateCity(new CreateCity(){City = city,ProvinceId = provinceId});
          return new JsonResult(result);
        } 
        
        public IActionResult OnGetEdit(long id)
        {
            var city = _cityApplication.GetCityDetails(id);
            city.ProvinceList = _cityApplication.GetProvince();
            return Partial("./EditCity", city);
        }  
        public JsonResult OnPostEdit(string city, long provinceId,long id)
        {
          var result=  _cityApplication.EditCity(new EditCity() {Id = id,City = city, ProvinceId = provinceId });
          return new JsonResult(result);
        }
    }
}
