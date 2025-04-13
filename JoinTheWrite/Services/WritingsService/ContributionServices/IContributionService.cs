using JoinTheWrite.Models;

namespace JoinTheWrite.Services.WritingsService.ContributionServices
{
    public interface IContributionService
    {
        Task<List<Contribution>> GetContributionsByChapterIdAsync(int chapterId);
        Task<Contribution> SubmitContributionAsync(Contribution contribution);
        Task<Contribution> GetContributionByIdAsync(int id);
        Task<bool> DeleteContributionAsync(int id);
        Task<bool> IsContributionDeadlineReachedAsync(int chapterId);
        Task<Contribution> GetWinningContributionAsync(int chapterId); // based on votes

    }
}
