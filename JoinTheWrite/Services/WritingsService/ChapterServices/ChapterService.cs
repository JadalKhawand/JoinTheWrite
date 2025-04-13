using AutoMapper;
using JoinTheWrite.Data;
using JoinTheWrite.Models;
using JoinTheWrite.Models.Dto;
using JoinTheWrite.Models.enums;
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

        public async Task<List<Chapter>> GetChaptersByCreationIdAsync(Guid creationId)
        {
            return await _context.Chapters
                .Where(c => c.CreationId == creationId)
                .OrderBy(c => c.ChapterNumber)
                .ToListAsync();
        }

        public async Task<Chapter> CreateChapterAsync(ChapterDto dto, Guid creationId)
        {
            if (await IsMaxChapterReachedAsync(creationId))
            {
                throw new InvalidOperationException("Cannot create more chapters. Maximum limit reached.");
            }
            var chapter = _mapper.Map<Chapter>(dto);
            chapter.ChapterId = Guid.NewGuid();
            chapter.CreationId = creationId;
            chapter.CreatedAt = DateTime.UtcNow;

            chapter.Status = WritingStatus.OpenForWriting;

            chapter.VotingDeadline = chapter.CreatedAt.AddDays(14);

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

        private async Task<bool> IsMaxChapterReachedAsync(Guid creationId)
        {
            var maxChapters = await _context.Creations
                .Where(c => c.CreationId == creationId)
                .Select(c => c.MaxChapters)
                .FirstOrDefaultAsync();

            var currentChapters = await _context.Chapters
                .Where(c => c.CreationId == creationId)
                .CountAsync();

            return currentChapters >= maxChapters;
        }


        public async Task<bool> IsLastChapterAsync(Guid chapterId)
        {
            var chapter = await _context.Chapters.FindAsync(chapterId);
            if (chapter == null) return false;

            var maxChapter = await _context.Creations
            .Where(c => c.CreationId == chapter.CreationId)
            .Select(c => c.MaxChapters)
            .FirstOrDefaultAsync();


            return chapter.ChapterNumber == maxChapter;
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
