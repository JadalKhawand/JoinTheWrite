using JoinTheWrite.Models;

namespace JoinTheWrite.Services.WritingsService.ChapterServices
{
    public interface IChapterService
    {
        Task<List<Chapter>> GetChaptersByCreationIdAsync(int creationId);
        Task<Chapter> GetChapterByIdAsync(int chapterId);
        Task<Chapter> CreateChapterAsync(Chapter chapter);
        Task<Chapter> UpdateChapterAsync(Chapter chapter);
        Task<bool> DeleteChapterAsync(int chapterId);
        Task<bool> IsLastChapterAsync(int chapterId);

    }
}
