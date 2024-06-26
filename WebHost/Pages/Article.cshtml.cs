using System.Collections.Generic;
using _0_FrameWork.Application;
using AccountManagement.Domain.Account.Agg;
using Afg.Azad.UnQuery.Contract.Article;
using Afg.Azad.UnQuery.Contract.ArticleCategory;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Domain.CourseCommentAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Pages
{
    public class ArticleModel : PageModel
    {
        private readonly IAccountRepository _account;
        private readonly IArticleQuery _article;
        private readonly IAuthHelper _authHelper;
        private readonly IArticleCategoryQuery _category;
        private readonly ICommentApplication _comment;
        private readonly ICommentRepository _commentRepository;
        public Account Account;

        public SinglePageArticleQueryModel Article;
        public List<ArticleCategoryQueryModel> Categories;
        public CreateCommentViewModel Command;
        public ArticleModel(IArticleQuery article, ICommentApplication comment, IAuthHelper authHelper,
            ICommentRepository commentRepository, IAccountRepository account, IArticleCategoryQuery category)
        {
            _article = article;
            _comment = comment;
            _authHelper = authHelper;
            _commentRepository = commentRepository;
            _account = account;
            _category = category;
        }

        public void OnGet(string id)
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            Article = _article.GetSingleArticleBy(id, ipAddress);
            Categories = _category.GetAll();
        }

        public IActionResult OnPost(CreateCommentViewModel command)
        {
            command.Type = ThisType.Article;
            if (_authHelper.IsAuthenticated())
            {
                var user = _authHelper.CurrentAccountInfo();
                Account = _account.GetUserBy(user.Email);

                var createComment = new Comment(user.FirstName + " " + user.LastName, user.Email, command.Message,
                    command.OwnerRecordId, command.Type, command.ParentId, "", command.Title);

                _commentRepository.Create(createComment);
                _commentRepository.SaveChanges();
                return new JsonResult(true);

            }

            var result = _comment.Create(command);
            return result.IsSucceeded ? new JsonResult(true) : new JsonResult(result);
        }
    }
}