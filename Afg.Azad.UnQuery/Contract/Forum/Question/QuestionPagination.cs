using System.Collections.Generic;

namespace Afg.Azad.UnQuery.Contract.Forum.Question
{
    public class QuestionPagination
    {
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public List<QuestionQueryModel> Questions { get; set; }
    }
}