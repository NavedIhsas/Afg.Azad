﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using _0_FrameWork.Domain;
using AccountManagement.Application.Contract.City;

namespace AccountManagement.Domain.ProvinceAgg
{
   public class Province
    {
        public Province(string name,long id)
        {
            Name = name;
            Id = id;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get;private set; }
        public string Name { get; private set; }
        public List<City> Cities { get; private set; }
    }

   public class City
    {
        public City()
        {
            
        }
        public City(string name,long? provinceId)
        {
            Name = name;
            ProvinceId = provinceId;
        }
          public void Edit(string name,long? provinceId)
        {
            Name = name;
            ProvinceId = provinceId;
        }

        public City(long id, long? provinceId, string name)
        {
            Id = id;
            ProvinceId = provinceId;
            Name = name;
        }
        public long Id { get; private set; }
        public long? ProvinceId { get; private set; }
        public string Name { get; private set; }
        public Province Province { get; private set; }
        public List<Account.Agg.Account> Accounts { get; private set; }
    }

   public interface ICityRepository : IRepository<long, City>
   {
       List<CityDto> GetAllCity(CitySearchModel searchModel);
       EditCity GetCityDetails(long id);
       List<ProvinceDto> GetProvince();
       List<CityDto> GetProvinceCity(long provinceId);
   }
}
