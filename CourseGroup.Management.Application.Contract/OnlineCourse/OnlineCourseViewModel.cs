using System;

namespace Shop.Management.Application.Contract.OnlineCourse;

public class OnlineCourseViewModel
{
    public long? CourseId { get;  set; }
    public string Url { get;  set; }
    public string Title { get;  set; }
    public TimeSpan Time { get;  set; }
    public string Description { get;  set; }
    public long Id { get; set; }
    public DateTime CreationDate { get; set; }
}