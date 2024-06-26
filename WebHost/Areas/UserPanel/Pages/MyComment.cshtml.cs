using Afg.Azad.UnQuery.Contract.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Areas.UserPanel.Pages
{
    [Authorize]
    public class MyCommentModel : PageModel
    {
        private readonly ICommentQuery _comment;

        public MyCommentModel(ICommentQuery comment)
        {
            _comment = comment;
        }

        public List<CommentModelForUserPanel> List;
        public void OnGet()
        {
            List = _comment.GetUserComment(User.Identity.Name);
        }

    }
}