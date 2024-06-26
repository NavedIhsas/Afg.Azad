using System.Collections.Generic;
using _0_Framework.Application;
using _0_FrameWork.Application;
using Shop.Management.Application.Contract.Quiz;
using ShopManagement.Domain.Quiz;

namespace ShopManagement.Application;

public class QuestionApplication : IQuestionApplication
{
    private readonly IQuestionRepository _questionRepository;

    public QuestionApplication(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public OperationResult Create(CreateQuestion command)
     {
        var operation = new OperationResult();
        if (_questionRepository.IsExist(x => x.QuizId == command.QuizId && x.QuestionName == command.QuestionName.ToPascalCase()))
            return operation.Failed(ApplicationMessage.DuplicatedRecord);
        var question = new Question(command.QuestionName, command.FirstOption, command.SecondOption,
            command.ThirdOption, command.FourthOption, command.CorrectAnswer, command.CorrectAnswerPoints,
            command.QuizId);
        _questionRepository.Create(question);
        _questionRepository.SaveChanges();
        return operation.Succeeded();
    }

    public OperationResult Edit(EditQuestion command)
    {
        var operation = new OperationResult();

        var question = _questionRepository.GetById(command.Id);
        if (question == null)
            return operation.Failed(ApplicationMessage.RecordNotFount);
        if (_questionRepository.IsExist(x => x.QuizId == command.QuizId && x.QuestionName == command.QuestionName.ToPascalCase() && x.Id != command.Id))
            return operation.Failed(ApplicationMessage.DuplicatedRecord);

        question.Edit(command.QuestionName, command.FirstOption, command.SecondOption,
            command.ThirdOption, command.FourthOption, command.CorrectAnswer, command.CorrectAnswerPoints,
            command.QuizId);
        _questionRepository.Update(question);
        _questionRepository.SaveChanges();
        return operation.Succeeded();
    }
    public EditQuestion GetDetails(long id) => _questionRepository.GetDetails(id);
    public List<QuestionViewModel> GetAll() => _questionRepository.GetAll();
}