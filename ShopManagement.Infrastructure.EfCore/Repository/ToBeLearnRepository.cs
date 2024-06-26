using System.Collections.Generic;
using System.Linq;
using _0_FrameWork.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Application.Contract.ToBeLearn;
using ShopManagement.Domain.ToBeLearn;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class ToBeLearnRepository:RepositoryBase<long,ToBeLearn>,IToBeLeanRepository
    {
        private readonly ShopContext _context;
        public ToBeLearnRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<ToBeLearnDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public EditToBeLearn GetDetails(long id)
        {
            throw new System.NotImplementedException();
        }

        public ToBeLearnDto GetToBeLearnBy(long courseId)
        {
            return new ToBeLearnDto();
        }
    }
}
