using JoinTheWrite.Models;

namespace JoinTheWrite.Services.WritingsService
{
    public interface IWritingService
    {
        Task<Creation> StartNewCreationAsync(int userId, string creationTitle, string chapterTitle, string text);
        Task<List<Contribution>> GetContributionsForChapterAsync(int chapterId);
        Task<bool> SubmitContributionAsync(int userId, int chapterId, string title, string text);
        Task<bool> CastVoteAsync(int userId, int contributionId);
        Task<bool> EndVotingAndPromoteWinningContributionAsync(int chapterId);
        Task<bool> ExtendDeadlineAsync(int chapterId, TimeSpan extension);
    }
}
