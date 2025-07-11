using System.Collections.Generic;
using WebApplication7.model;
using System.Linq;

namespace WebApplication7.DTO
{
    public class StuCourseDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }

    public class StuCourseDetailDTO
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; } = string.Empty;
        public string? StudentLastName { get; set; }
        public int CourseId { get; set; }
        public string CourseTitle { get; set; } = string.Empty;
    }

    public class EnrollmentRequest
    {
        public int[] CourseIds { get; set; }
    }
}
