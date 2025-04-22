using JoinTheWrite.Models;
using JoinTheWrite.Models.Dto;

namespace JoinTheWrite.Services.WritingsService.ContributionServices
{
    public interface IContributionService
    {
        Task<Contribution> CreateContributionAsync(ContributionDto dto);
        Task<Contribution?> GetContributionByIdAsync(Guid id);
        Task<List<Contribution>> GetContributionsByChapterAsync(Guid chapterId);
        Task<Contribution> GetWinningContributionAsync(Guid chapterId); // based on votes

    }
}
