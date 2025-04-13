using JoinTheWrite.Models;

namespace JoinTheWrite.Services.WritingsService.CommentServices
{
    public interface ICommentService
    {
        Task<List<Comment>> GetCommentsByCreationIdAsync(int creationId);
        Task<List<Comment>> GetCommentsByContributionIdAsync(int contributionId);
        Task<Comment> AddCommentAsync(Comment comment);
        Task<bool> DeleteCommentAsync(int commentId);

    }
}
