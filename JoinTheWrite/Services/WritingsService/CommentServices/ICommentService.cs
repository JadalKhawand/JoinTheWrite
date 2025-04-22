using JoinTheWrite.Models;
using JoinTheWrite.Models.Dto;

namespace JoinTheWrite.Services.WritingsService.CommentServices
{
    public interface ICommentService
    {
        Task<Comment> AddCommentAsync(CommentDto dto);
        Task<IEnumerable<Comment>> GetCommentsByChapterIdAsync(Guid contributionId);
        Task<bool> DeleteCommentAsync(Guid commentId);

    }
}
