using System;

namespace BlogManagement.Application.Contract.News
{
    public class NewsViewModel
    {
        public string Title { get; set; }
        public string Picture { get; set; }
        public DateTime CreationDate { get; set; }
        public long Id { get; set; }
        public string ShortDescription { get; set; }
        public string Slug { get; set; }
        public long AuthorId { get; set; }
        public string ThumpPic { get; set; }
        public string PictureTitle { get; set; }
        public string PictureAlt { get; set; }
        public string AuthorName { get; set; }
    }
}