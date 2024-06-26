using Microsoft.AspNetCore.Mvc;
using Shop.Management.Application.Contract.CourseGroup;

namespace WebHost.Pages.ViewComponent;

public class CourseGroupViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly ICourseGroupApplication _course;

    public CourseGroupViewComponent(ICourseGroupApplication course)
    {
        _course = course;
    }

    public IViewComponentResult Invoke()
    {
        var course = _course.GetAll();
        return View("Defualt",course);

    }
}