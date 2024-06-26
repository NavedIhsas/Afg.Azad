using _0_FrameWork.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.City
{
    public interface ICityApplication
    {
        List<CityDto> GetAllCity(CitySearchModel searchModel);
        EditCity GetCityDetails(long id);
        OperationResult CreateCity(CreateCity command);
        OperationResult EditCity(EditCity command);
        List<ProvinceDto> GetProvince();
        List<CityDto> GetProvinceCity(long provinceId);
    }
}
