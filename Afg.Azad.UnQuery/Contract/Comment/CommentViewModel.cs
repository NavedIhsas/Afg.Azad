using System;
using System.Collections.Generic;

namespace Afg.Azad.UnQuery.Contract.Comment
{
    public class CommentQueryModel
    {
        public CommentQueryModel()
        {
            SubComment = new List<CommentQueryModel>();
        }

        public long? AccountId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string CreationDate { get; set; }
        public DateTime CreateDateTime { get; set; }
        public long OwnerRecordId { get; set; }
        public List<CommentQueryModel> SubComment { get; set; }
        public string ParentName { get; internal set; }
        public string Picture { get; set; }
    }
}