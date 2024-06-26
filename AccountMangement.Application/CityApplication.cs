using System;
using System.Collections.Generic;
using _0_Framework.Application;
using _0_FrameWork.Application;
using AccountManagement.Application.Contract.City;
using AccountManagement.Domain.ProvinceAgg;

namespace AccountManagement.Application
{
    public class CityApplication : ICityApplication
    {
        private readonly ICityRepository _repository;

        public CityApplication(ICityRepository repository)
        {
            _repository = repository;
        }

     
        public OperationResult CreateCity(CreateCity command)
        {
            var result = new OperationResult();
            if (_repository.IsExist(x => x.Name == command.City.ToPascalCase() && x.ProvinceId == command.ProvinceId))
                return result.Failed(ApplicationMessage.DuplicatedRecord);
            var city = new City(command.City, command.ProvinceId);
            _repository.Create(city);
            _repository.SaveChanges();
            return result.Succeeded();

        }

        public OperationResult EditCity(EditCity command)
        {
            var result = new OperationResult();
            if (_repository.IsExist(x => (x.Name == command.City.ToPascalCase() && x.ProvinceId == command.ProvinceId) && x.Id !=command.Id))
                return result.Failed(ApplicationMessage.DuplicatedRecord);

            var update = _repository.GetById(command.Id);
            if (update == null) return result.Failed(ApplicationMessage.RecordNotFount);
            update.Edit(command.City,command.ProvinceId);
            _repository.Update(update);
            _repository.SaveChanges();
            return result.Succeeded();
        }

        public List<CityDto> GetAllCity(CitySearchModel searchModel)
        {
            return _repository.GetAllCity(searchModel);
        }

        public EditCity GetCityDetails(long id)
        {
            return _repository.GetCityDetails(id);
        }

       public List<ProvinceDto> GetProvince()
       {
           return _repository.GetProvince();
       }
      public List<CityDto> GetProvinceCity(long provinceId)=>_repository.GetProvinceCity(provinceId);
    }
}
