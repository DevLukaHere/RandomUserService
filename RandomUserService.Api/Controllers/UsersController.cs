using Microsoft.AspNetCore.Mvc;
using RandomUserService.Api.DTO.Mappings;
using RandomUserService.Core.Services;

namespace RandomUserService.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            var usersDto = users.Select(user => user.ToDto());

            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound(id);
            }
            var userDto = user.ToDto();

            return Ok(userDto);
        }
    }
}
