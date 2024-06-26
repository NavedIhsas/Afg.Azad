using _0_FrameWork.Domain;
using ShopManagement.Domain.CourseAgg;

namespace ShopManagement.Domain.UserCoursesAgg
{
    public class UserCourse : EntityBase
    {
        public UserCourse(long accountId, long courseId, bool status=true)
        {
            AccountId = accountId;
            CourseId = courseId;
            Status = status;
        }
        public long AccountId { get; set; }
        public long CourseId { get; set; }
        public bool Status { get; set; }
        public Course Course { get; set; }
    }


}