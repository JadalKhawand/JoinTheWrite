using JoinTheWrite.Data;
using JoinTheWrite.Models;
using JoinTheWrite.Services.WritingsService.ChapterServices;
using Microsoft.EntityFrameworkCore;

namespace JoinTheWrite.Services.WritingsService.VoteServices
{
    public class VoteService : IVoteService
    {
        private readonly AppDbContext _context;

        private readonly IChapterService _chapterService;

        public VoteService(AppDbContext context, IChapterService chapterService)
        {
            _context = context;
            _chapterService = chapterService;
        }

        public async Task<bool> UpvoteAsync(Guid contributionId, Guid userId)
        {
            var exists = await _context.Votes
                .AnyAsync(v => v.ContributionId == contributionId && v.AuthorId == userId);

            if (exists)
                return false; // Already voted

            var vote = new Vote
            {
                VoteId = Guid.NewGuid(),
                ContributionId = contributionId,
                AuthorId = userId,
                IsUpvote = true
            };

            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveVoteAsync(Guid contributionId, Guid userId)
        {
            var vote = await _context.Votes
                .FirstOrDefaultAsync(v => v.ContributionId == contributionId && v.AuthorId == userId);

            if (vote == null)
                return false;

            _context.Votes.Remove(vote);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetVoteCountAsync(Guid contributionId)
        {
            return await _context.Votes
                .CountAsync(v => v.ContributionId == contributionId && v.IsUpvote);
        }

        public async Task EvaluateVotesAndFinalizeAsync(Guid chapterId)
        {
            var chapter = await _context.Chapters
                .Include(c => c.Contributions)
                    .ThenInclude(c => c.Votes)
                .FirstOrDefaultAsync(c => c.ChapterId == chapterId);

            if (chapter == null || chapter.Status != Models.enums.WritingStatus.Finalized || chapter.VotingDeadline == null)
                return;

            if (DateTime.UtcNow < chapter.VotingDeadline.Value)
                return;

            var winningContribution = chapter.Contributions
                .OrderByDescending(c => c.Votes.Count(v => v.IsUpvote))
                .ThenBy(c => c.SubmittedAt)
                .FirstOrDefault();

            if (winningContribution != null)
            {
                chapter.FinalizedContributionId = winningContribution.ContributionId;
                chapter.FinalizedTitle = winningContribution.Title;
                chapter.Status = Models.enums.WritingStatus.Finalized;

                await _context.SaveChangesAsync();

                await _chapterService.CreateChapterAsync(chapter.CreationId);
            }
        }
    }
}
