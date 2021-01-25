using EpsicBlogBackend.Models;
using EpsicBlogBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace EpsicBlogBackend.Controllers
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
            if (id <= 0) return BadRequest("L'ID doit être suppérieur à 0.");
            if (!_userService.ExistsById(id)) return NotFound();
            if (model.Password != string.Empty && !_userService.ConfirmPassword(model.Password, model.Passconf)) return BadRequest("Les mots de passe ne correspondent pas !");
            return Ok(_userService.Update(id, model));
        }

        [HttpPost("users")]
        public IActionResult Add(User user)
        {
            if (_userService.ExistsById(user.Id)) return BadRequest("Cet ID est déjà attribué !");
            if (_userService.ExistsByUsername(user.Username)) return BadRequest("Ce nom d'utilisateur est déjà utilisé !");
            if (!_userService.ConfirmPassword(user.Password, user.Passconf)) return BadRequest("Les mots de passe ne correspondent pas !");
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
        public IActionResult CheckPassword([FromBody] UserCheckPasswordViewModel user)
        {
            if (_userService.CheckPassword(user.Username, user.Password))
            {
                return Ok(_userService.GetByUsername(user.Username));
            }
            return StatusCode(403);
        }

        [HttpPost("users/{id}/avatar")]
        public IActionResult Images([FromRoute] int id, IFormFile file)
        {
            var ms = new MemoryStream();
            file.CopyTo(ms);
            _userService.SetAvatar(id, ms.ToArray());
            return Ok();
        }

        [HttpGet("users/{id}/avatar")]
        public IActionResult Images([FromRoute] int id)
        {
            var avatar = _userService.GetAvatar(id);
            if (avatar != null)
            {
                return File(avatar, "image/png");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
