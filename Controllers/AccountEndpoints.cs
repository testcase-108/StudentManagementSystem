using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using WebApplication7.model;

namespace WebApplication7.Controllers
{
    public static class AccountEndpoints
    {
        public static IEndpointRouteBuilder MapAccountEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/UserProfile", GetProfile);
            return app;
        }

        [Authorize]
        private static async Task<IResult> GetProfile(ClaimsPrincipal user, IConfiguration config, UserManager<User> userManager)
        {
            string UserID = user.Claims.First(x => x.Type == "UserID").Value;
            var details = await userManager.FindByIdAsync(UserID);

            if (details == null)
            {
                return Results.BadRequest();
            }
            else
            {
                return Results.Ok(new
                {
                    firstName = details.FirstName,
                    lastName = details.LastName,
                    email = details.Email,
                    Roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList()
                });
            }
        }
    }
}
