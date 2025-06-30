namespace StudentManagementSystem.DTOs
{
    public class StudentCourseDTO
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
    }

    public class EnrollRequestDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}