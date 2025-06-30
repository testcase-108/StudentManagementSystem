using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace WebApplication7.model
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public required string Title { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
