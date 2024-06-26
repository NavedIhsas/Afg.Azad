namespace Shop.Management.Application.Contract.Course
{
    public class EditCourseViewModel : CreateCourseViewModel
    {
        public string EditDescription { get; set; }
        public long Id { get; set; }
    }
}