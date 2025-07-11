namespace WebApplication7.DTO
{
    public class UserWithRolesDTO
    {
        public string UserId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
    }

    public class AssignRoleDTO
    {
        public string UserId { get; set; }
        public IList<string> RoleNames { get; set; }
    }
}
