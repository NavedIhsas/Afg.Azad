using AccountManagement.Application.Contract.Account;

namespace Shop.Management.Application.Contract.UserCourse
{
    public class UserCourseViewModel
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public long CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseSlug { get; set; }
        public string CourseImg { get; set; }
        public TeacherViewModel TeacherName { get; set; }

    }

    public class LastCourseFooter
    {
        public string CourseName { get; set; }
        public string CourseSlug { get; set; }
    }

      public class LastCourseGroupFooter
    {
        public string Title { get; set; }
        public long Id { get; set; }
    }


}