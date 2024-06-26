using System.Collections.Generic;
using Afg.Azad.UnQuery.Contract.Forum.Answer;

namespace Afg.Azad.UnQuery.Contract.Forum.Question
{
    public class AnswerPagination
    {
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public List<AnswerQueryModel> Answers { get; set; }
    }
}