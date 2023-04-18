using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = (await userService.GetUsersAsync()).ToList();
            users.Remove(users.First(user => user.Username == this.User.GetUserName()));
            return users is null ? NotFound("No Users Found") : Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await userService.GetUserByIdAsync(id);
            return user is null ? NotFound("No User Found") : Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await userService.DeleteUserAsync(id);
            return !result ? Problem("Problem in deleting the user!") : Ok("User deleted!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(User user,int id)
        {
            user.Id= id;
            var result = await userService.UpdateAsync(user);
            return !result ? Problem("Problem in updating the user!") : Ok("User updated!");
        }
    }
}
