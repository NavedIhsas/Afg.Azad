using System.Collections.Generic;
using _0_FrameWork.Application;
using _0_FrameWork.Domain;
using Shop.Management.Application.Contract.OnlineCourse;

namespace ShopManagement.Domain.OnlineCourse;

public interface IOnlineCourseRepository : IRepository<long, OnlineCourse>
{
    EditOnlineCourse GetDetails(long onlineCourseId);
    List<OnlineCourseViewModel> List();
}