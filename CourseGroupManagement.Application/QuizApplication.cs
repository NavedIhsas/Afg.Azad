using System;
using System.Collections.Generic;
using _0_Framework.Application;
using _0_FrameWork.Application;
using Shop.Management.Application.Contract.Quiz;
using ShopManagement.Domain.Quiz;

namespace ShopManagement.Application
{
    public class QuizApplication : IQuizApplication
    {
        private readonly IQuizRepository _quizRepository;

        public QuizApplication(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public OperationResult Create(CreateQuiz command)
        {
            var operation = new OperationResult();
            if (_quizRepository.IsExist(x => x.CourseId == command.CourseId && x.Name == command.Name.ToPascalCase()))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

         
            var fullDate = command.OnDate +" "+ command.Time.ToString("c");

            var georgianDateTime = fullDate.ToGeorgianFullDateTime();
            if (georgianDateTime.Date < DateTime.Now.Date)
                return operation.Failed("تاریخ برگزاری  نمیتواند کمتر از زمان فعلی باشد");

            if(command.PeriodTime <= command.Time)
                return operation.Failed("زمان پایان باید بزرگتر از زمان  برگزاری باشد");

            var quiz = new Quiz(command.Name, command.CourseId, georgianDateTime, command.PeriodTime,command.KeyWord,command.MetaDes,command.Slug);
            _quizRepository.Create(quiz);
            _quizRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditQuiz command)
        {
            var operation = new OperationResult();

            var quiz = _quizRepository.GetById(command.Id);
            if (quiz == null)
                return operation.Failed(ApplicationMessage.RecordNotFount);
            if (_quizRepository.IsExist(x => x.CourseId == command.CourseId && x.Name == command.Name.ToPascalCase() && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var fullDate = command.OnDate + " " + command.Time.ToString("c");

            var georgianDateTime = fullDate.ToGeorgianFullDateTime();

            if (georgianDateTime.Date < DateTime.Now.Date)
                return operation.Failed("تاریخ برگزاری  نمیتواند کمتر از زمان فعلی باشد");

            if (command.PeriodTime <= command.Time)
                return operation.Failed("زمان پایان باید بزرگتر از زمان برگزاری باشد");

            quiz.Edit(command.Name, command.CourseId, georgianDateTime, command.PeriodTime, command.KeyWord, command.MetaDes, command.Slug);
            _quizRepository.Update(quiz);
            _quizRepository.SaveChanges();
            return operation.Succeeded();
        }
        public EditQuiz GetDetails(long id) => _quizRepository.GetDetails(id);
        public List<QuizViewModel> GetAll() => _quizRepository.GetAll();
         public List<QuizViewModel> SelectList() => _quizRepository.SelectList();

    }
}
