using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _0_FrameWork.Application;
using Shop.Management.Application.Contract.Quiz;
using ShopManagement.Domain.Quiz;

namespace Afg.Azad.UnQuery.Contract.Quiz
{
    public class QuizQueryModel
    {
        public string Slug { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string CourseName { get; set; }
        public long CourseId { get; set; }
        public string OnDatePersian { get; set; }
        public TimeSpan Time { get; set; }
        public TimeSpan PeriodTime { get; set; }
        public string CreationDate { get; set; }
        public string Status { get; set; }
        public DateTime OnDate { get; set; }
        public List<QuestionViewModel> QuizQuestions { get; set; }
    }

    public interface IQuizQuery
    {
        List<QuizQueryModel> GetAll();
        Task<QuizQueryModel> GetById(long id);
        QuizQueryModel GetQuizQuestion(long quizId);
        OperationResult<UserResult> SubmitQuiz(string data);
        bool GetUserQuiz(long quizId);
    }
}
