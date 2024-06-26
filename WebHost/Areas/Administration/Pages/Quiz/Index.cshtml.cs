using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Management.Application.Contract.Course;
using Shop.Management.Application.Contract.Quiz;
using ShopManagement.Application;

namespace WebHost.Areas.Administration.Pages.Quiz
{
    public class IndexModel : PageModel
    {
        private readonly IQuizApplication _quizApplication;
        private readonly ICourseApplication _courseApplication;
        private readonly IQuestionApplication _questionApplication;

        public IndexModel(IQuizApplication quizApplication, ICourseApplication courseApplication, IQuestionApplication questionApplication)
        {
            _quizApplication = quizApplication;
            _courseApplication = courseApplication;
            _questionApplication = questionApplication;
        }

        public List<QuizViewModel> List;
        [NeedPermission(PermissionPlace.ListQuiz)]
        public void OnGet()
        {
            List = _quizApplication.GetAll();
        }

        [NeedPermission(PermissionPlace.CreateQuiz)]
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateQuiz() { SelectList = _courseApplication.SelectCourses() });
        }

        public JsonResult OnPostCreate(CreateQuiz command)
        {
            return new JsonResult(_quizApplication.Create(command));
        }

        [NeedPermission(PermissionPlace.EditQuiz)]
        public IActionResult OnGetEdit(long id)
        {
            var course = _quizApplication.GetDetails(id);

            course.SelectList = _courseApplication.SelectCourses();
            return Partial("./Edit", course);

        }

        [NeedPermission(PermissionPlace.AddQuestion)]
        public IActionResult OnGetAddQuestion(long id)
        {
            return Partial("./AddQuestion", new CreateQuestion(){QuizId = id});
        }

        public JsonResult OnPostAddQuestion(CreateQuestion command)
        {
            return new JsonResult(_questionApplication.Create(command));
        }



        public JsonResult OnPostEdit(EditQuiz command)
        {
            return new JsonResult(_quizApplication.Edit(command));
        }
    }
}
