using Microsoft.AspNetCore.Mvc;
using RandomUserService.Api.DTO;
using RandomUserService.Core.Services;

namespace RandomUserService.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = (await _userService.GetAllUsersAsync())
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Title = u.Title,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Gender = u.Gender,
                    Email = u.Email,
                    ExternalId = u.ExternalId,
                    Timestamp = u.Timestamp
                });

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            var dto = new UserDto
            {
                Id = user.Id,
                Title = user.Title,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                Email = user.Email,
                ExternalId = user.ExternalId,
                Timestamp = user.Timestamp
            };

            return Ok(dto);
        }
    }
}
