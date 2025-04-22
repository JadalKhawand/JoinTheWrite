using AutoMapper;
using JoinTheWrite.Data;
using JoinTheWrite.Models.Dto;
using JoinTheWrite.Models;
using JoinTheWrite.Models.enums;
using Microsoft.EntityFrameworkCore;

namespace JoinTheWrite.Services.WritingsService.ContributionServices
{
   
        public class ContributionService : IContributionService
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public ContributionService(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Contribution> CreateContributionAsync(ContributionDto dto)
            {
                var contribution = _mapper.Map<Contribution>(dto);
                contribution.ContributionId = Guid.NewGuid();
                contribution.SubmittedAt = DateTime.UtcNow;

                _context.Contributions.Add(contribution);
                await _context.SaveChangesAsync();
                return contribution;
            }

            public async Task<Contribution?> GetContributionByIdAsync(Guid id)
            {
                return await _context.Contributions
                    .Include(c => c.Author)
                    .Include(c => c.Chapter)
                    .FirstOrDefaultAsync(c => c.ContributionId == id);
            }

            public async Task<List<Contribution>> GetContributionsByChapterAsync(Guid chapterId)
            {
                return await _context.Contributions
                    .Where(c => c.ChapterId == chapterId)
                    .OrderByDescending(c => c.SubmittedAt)
                    .ToListAsync();
            }
            public async Task<Contribution> GetWinningContributionAsync(Guid chapterId)
            {
                var winningContribution = await _context.Contributions
                    .Where(c => c.ChapterId == chapterId)
                    .OrderByDescending(c => c.Votes.Count) // highest vote count
                    .FirstOrDefaultAsync();

                if (winningContribution == null)
                    throw new InvalidOperationException("No contributions found for this chapter.");

                // Update the Chapter's FinalizedContributionId
                var chapter = await _context.Chapters.FindAsync(chapterId);
                if (chapter == null)
                    throw new InvalidOperationException("Chapter not found.");

                chapter.FinalizedContributionId = winningContribution.ContributionId;
                chapter.Status = WritingStatus.Finalized;

                await _context.SaveChangesAsync();

                return winningContribution;
            }

        }
    }
