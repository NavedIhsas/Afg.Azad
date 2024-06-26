using System.Collections.Generic;

namespace Afg.Azad.UnQuery.Contract.Course
{
    public class CourseQuerySearchModel
    {
        public string Search { get; set; }
        public string Filter { get; set; }
        public string Course { get; set; }
        public List<long> CategoryId { get; set; }
        public List<long?> TeacherId { get; set; }
        public List<long?> LevelId { get; set; }
        public int SubGroupId { get; set; }
    }
}