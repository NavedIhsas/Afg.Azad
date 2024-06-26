using System.Collections.Generic;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Application.Contract.ArticleCategory;
using CommentManagement.Application.Contract.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebHost.Areas.Administration.Pages.Comment
{
    public class IndexModel : PageModel
    {
        public SelectList SelectList;
        public SearchCommentViewModel SearchModel;
        public List<CommentViewModel> Comment;
        public bool CheckList;
        private readonly ICommentApplication _comment;

        public IndexModel(ICommentApplication comment)
        {
            _comment = comment;
        }

        [NeedPermission(PermissionPlace.ListComments)]
        public void OnGet(SearchCommentViewModel searchModel)
        {
            Comment = _comment.Search(searchModel);
           
        }

        [NeedPermission(PermissionPlace.CancelComments)]
        public IActionResult OnGetCancel(long id)
        {
            _comment.IsCancel(id);
            return RedirectToPage("Index");
        }

        [NeedPermission(PermissionPlace.ApproveComments)]
        public IActionResult OnGetConfirm(long id)
        {
            _comment.IsConfirm(id);
            return RedirectToPage("Index");
        }
    }
}
