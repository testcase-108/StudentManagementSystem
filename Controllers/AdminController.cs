using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.DTO;
using WebApplication7.model;

namespace WebApplication7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<UserWithRolesDTO>>> GetUsersWithRoles()
        {
            var users = await _userManager.Users.ToListAsync();
            var usersWithRoles = new List<UserWithRolesDTO>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                usersWithRoles.Add(new UserWithRolesDTO
                {
                    UserId = user.Id,
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    Email = user.Email,
                    Roles = roles
                });
            }

            return Ok(usersWithRoles);
        }

        [HttpPut("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleDTO assignRoleDto)
        {
            var user = await _userManager.FindByIdAsync(assignRoleDto.UserId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!result.Succeeded)
            {
                return BadRequest("Failed to remove user roles.");
            }

            result = await _userManager.AddToRolesAsync(user, assignRoleDto.RoleNames);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }
    }
}
