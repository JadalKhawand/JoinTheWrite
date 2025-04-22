using JoinTheWrite.Services.WritingsService.VoteServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JoinTheWrite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;

        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
        }

        [HttpPost("upvote")]
        public async Task<IActionResult> Upvote(Guid contributionId, Guid userId)
        {
            var success = await _voteService.UpvoteAsync(contributionId, userId);
            return success ? Ok("Upvoted successfully.") : BadRequest("Already upvoted.");
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveVote(Guid contributionId, Guid userId)
        {
            var success = await _voteService.RemoveVoteAsync(contributionId, userId);
            return success ? Ok("Vote removed.") : NotFound("Vote not found.");
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetVoteCount(Guid contributionId)
        {
            var count = await _voteService.GetVoteCountAsync(contributionId);
            return Ok(count);
        }

        [HttpPost("finalize")]
        public async Task<IActionResult> FinalizeVoting(Guid chapterId)
        {
            await _voteService.EvaluateVotesAndFinalizeAsync(chapterId);
            return Ok("Finalization process complete.");
        }
    }
}
