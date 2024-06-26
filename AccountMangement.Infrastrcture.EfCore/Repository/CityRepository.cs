using System;
using System.Collections.Generic;
using System.Linq;
using _0_FrameWork.Domain.Infrastructure;
using AccountManagement.Application.Contract.City;
using AccountManagement.Domain.ProvinceAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EfCore.Repository
{
    public class CityRepository : RepositoryBase<long, City>, ICityRepository
    {
        private readonly AccountContext _context;
        public CityRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public List<CityDto> GetAllCity(CitySearchModel searchModel)
        {
            var city = _context.Cities.Include(x => x.Province).Select(x => new CityDto()
            {
                City = x.Name,
                Province = x.Province.Name,
                Id = x.Id,
            }).AsNoTracking().ToList();

            if (!string.IsNullOrWhiteSpace(searchModel.City))
                city = city.Where(x => x.City.Contains(searchModel.City)).ToList();
            return city;
        }

        public EditCity GetCityDetails(long id)
        {
            return _context.Cities.Select(x => new EditCity()
            {
                City = x.Name,
                Id = x.Id,
                ProvinceId = x.ProvinceId ?? 0
            }).SingleOrDefault(x => x.Id == id);
        }

        public List<ProvinceDto> GetProvince()
        {
            return _context.Provinces.Select(x => new ProvinceDto()
            {
                Id = x.Id,
                Name = x.Name
            }).AsNoTracking().ToList();
        }

        public List<CityDto> GetProvinceCity(long provinceId)
        {
            if (provinceId == 0)
                return new List<CityDto>();
            return _context.Cities.Where(x=>x.ProvinceId==provinceId).Select(x => new CityDto()
            {
                Id = x.Id,
                City = x.Name
            }).AsNoTracking().ToList();
        }
    }
}
