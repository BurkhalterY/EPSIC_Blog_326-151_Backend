using EpsicBlogBackend.Models;
using EpsicBlogBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace EpsicBlogBackend.Controllers
{
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("posts")]
        public IActionResult GetAll()
        {
            return Ok(_postService.GetAll());
        }

        [HttpGet("posts/{id}")]
        public IActionResult GetSingle(int id)
        {
            if (id <= 0) return BadRequest();
            var post = _postService.GetSingle(id);
            if (post == null) return NotFound();
            return Ok(post);
        }

        [HttpPost("posts/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Post model)
        {
            if (id <= 0) return BadRequest();
            if (!_postService.ExistsById(id)) return NotFound();
            return Ok(_postService.Update(id, model));
        }

        [HttpPost("posts")]
        public IActionResult Add(Post post)
        {
            if (_postService.ExistsById(post.Id)) return BadRequest();
            _postService.Add(post);
            return Created($"posts/{post.Id}", post);
        }

        [HttpDelete("posts/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _postService.Delete(id);
                return NoContent();
            }
            catch
            {
                return NoContent();
            }
        }
    }
}
