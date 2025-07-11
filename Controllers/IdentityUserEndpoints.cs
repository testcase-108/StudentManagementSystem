using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApplication7.model;

namespace WebApplication7.Controllers
{
    public class RegisterUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }

    public class LoginUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public static class IdentityUserEndpoints
    {
        public static IEndpointRouteBuilder MapIdentityUserEndpoints(this IEndpointRouteBuilder app, IConfiguration config)
        {
            app.MapPost("/api/signup", CreateUser);
            app.MapPost("/api/signin", Login);
            return app;
        }

            [AllowAnonymous]
            private static async Task<IResult> CreateUser (
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            [FromBody] RegisterUser registerUser)
            {
            var user = new User
            {
                UserName = registerUser.Email,
                FirstName = registerUser.FirstName,
                LastName = registerUser.LastName,
                Email = registerUser.Email
            };

            var res = await userManager.CreateAsync(user, registerUser.Password);

            if (!res.Succeeded)
                return Results.BadRequest(res.Errors);
            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
            await userManager.AddToRoleAsync(user, "User");

            return Results.Ok();
        }
            
            [AllowAnonymous]
            private static async Task<IResult> Login (
                UserManager<User> userManager,
                [FromBody] LoginUser loginUser,
                IConfiguration config)
            {
                var user = await userManager.FindByEmailAsync(loginUser.Email);

                if (user != null && userManager.CheckPasswordAsync(user, loginUser.Password).Result)
                {
                    // Create JWT token
                var roles = await userManager.GetRolesAsync(user);
                //string getRoles = roles.FirstOrDefault() ?? "User";
                var sigInKey = new SymmetricSecurityKey(
                        System.Text.Encoding.UTF8.GetBytes(
                            config["AppSettings:JWTSecretKey"]!));

                var claims = new List<Claim>
                {
                    new Claim("UserID", user.Id.ToString())
                };
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                var tokenDescriptor = new SecurityTokenDescriptor
                    {

                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(
                      sigInKey, SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var actualToken = tokenHandler.WriteToken(token);
                    return Results.Ok(new { actualToken });
                }
                else
                {
                    return Results.BadRequest("Invalid login attempt.");
                }
            }  
    }
}
