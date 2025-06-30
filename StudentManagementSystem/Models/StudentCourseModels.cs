using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{ 
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}

