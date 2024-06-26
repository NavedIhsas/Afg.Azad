using _0_FrameWork.Domain;

namespace ShopManagement.Domain.Quiz;

public class Question : EntityBase
{
    public string QuestionName { get; private set; }
    public string FirstOption { get; private set; }
    public string SecondOption { get; private set; }
    public string ThirdOption { get; private set; }
    public string FourthOption { get; private set; }
    public string CorrectAnswer { get; private set; }
    public int CorrectAnswerPoints { get; private set; }
    public long QuizId { get; private set; }
    public Quiz Quiz { get; private set; }
    public Question(string questionName, string firstOption, string secondOption, string thirdOption, string fourthOption, string correctAnswer, int correctAnswerPoints, long quizId)
    {
        QuestionName = questionName;
        FirstOption = firstOption;
        SecondOption = secondOption;
        ThirdOption = thirdOption;
        FourthOption = fourthOption;
        CorrectAnswer = correctAnswer;
        CorrectAnswerPoints = correctAnswerPoints;
        QuizId = quizId;
    }
    public void Edit(string questionName, string firstOption, string secondOption, string thirdOption, string fourthOption, string correctAnswer, int correctAnswerPoints, long quizId)
    {
        QuestionName = questionName;
        FirstOption = firstOption;
        SecondOption = secondOption;
        ThirdOption = thirdOption;
        FourthOption = fourthOption;
        CorrectAnswer = correctAnswer;
        CorrectAnswerPoints = correctAnswerPoints;
        QuizId = quizId;
    }
}