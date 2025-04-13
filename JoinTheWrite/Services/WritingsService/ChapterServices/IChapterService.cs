using JoinTheWrite.Models;
using JoinTheWrite.Models.Dto;

namespace JoinTheWrite.Services.WritingsService.ChapterServices
{
    public interface IChapterService
    {
        Task<List<Chapter>> GetChaptersByCreationIdAsync(int creationId);
        Task<Chapter> CreateChapterAsync(ChapterDto dto, Guid creationId);
        Task<bool> IsLastChapterAsync(int chapterId);

        Task<Chapter?> GetChapterByIdAsync(Guid chapterId);

    }
}
