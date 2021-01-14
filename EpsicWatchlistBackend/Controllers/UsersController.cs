using EpsicWatchlistBackend.Models;
using EpsicWatchlistBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace EpsicWatchlistBackend.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("users")]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("users/{id}")]
        public IActionResult GetSingle(int id)
        {
            if (id <= 0) return BadRequest();
            var user = _userService.GetSingle(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost("users/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UserUpdateViewModel model)
        {
            if (id <= 0) return BadRequest();
            if (!_userService.ExistsById(id)) return NotFound();
            return Ok(_userService.Update(id, model));
        }

        [HttpPost("users")]
        public IActionResult Add(User user)
        {
            if (_userService.ExistsById(user.Id)) return BadRequest();
            if (_userService.ExistsByUsername(user.Username)) return BadRequest();
            _userService.Add(user);
            return Created($"users/{user.Id}", user);
        }

        [HttpDelete("users/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userService.Delete(id);
                return NoContent();
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpPost("users/check_password")]
        public IActionResult CheckPassword(string username, string password)
        {
            if (_userService.CheckPasswork(username, password))
            {
                return Ok();
            }
            return StatusCode(403);
        }
    }
}
