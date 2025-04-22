using JoinTheWrite.Models.Dto;
using JoinTheWrite.Services.WritingsService.CommentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JoinTheWrite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] CommentDto dto)
        {
            var result = await _commentService.AddCommentAsync(dto);
            return Ok(result);
        }

        [HttpGet("chapter/{chapterId}")]
        public async Task<IActionResult> GetComments(Guid chapterId)
        {
            var result = await _commentService.GetCommentsByChapterIdAsync(chapterId);
            return Ok(result);
        }
        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment(Guid commentId)
        {
            var success = await _commentService.DeleteCommentAsync(commentId);
            if (!success)
                return NotFound(new { message = "Comment not found." });

            return NoContent();
        }

    }
}
