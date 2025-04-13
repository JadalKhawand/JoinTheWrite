using JoinTheWrite.Models;

namespace JoinTheWrite.Services.WritingsService.ChapterServices
{
    public interface IChapterService
    {
        Task<List<Chapter>> GetChaptersByCreationIdAsync(int creationId);
        Task<Chapter> CreateChapterAsync(Chapter chapter);
        Task<bool> IsLastChapterAsync(int chapterId);

    }
}
