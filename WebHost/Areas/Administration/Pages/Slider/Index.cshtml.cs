using System.Collections.Generic;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Application.Contract.News;
using CommentManagement.Application.Contract.HomePhoto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Management.Application.Contract.Course;

namespace WebHost.Areas.Administration.Pages.Slider
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        private readonly ISliderApplication _application;
        private readonly IArticleApplication _articles;
        private readonly ICourseApplication _course;
        private readonly INewsApplication _news;
        public List<SliderViewModel> List;

        public IndexModel(ISliderApplication application, IArticleApplication articles, ICourseApplication course, INewsApplication news)
        {
            _application = application;
            _articles = articles;
            _course = course;
            _news = news;
        }

        public void OnGet()
        {
            List = _application.GetAllList();
        }

        [NeedPermission(PermissionPlace.CreatePhotoHomePage)]
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new SliderViewModel());
        }

        public IActionResult OnGetCreateText()
        {
            var slide = new SliderViewModel()
            {
                Articles = _articles.GetSelectList()
            };
            return Partial("Slider/CreateText", new SliderViewModel());
        }


        public IActionResult OnGetSelectType(int type)
        {
            return type switch
            {
                ThisType.Article => new JsonResult(_articles.GetSelectList()),
                ThisType.Course => new JsonResult(_course.SelectCourses()),
                ThisType.News => new JsonResult(_news.SelectList()),
                _ => new JsonResult(_course.SelectCourses())
            };
        }

        [NeedPermission(PermissionPlace.CreatePhotoHomePage)]
        public IActionResult OnPostCreate(SliderViewModel command)
        {
            _application.Create(command);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostUpload(List<IFormFile> file, int type, int selectValue)
        {
            switch (type)
            {
                case ThisType.Article:
                    _articles.CreatePhoto(file, selectValue);
                    break;
                case ThisType.News:
                    _news.CreatePhoto(file, selectValue);
                    break;
                case ThisType.Slide:
                    _application.CreateSlidePhoto(file);
                    break;
            }

            return RedirectToPage();
        }


        public IActionResult OnPostCreateText(IFormFile file)
        {
            // _application.CreateSlidePhoto(file);
            return RedirectToPage();
        }
        [NeedPermission(PermissionPlace.ChangePhotoHomePage)]
        public IActionResult OnGetEdit(long id)
        {
            var home = _application.GetDetails(id);
            return Partial("./Edit", home);
        }

        [NeedPermission(PermissionPlace.ChangePhotoHomePage)]
        public IActionResult OnPostEdit(SliderViewModel command)
        {
            _application.Edit(command);
            return RedirectToPage("Index");
        }


    }
}