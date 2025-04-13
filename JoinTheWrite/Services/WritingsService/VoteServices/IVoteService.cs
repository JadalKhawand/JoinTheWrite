namespace JoinTheWrite.Services.WritingsService.VoteServices
{
    public interface IVoteService
    {
        Task<bool> CastVoteAsync(int userId, int contributionId);
        Task<bool> RemoveVoteAsync(int userId, int contributionId);
        Task<int> GetVoteCountAsync(int contributionId);
        Task<bool> HasUserVotedAsync(int userId, int chapterId);

    }
}
