using _0_FrameWork.Domain;
using ShopManagement.Domain.CourseAgg;
using System;

namespace ShopManagement.Domain.OnlineCourse
{
    public class OnlineCourse:EntityBase
    {
        public OnlineCourse(long? courseId, string url, string title, TimeSpan time, string description)
        {
            CourseId = courseId;
            Url = url;
            Title = title;
            Time = time;
            Description = description;
        } 
        public void Edit(long? courseId, string url, string title, TimeSpan time, string description)
        {
            CourseId = courseId;
            Url = url;
            Title = title;
            Time = time;
            Description = description;
        }
        public long? CourseId { get; private set; }
        public string Url { get; private set; }
        public string Title { get; private set; }
        public TimeSpan Time { get; private set; }
        public string Description { get; private set; }
        public Course Course { get;private set; }
    }
}
