using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_FrameWork.Application;
using Shop.Management.Application.Contract.Course;

namespace Shop.Management.Application.Contract.Quiz
{
    public class CreateQuiz
    {
        [MaxLength(150, ErrorMessage = Validate.MaxLength)]
        public string KeyWord { get; set; }

        [MaxLength(170, ErrorMessage = Validate.MaxLength)]
        public string MetaDes { get; set; }

        [Required(ErrorMessage = Validate.Required), MaxLength(200, ErrorMessage = Validate.MaxLength)]
        public string Slug { get; set; }

        [Required(ErrorMessage = Validate.Required), MaxLength(100, ErrorMessage = Validate.MaxLength)]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = Validate.Required)]
        public long CourseId { get; set; }

        [Required(ErrorMessage = Validate.Required)]
        public string OnDate { get; set; }

        [Required(ErrorMessage = Validate.Required)]

        public TimeSpan Time { get; set; }
        public TimeSpan PeriodTime { get; set; }
        public List<CourseViewModel> SelectList { get; set; }
    }
    public class EditQuiz : CreateQuiz
    {
        public long Id { get; set; }
    }

    public interface IQuizApplication
    {
        OperationResult Create(CreateQuiz command);
        OperationResult Edit(EditQuiz command);
        EditQuiz GetDetails(long id);
        List<QuizViewModel> GetAll();
        List<QuizViewModel> SelectList();
    }
    public class QuizViewModel
    {
        public string Slug { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string CourseName { get; set; }
        public string OnDate { get; set; }
        public TimeSpan Time { get; set; }
        public TimeSpan PeriodTime { get; set; }
        public string CreationDate { get; set; }
        public string Status { get; set; }
    }

    public class CreateQuestion
    {
        [Required(ErrorMessage = Validate.Required)]
        public string QuestionName { get; set; }
        [Required(ErrorMessage = Validate.Required)]
        public string FirstOption { get; set; }
        [Required(ErrorMessage = Validate.Required)]
        public string SecondOption { get; set; }
        [Required(ErrorMessage = Validate.Required)]
        public string ThirdOption { get; set; }
        [Required(ErrorMessage = Validate.Required)]
        public string FourthOption { get; set; }
        [Required(ErrorMessage = Validate.Required)]
        public string CorrectAnswer { get; set; }
        [Required(ErrorMessage = Validate.Required)]
        public int CorrectAnswerPoints { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = Validate.Required)]
        public long QuizId { get; set; }
        public List<QuizViewModel> Quiz { get; set; }
    }

    public class EditQuestion : CreateQuestion
    {
        public long Id { get; set; }
    }

    public class QuestionViewModel
    {
        public long Id { get; set; }
        public string QuestionName { get; set; }
        public string FirstOption { get; set; }
        public string SecondOption { get; set; }
        public string ThirdOption { get; set; }
        public string FourthOption { get; set; }
        public string CorrectAnswer { get; set; }
        public int CorrectAnswerPoints { get; set; }
        public string QuizName { get; set; }
    }


    public interface IQuestionApplication
    {
        OperationResult Create(CreateQuestion command);
        OperationResult Edit(EditQuestion command);
        EditQuestion GetDetails(long id);
        List<QuestionViewModel> GetAll();
    }
}
