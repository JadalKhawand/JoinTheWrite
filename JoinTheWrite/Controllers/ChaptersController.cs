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
        public async Task<ActionResult<Chapter>> CreateChapterAsync(Guid creationId)
        {
           
            var createdChapter = await _chapterService.CreateChapterAsync(creationId);

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
        // GET: api/chapter/creation/{creationId}
        [HttpGet("creation/{creationId}")]
        public async Task<ActionResult<IEnumerable<Chapter>>> GetChaptersByCreation(Guid creationId)
        {
            var chapters = await _chapterService.GetChaptersByCreationIdAsync(creationId);
            return Ok(chapters);
        }

        // GET: api/chapter/isLast/{chapterId}
        [HttpGet("isLast/{chapterId}")]
        public async Task<ActionResult<bool>> IsLastChapter(Guid chapterId)
        {
            var isLast = await _chapterService.IsLastChapterAsync(chapterId);
            return Ok(isLast);
        }
    }
}
