using EpsicBlogBackend.Models;
using EpsicBlogBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace EpsicBlogBackend.Controllers
{
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("comments")]
        public IActionResult GetAll()
        {
            return Ok(_commentService.GetAll());
        }

        [HttpGet("comments/{id}")]
        public IActionResult GetSingle(int id)
        {
            if (id <= 0) return BadRequest();
            var comment = _commentService.GetSingle(id);
            if (comment == null) return NotFound();
            return Ok(comment);
        }

        [HttpPost("comments/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Comment model)
        {
            if (id <= 0) return BadRequest();
            if (!_commentService.ExistsById(id)) return NotFound();
            return Ok(_commentService.Update(id, model));
        }

        [HttpPost("comments")]
        public IActionResult Add(Comment comment)
        {
            if (_commentService.ExistsById(comment.Id)) return BadRequest();
            _commentService.Add(comment);
            return Created($"comments/{comment.Id}", comment);
        }

        [HttpDelete("comments/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _commentService.Delete(id);
                return NoContent();
            }
            catch
            {
                return NoContent();
            }
        }
    }
}
