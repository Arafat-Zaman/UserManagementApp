using Microsoft.AspNetCore.Mvc;
using UserManagementApp.Server.Models;
using UserManagementApp.Server.Services;

namespace UserManagementApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers() => Ok(_userService.GetUsers());

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id) => Ok(_userService.GetUserById(id));

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] User user)
        {
            if (user == null || user.Id <= 0)
            {
                return BadRequest("Invalid user data.");
            }

            _userService.UpdateUser(user);
            return NoContent(); // Indicates success with no response body
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
