using AutoMapper;
using JoinTheWrite.Data;
using JoinTheWrite.Models;
using JoinTheWrite.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace JoinTheWrite.Services.WritingsService.ChapterServices
{
    public class ChapterService : IChapterService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ChapterService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Chapter>> GetChaptersByCreationIdAsync(int creationId)
        {
            return await _context.Chapters
                .Where(c => c.CreationId == new Guid(creationId.ToString()))
                .OrderBy(c => c.ChapterNumber)
                .ToListAsync();
        }

        public async Task<Chapter> CreateChapterAsync(ChapterDto dto, Guid creationId)
        {
            var chapter = _mapper.Map<Chapter>(dto);
            chapter.ChapterId = Guid.NewGuid();
            chapter.CreationId = creationId;
            chapter.CreatedAt = DateTime.UtcNow;
            chapter.Status = dto.Status;

            // Get latest chapter number
            int lastChapterNumber = await _context.Chapters
                .Where(c => c.CreationId == creationId)
                .OrderByDescending(c => c.ChapterNumber)
                .Select(c => c.ChapterNumber)
                .FirstOrDefaultAsync();

            chapter.ChapterNumber = lastChapterNumber + 1;

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

        public async Task<Chapter?> GetChapterByIdAsync(Guid chapterId)
        {
            var chapter = await _context.Chapters
                .Include(c => c.Contributions)
                .FirstOrDefaultAsync(c => c.ChapterId == chapterId);

            if (chapter == null) return null;

            return chapter;
        }
    }

}
