using JoinTheWrite.Models.Dto;
using JoinTheWrite.Models;
using JoinTheWrite.Services.WritingsService.ContributionServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JoinTheWrite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContributionsController : ControllerBase
    {
        private readonly IContributionService _contributionService;

        public ContributionsController(IContributionService contributionService)
        {
            _contributionService = contributionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContribution([FromBody] ContributionDto dto)
        {
            var contribution = await _contributionService.CreateContributionAsync(dto);
            return Ok(contribution);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contribution>> GetContribution(Guid id)
        {
            var contribution = await _contributionService.GetContributionByIdAsync(id);
            if (contribution == null) return NotFound();
            return Ok(contribution);
        }

        [HttpGet("chapter/{chapterId}")]
        public async Task<ActionResult<List<Contribution>>> GetByChapter(Guid chapterId)
        {
            var contributions = await _contributionService.GetContributionsByChapterAsync(chapterId);
            return Ok(contributions);
        }
        [HttpPost("chapter/{chapterId}/finalize")]
        public async Task<ActionResult<Contribution>> FinalizeChapter(Guid chapterId)
        {
            try
            {
                var winning = await _contributionService.GetWinningContributionAsync(chapterId);
                return Ok(winning);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
