using _0_FrameWork.Application;
using Afg.Azad.UnQuery.Contract.Course;
using Afg.Azad.UnQuery.Contract.Quiz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHost.Pages
{
    [IgnoreAntiforgeryToken]
    [Authorize]
    public class QuizStatusModel : PageModel
    {

        private readonly IQuizQuery _quizQuery;
        private readonly ICourseQuery _courseQuery;
        private readonly IAuthHelper _authHelper;
        public QuizQueryModel Quiz;

        public QuizStatusModel(IQuizQuery quizQuery, ICourseQuery courseQuery, IAuthHelper authHelper)
        {
            _quizQuery = quizQuery;
            _courseQuery = courseQuery;
            _authHelper = authHelper;
        }

        public async Task OnGet(long id)
        {
            Quiz = await _quizQuery.GetById(id);
        }

        public IActionResult OnGetQuestions(long id)
        {
            var email = _authHelper.CurrentAccountInfo().Email;
            var result = _quizQuery.GetQuizQuestion(id);
            var inCourse = _courseQuery.UserInCourse(email, result.CourseId);
            if (!inCourse)
                return RedirectToPage("Quiz");

            return Partial("Shared/PartialViews/Questions", result);
        }

        public IActionResult OnPostSubmitQuiz(string data)
        {
            var result = _quizQuery.SubmitQuiz(data);
                 return Partial("Shared/PartialViews/QuizResult", result.Data);
        }


    }
}
