using System.Collections.Generic;
using _0_FrameWork.Application;

namespace Shop.Management.Application.Contract.OnlineCourse;

public interface IOnlineCourseApplication
{
    OperationResult Create(CreateOnlineCourse command);
    EditOnlineCourse GetDetails(long onlineCourseId);
    OperationResult Edit(EditOnlineCourse command);
    List<OnlineCourseViewModel> List();
}