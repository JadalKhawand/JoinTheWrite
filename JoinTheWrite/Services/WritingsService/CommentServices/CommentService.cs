using AutoMapper;
using JoinTheWrite.Data;
using JoinTheWrite.Models.Dto;
using JoinTheWrite.Models;
using Microsoft.EntityFrameworkCore;

namespace JoinTheWrite.Services.WritingsService.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CommentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Comment> AddCommentAsync(CommentDto dto)
        {
            var authorExists = await _context.Users.AnyAsync(u => u.AuthorId == dto.AuthorId);
            if (!authorExists)
                throw new Exception("Author not found.");

            var contributionExists = await _context.Contributions.AnyAsync(c => c.ContributionId == dto.ContributionId);
            if (!contributionExists)
                throw new Exception("Contribution not found.");

            var comment = _mapper.Map<Comment>(dto);
            comment.CommentId = Guid.NewGuid();
            comment.PostedAt = DateTime.UtcNow;

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return _mapper.Map<Comment>(comment);
        }

        public async Task<IEnumerable<Comment>> GetCommentsByChapterIdAsync(Guid contributionId)
        {
            var comments = await _context.Comments
                .Where(c => c.ContributionId == contributionId)
                .OrderByDescending(c => c.PostedAt)
                .ToListAsync();

            return _mapper.Map<IEnumerable<Comment>>(comments);
        }
        public async Task<bool> DeleteCommentAsync(Guid commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null)
                return false;

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
