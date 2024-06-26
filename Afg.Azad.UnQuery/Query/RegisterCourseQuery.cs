using System;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.City;
using AccountManagement.Infrastructure.EfCore;
using Afg.Azad.UnQuery.Contract.Account;
using Afg.Azad.UnQuery.Contract.Course;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EfCore;

namespace Afg.Azad.UnQuery.Query
{
    public class RegisterCourseQuery : IRegisterCourseQuery
    {
        private readonly ShopContext _context;
        private readonly AccountContext _accountContext;
        private readonly IAccountQuery _accountQuery;
        private readonly ICityApplication _cityApplication;
        private readonly IAuthHelper _authHelper;
        public RegisterCourseQuery(ShopContext context, IAccountQuery accountQuery,AccountContext accountContext, IAuthHelper authHelper, ICityApplication cityApplication)
        {
            _context = context;
            _accountQuery = accountQuery;
            _accountContext = accountContext;
            _authHelper = authHelper;
            _cityApplication = cityApplication;
        }

        public RegisterCourseQueryModel GetCourseDetails(long id)
        {


            var course = _context.Courses.Include(x => x.CourseLevel).Include(x => x.CourseGroup)
                .Include(x => x.CourseStatus)
                .Select(x => new RegisterCourseQueryModel()
                {
                    TeacherId = x.TeacherId,
                    Id = x.Id,
                    Code = x.Code,
                    Slug = x.Slug,
                    CourseLevel = x.CourseLevel.Title,
                    CourseStatus = x.CourseStatus.Title,
                    Name = x.Name,
                    Price = x.Price,
                    UpdateDate = x.UpdateDate.ToFarsi(),
                }).FirstOrDefault(x => x.Id == id);
            if (course == null)
                throw new NullReferenceException(ApplicationMessage.ServerError);

            var teacher = _accountContext.Teachers.Include(x => x.Account).Select(x => new { x.Account.FirstName, x.Account.LastName, x.Id })
                .FirstOrDefault(x => x.Id == course.TeacherId);
            if (teacher == null)
                throw new NullReferenceException(ApplicationMessage.ServerError);

            course.TeacherName = teacher.FirstName + " " + teacher.LastName;
            course.Cities = _cityApplication.GetProvinceCity(0);
            course.Province = _cityApplication.GetProvince();
            if (_authHelper.IsAuthenticated())
            {
                var email = _authHelper.CurrentAccountInfo().Email;
                course.User = _accountQuery.UserInformation(email);
            }
            else
                course.User = new UserInformationQueryModel();

            return course;
        }
    }
}
