using System.Collections.Generic;
using System.Linq;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Application.Contract.OnlineCourse;
using ShopManagement.Domain.OnlineCourse;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class OnlineCourseRepository:RepositoryBase<long,OnlineCourse>,IOnlineCourseRepository
    {
        private readonly ShopContext _context;

        public OnlineCourseRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditOnlineCourse GetDetails(long onlineCourseId)
        {
           return _context.OnlineCourses.Select(x => new EditOnlineCourse()
            {
                Url = x.Url,
                CourseId = x.CourseId,
                Time = x.Time,
                Title = x.Title,
                Description = x.Description,
                Id = x.Id,
                CreationDate = x.CreationDate,
            }).FirstOrDefault(x=>x.Id== onlineCourseId);
        }

        public List<OnlineCourseViewModel> List()
        {
            return _context.OnlineCourses.Select(x => new OnlineCourseViewModel()
            {
                Url = x.Url,
                CourseId = x.CourseId,
                Time = x.Time,
                Title = x.Title,
                Description = x.Description,
                Id = x.Id,
                CreationDate = x.CreationDate,
            }).AsNoTracking().ToList();
        }
    }
}
