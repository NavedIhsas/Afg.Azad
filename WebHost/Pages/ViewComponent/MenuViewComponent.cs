using Afg.Azad.UnQuery.Contract;
using Afg.Azad.UnQuery.Contract.ArticleCategory;
using Afg.Azad.UnQuery.Contract.CourseGroup;
using Microsoft.AspNetCore.Mvc;
using Shop.Management.Application.Contract.CourseGroup;
using ShopManagement.Domain.CourseGroupAgg;

namespace WebHost.Pages.ViewComponent
{
    public class MenuViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly ICourseGroupQuery _courseGroup;
        private readonly ICourseGroupApplication _course;
        private readonly IArticleCategoryQuery _articleCategory;
        public MenuViewComponent(ICourseGroupQuery courseGroup, ICourseGroupApplication course, IArticleCategoryQuery articleCategory)
        {
            _courseGroup = courseGroup;
            _course = course;
            _articleCategory = articleCategory;
        }
        public IViewComponentResult Invoke()
        {
            var course=_course.Search(new CourseGroupSearchModel());
                // List<ArticleCategoryMenu> blog = new List<ArticleCategoryMenu>();
           var  blog = _articleCategory.GetTen();
            var courseGroup = new MenuDot()
            {
                Courses = course.Take(5).ToList(),
                ArticleCategories=blog,

            };
            //var courseGroup = _courseGroup.GetAllMenu();
            return View("Default", courseGroup);
        }
    }
}