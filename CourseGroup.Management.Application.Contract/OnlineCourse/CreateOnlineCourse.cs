using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_FrameWork.Application;
using Shop.Management.Application.Contract.Course;

namespace Shop.Management.Application.Contract.OnlineCourse
{
    public class CreateOnlineCourse
    {
        public long? CourseId { get;  set; }
        [Required,Url(ErrorMessage = Validate.Url),MaxLength(500,ErrorMessage = Validate.MaxLength)]
        public string Url { get;  set; }

        [Required,MaxLength(100,ErrorMessage = Validate.MaxLength)]
        public string Title { get;  set; }
        public TimeSpan Time { get;  set; }
        public string Description { get;  set; }
        public bool SendEmail { get;  set; }
        public DateTime CreationDate { get; set; }
        public List<CourseViewModel> CoursesSelectList { get; set; }
    }
}
