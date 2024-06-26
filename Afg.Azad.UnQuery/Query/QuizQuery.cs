using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using _0_FrameWork.Application;
using Afg.Azad.UnQuery.Contract;
using Afg.Azad.UnQuery.Contract.Quiz;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopManagement.Domain.Quiz;
using ShopManagement.Infrastructure.EfCore;

namespace Afg.Azad.UnQuery.Query
{
    public class QuizQuery : IQuizQuery
    {
        private readonly IMapper _mapper;
        private readonly ShopContext _shopContext;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IAuthHelper _authHelper;
        private readonly ILanguageQuery _languageQuery;
        public QuizQuery(IMapper mapper, ShopContext shopContext, IHttpContextAccessor contextAccessor, IAuthHelper authHelper, ILanguageQuery languageQuery)
        {
            _mapper = mapper;
            _shopContext = shopContext;
            _contextAccessor = contextAccessor;
            _authHelper = authHelper;
            _languageQuery = languageQuery;
        }
        public List<QuizQueryModel> GetAll()
        {
            var langId = _languageQuery.GetLanguageId(CultureInfo.CurrentCulture.Name);
            return _mapper.Map<List<QuizQueryModel>>(_shopContext.Quizzes.Where(x => x.LanguageId == langId).Include(x => x.Course).AsNoTracking().ToList());
        }
        public async Task<QuizQueryModel> GetById(long id)
        {
            var result = await _shopContext.Quizzes.Include(x => x.Course).SingleOrDefaultAsync(x => x.Id == id);

            if (result.OnDate.Date == DateTime.Today.Date)
            {
                if (result.OnDate.TimeOfDay > DateTime.Today.TimeOfDay && result.OnDate.TimeOfDay < result.PeriodTime)
                    result.QuizStatus = QuizStatus.InProcess;

                else if (result.OnDate.TimeOfDay > result.PeriodTime)
                    result.QuizStatus = QuizStatus.Done;

                else if (result.OnDate.TimeOfDay < DateTime.Today.TimeOfDay)
                    result.QuizStatus = QuizStatus.Wait;

            }
            else
            {
                if (result.OnDate.Date > DateTime.Today.Date)
                    result.QuizStatus = QuizStatus.Wait;

                else if (result.OnDate.Date < DateTime.Today.Date)
                    result.QuizStatus = QuizStatus.Done;
            }

            var quiz = _mapper.Map<QuizQueryModel>(result);

           
            return quiz;
        }


        public QuizQueryModel GetQuizQuestion(long quizId)
        {
            var quiz = _shopContext.Quizzes.Include(x => x.QuizQuestions).SingleOrDefault(x => x.Id == quizId);
            return _mapper.Map<QuizQueryModel>(quiz);

        }

        public OperationResult<UserResult> SubmitQuiz(string data)
        {
            var operation = new OperationResult<UserResult>();
            var userId = _authHelper.CurrentAccountInfo().AccountId;
            var cookie = GetCookie("quiz");
            var questions = JsonConvert.DeserializeObject<List<SubmitQuizDto>>(cookie);
            if (!questions.Any())
                return operation.Failed(ApplicationMessage.ServerError, new UserResult());

            var correctAnswer = 0;
            var inCorrectAnswer = 0;
            var point = 0;
            foreach (var question in questions)
            {
                if (GetUserQuiz(question.QuizId))
                    return operation.Failed(ApplicationMessage.AlreadyTakenExam, new UserResult());
                var find = _shopContext.Questions.Find(question.Id);
                if (find == null) continue;
                if (int.Parse(find.CorrectAnswer) == question.Checked)
                {
                    correctAnswer = correctAnswer + 1;
                    point = point + find.CorrectAnswerPoints;
                }
                else
                    inCorrectAnswer = inCorrectAnswer + 1;

            }

            var userResult = new UserResult(userId, questions.First().QuizId, correctAnswer, inCorrectAnswer, point);
            _shopContext.UserResults.Add(userResult);
            _shopContext.SaveChanges();
            DeleteCookies();
            var result = _shopContext.UserResults.Include(x => x.Quiz).ThenInclude(x => x.Course)
                .SingleOrDefault(x => x.Id == userResult.Id);
            return operation.Succeeded(result);
        }



        public bool GetUserQuiz(long quizId)
        {
            //var cookie = GetCookie("quiz");
            //if(cookie == null) return false;
            var userId = _authHelper.CurrentAccountInfo().AccountId;
            var count = _shopContext.UserResults.Count(x => x.QuizId == quizId && x.UserId == userId);
            return count <= 3;
        }
        public string GetCookie(string name)
        {
            _contextAccessor.HttpContext.Request.Headers.TryGetValue("Cookie", out var values);
            var cookies = values.ToString().Split(';').ToList();
            var result = cookies.Select(c => new
            {
                Key = c.Split('=')[0].Trim(),
                Value = c.Split('=')[1].Trim()
            }).ToList();
            var cookie = result.FirstOrDefault(r => r.Key == name)?.Value;
            return cookie;
        }

        private void DeleteCookies()
        {
            foreach (var cookie in _contextAccessor.HttpContext.Request.Cookies)
            {
                _contextAccessor.HttpContext.Response.Cookies.Delete(cookie.Key);
            }
        }
    }
}


public class SubmitQuizDto
{
    public long QuizId { get; set; }
    public long Id { get; set; }
    public int Checked { get; set; }
}