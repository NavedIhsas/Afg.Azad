using System;

namespace Afg.Azad.UnQuery.Contract.Forum.Answer
{
    public class AnswerQueryModel
    {
        public long QuestionId { get; set; }
        public long? AccountId { get; set; }
        public string Body { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}