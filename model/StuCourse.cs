using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace WebApplication7.model
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        
    }

}
