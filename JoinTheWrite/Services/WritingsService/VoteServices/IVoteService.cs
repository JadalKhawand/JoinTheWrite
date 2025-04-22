namespace JoinTheWrite.Services.WritingsService.VoteServices
{
    public interface IVoteService
    {
        Task<bool> UpvoteAsync(Guid contributionId, Guid userId);
        Task<bool> RemoveVoteAsync(Guid contributionId, Guid userId);
        Task<int> GetVoteCountAsync(Guid contributionId);
        Task EvaluateVotesAndFinalizeAsync(Guid chapterId);

    }
}
