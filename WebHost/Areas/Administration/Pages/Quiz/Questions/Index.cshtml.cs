using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Management.Application.Contract.Quiz;

namespace WebHost.Areas.Administration.Pages.Quiz.Questions
{
    public class IndexModel : PageModel
    {
        private readonly IQuestionApplication _questionApplication;
        private readonly IQuizApplication _quizApplication;
        public IndexModel(IQuestionApplication quizApplication, IQuizApplication quizApplication1)
        {
            _questionApplication = quizApplication;
            _quizApplication = quizApplication1;
        }

        public List<QuestionViewModel> List;
        public void OnGet()
        {
            List = _questionApplication.GetAll();
        }

        [NeedPermission(PermissionPlace.AddQuestion)]
        public IActionResult OnGetAddQuestion()
        {
            return Partial("./AddQuestion", new CreateQuestion() { Quiz = _quizApplication.SelectList() });
        }


        public JsonResult OnPostAddQuestion(CreateQuestion command)
        {
            return new JsonResult(_questionApplication.Create(command));
        }

        [NeedPermission(PermissionPlace.AddQuestion)]
        public IActionResult OnGetEdit(long id)
        {
            var details = _questionApplication.GetDetails(id);
            details.Quiz = _quizApplication.SelectList();
            return Partial("./Edit", details);
        }

        [NeedPermission(PermissionPlace.AddQuestion)]
        public IActionResult OnPostEdit(EditQuestion command)
        {
            var details = _questionApplication.Edit(command);
            return new JsonResult(details);
        }


    }
}
