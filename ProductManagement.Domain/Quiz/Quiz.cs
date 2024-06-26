using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _0_FrameWork.Domain;
using Shop.Management.Application.Contract.Quiz;
using ShopManagement.Domain.CourseAgg;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace ShopManagement.Domain.Quiz
{
    public class Quiz : EntityBase
    {
        public Quiz()
        {

        }
        public string KeyWord { get; private set; }
        public string MetaDes { get; private set; }
        public string Slug { get; private set; }
        public string Name { get; private set; }
        public long CourseId { get; private set; }
        public Course Course { get; private set; }
        public QuizStatus QuizStatus { get; set; } = QuizStatus.Wait;
        public DateTime OnDate { get; private set; }
        public TimeSpan PeriodTime { get; private set; }
        public List<Question> QuizQuestions { get; private set; } = new List<Question>();
        public List<UserResult> UserResults { get; private set; }

        public Quiz(string name, long courseId, DateTime onDate, TimeSpan periodTime, string keyword, string meta, string slug)
        {
            Name = name;
            CourseId = courseId;
            OnDate = onDate;
            PeriodTime = periodTime;
            KeyWord = keyword;
            MetaDes = meta;
            Slug = slug;
        }
        public void Edit(string name, long courseId, DateTime onDate, TimeSpan periodTime, string keyword, string meta, string slug)
        {
            Name = name;
            CourseId = courseId;
            OnDate = onDate;
            PeriodTime = periodTime;
            KeyWord = keyword;
            MetaDes = meta;
            Slug = slug;
        }
    }

    public class UserResult : EntityBase
    {
        public UserResult()
        {
            
        }
        public UserResult(long userId, long quizId, int usersCorrectAnswers, int usersWrongAnswers, int pointsEarned)
        {
            UserId = userId;
            QuizId = quizId;
            UsersCorrectAnswers = usersCorrectAnswers;
            UsersWrongAnswers = usersWrongAnswers;
            PointsEarned = pointsEarned;
        }
        public long UserId { get; private set; }
        public long QuizId { get; private set; }
        public Quiz Quiz { get; private set; }
        public int UsersCorrectAnswers { get; private set; }
        public int UsersWrongAnswers { get; private set; }
        public int PointsEarned { get; private set; }
    }

    public enum QuizStatus
    {
        [Display(Name = "To Be Done")]
        DoIt,
        [Display(Name = "Done")]
        Done,
        [Display(Name = "Not Yet Held")]
        Wait,
        [Display(Name = "Canceled")]
        Cancel,
        [Display(Name = "In Progress")]
        InProcess
    }


    public interface IQuizRepository : IRepository<long, Quiz>
    {
        EditQuiz GetDetails(long id);
        List<QuizViewModel> GetAll();
        List<QuizViewModel> SelectList();
    }
    public interface IQuestionRepository : IRepository<long, Question>
    {
        EditQuestion GetDetails(long id);
        List<QuestionViewModel> GetAll();
    }
}
