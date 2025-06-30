namespace StudentManagementSystem.DTO
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class StudentAddDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

