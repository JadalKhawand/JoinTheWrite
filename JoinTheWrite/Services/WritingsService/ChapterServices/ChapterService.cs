using JoinTheWrite.Data;
using JoinTheWrite.Models;
using Microsoft.EntityFrameworkCore;

namespace JoinTheWrite.Services.WritingsService.ChapterServices
{
    public class ChapterService
    {
        private readonly AppDbContext _context;

        public ChapterService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Chapter>> GetChaptersByCreationIdAsync(int creationId)
        {
            return await _context.Chapters
                .Where(c => c.CreationId == new Guid(creationId.ToString()))
                .OrderBy(c => c.ChapterNumber)
                .ToListAsync();
        }

        public async Task<Chapter> CreateChapterAsync(Chapter chapter)
        {
            // Get the highest chapter number for this creation
            var lastChapter = await _context.Chapters
                .Where(c => c.CreationId == chapter.CreationId)
                .OrderByDescending(c => c.ChapterNumber)
                .FirstOrDefaultAsync();

            chapter.ChapterNumber = lastChapter == null ? 1 : lastChapter.ChapterNumber + 1;
            chapter.CreatedAt = DateTime.UtcNow;

            _context.Chapters.Add(chapter);
            await _context.SaveChangesAsync();

            return chapter;
        }

        public async Task<bool> IsLastChapterAsync(int chapterId)
        {
            var chapter = await _context.Chapters.FindAsync(new Guid(chapterId.ToString()));
            if (chapter == null) return false;

            var maxChapterNumber = await _context.Chapters
                .Where(c => c.CreationId == chapter.CreationId)
                .MaxAsync(c => c.ChapterNumber);

            return chapter.ChapterNumber == maxChapterNumber;
        }
    }

}
}
