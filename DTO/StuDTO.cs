namespace WebApplication7.DTO
{
    public class StuDTO
    {
        // public int StudentId { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
    }

    public class StuDTOWithId : StuDTO
    {
        public int StudentId { get; set; }

    }
}
