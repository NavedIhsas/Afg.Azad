using System.Collections.Generic;
using System.Linq;
using _0_FrameWork.Domain.Infrastructure;
using AccountManagement.Domain.Account.Agg;
using AccountManagement.Infrastructure.EfCore;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Application.Contract.UserCourse;
using ShopManagement.Domain.UserCoursesAgg;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class UserCourseInfoRepository : RepositoryBase<long, UserCourseInfo>, IUserCourseInfoRepository
    {
        private readonly ShopContext _context;
        private readonly AccountContext _accountContext;
        private readonly IMapper _mapper;

        public UserCourseInfoRepository(ShopContext context, IMapper mapper, AccountContext accountContext) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _accountContext = accountContext;
        }
        public List<UserCourseInfoDto> GetList(long id)
        {
            var list = _context.UserCourseInfo
                .AsNoTracking()
                .Include(userCourseInfo => userCourseInfo.UserCourse)
                .Where(x => x.UserCourse.CourseId.Equals(id))
                .ToList();

            var account = _accountContext.Accounts
                .Include(x => x.City)
                .AsNoTracking()
                .ToList();

            var join = list.Join(account,
                    arg => arg.UserCourse.AccountId,
                    ac => ac.Id,
                    ((userCourseInfo, user) =>
                        new UserCourseInfoDto()
                        {
                            FullName = user.FirstName + " " + user.LastName,
                            City = user.City.Name,
                            BirthDate = userCourseInfo.BirthDate,
                            FatherName = userCourseInfo.FatherName,
                            Mobile = userCourseInfo.Mobile,
                            Gender = userCourseInfo.Gender,
                            UpdateDate = userCourseInfo.CreationDate
                        }))
                .ToList();
            

            return join;

        }


    }
}
