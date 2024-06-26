

using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using AccountManagement.Domain.Account.Agg;
using BlogManagement.Application.Contract.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebHost.Areas.Administration.Pages.Blog.Article
{
    public class IndexModel : PageModel
    {
        public SelectList SelectList;
        public ArticleSearchModel SearchModel;
        public List<BlogManagement.Application.Contract.Article.ArticleViewModel> Article;

        private readonly IArticleApplication _article;
        private readonly IArticleCategoryApplication _categoryApplication;
        private readonly ITeacherRepository _teacher;
        public IndexModel(IArticleApplication article, IArticleCategoryApplication categoryApplication, ITeacherRepository teacher)
        {
            this._article = article;
            this._categoryApplication = categoryApplication;
            _teacher = teacher;
        }

        [NeedPermission(PermissionPlace.ListArticles)]
        public void OnGet(ArticleSearchModel searchModel)
        {
            SelectList = new SelectList(_categoryApplication.SelectList(), "Id", "Name");
            Article = _article.Search(searchModel);
        }

        [NeedPermission(PermissionPlace.CreateArticles)]
        public IActionResult OnGetCreate()
        {
            var course = new CreateArticleViewModel()
            {
                SelectList = _categoryApplication.SelectList(),
               BloggerSelectList = _teacher.SelectListForArticles(),
            };
            return Partial("./Create", course);
        }

        public IActionResult OnPostCreate(CreateArticleViewModel command)
        {
            _article.Create(command);
            return RedirectToPage("Index");
        }

        [NeedPermission(PermissionPlace.EditListArticles)]
        public IActionResult OnGetEdit(long id)
        {
            var course = _article.GetDetails(id);

            course.SelectList = _categoryApplication.SelectList();
            course.BloggerSelectList = _teacher.SelectListForArticles();
            return Partial("./Edit", course);

        }

        public IActionResult OnPostEdit(EditArticleViewModel command)
        {
          _article.Edit(command);
            return RedirectToPage("Index");
        }
    }
}
