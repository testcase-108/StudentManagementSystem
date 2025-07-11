using Microsoft.AspNetCore.Identity;

namespace WebApplication7.model
{
    public class User: IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        public string? LastName { get; set; }


    }
}
