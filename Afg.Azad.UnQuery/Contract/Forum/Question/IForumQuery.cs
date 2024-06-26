using System.Collections.Generic;
using Afg.Azad.UnQuery.Contract.Forum.Answer;

namespace Afg.Azad.UnQuery.Contract.Forum.Question
{
    public interface IForumQuery
    {
        long AddQuestion(AddQuestionQueryModel command);
        QuestionPagination QuestionCourse(long id, string filter, int pageId = 1);
        QuestionQueryModel ShowQuestion(long questionId, string ipAddress, int pageId = 1);
        void AddAnswer(AddAnswerQueryModel command);
        List<QuestionQueryModel> LatestQuestion(long courseId);
    }
}