using Afg.Azad.UnQuery.Contract.Quiz;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Management.Application.Contract.CourseGroup;

namespace WebHost.Pages
{
    public class QuizModel : PageModel
    {
        private readonly IQuizQuery _quizQuery;
        public QuizModel(IQuizQuery quizQuery)
        {
            _quizQuery = quizQuery;
        }

        public List<QuizQueryModel> List;
        public Task OnGet()
        {
            List = _quizQuery.GetAll();
            return Task.CompletedTask;
        }

       
    }
}
