using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace WebApplication7.model
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public required string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
