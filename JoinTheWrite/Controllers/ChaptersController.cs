using JoinTheWrite.Models.Dto;
using JoinTheWrite.Models;
using JoinTheWrite.Services.WritingsService.ChapterServices;
using JoinTheWrite.Services.WritingsService.CreationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JoinTheWrite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChaptersController : ControllerBase
    {
        private readonly IChapterService _chapterService;

        public ChaptersController(IChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        // POST: api/chapters
        [HttpPost("creations/{creationId}")]
        public async Task<ActionResult<Chapter>> CreateChapterAsync(Guid creationId , [FromBody] ChapterDto chapter)
        {
            if (chapter == null)
            {
                return BadRequest();
            }

            var createdChapter = await _chapterService.CreateChapterAsync(chapter,creationId);

            // You can return 201 Created status with the location of the newly created resource
            return CreatedAtAction(nameof(GetChapter), new { id = createdChapter.ChapterId }, createdChapter);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chapter>> GetChapter(Guid id)
        {
            var chapter = await _chapterService.GetChapterByIdAsync(id);
            if (chapter == null)
                return NotFound();

            return Ok(chapter);
        }
    }
}
