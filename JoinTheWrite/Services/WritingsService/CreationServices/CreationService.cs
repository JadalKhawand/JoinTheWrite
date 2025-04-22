using AutoMapper;
using JoinTheWrite.Data;
using JoinTheWrite.Mappings;
using JoinTheWrite.Models;
using JoinTheWrite.Models.Dto;
using JoinTheWrite.Models.enums;
using Microsoft.EntityFrameworkCore;

namespace JoinTheWrite.Services.WritingsService.CreationServices
{
    public class CreationService : ICreationService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreationService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Creation>> GetAllCreationsAsync()
        {
            return await _context.Creations
                .Include(c => c.Chapters)
                    .ThenInclude(ch => ch.Contributions)
                        .ThenInclude(con => con.Votes)
                .Include(c => c.Chapters)
                    .ThenInclude(ch => ch.Contributions)
                        .ThenInclude(con => con.Comments)
                .ToListAsync();
        }


        public async Task<Creation> GetCreationByIdAsync(Guid id)
        {
            var creation = await _context.Creations
                .Include(c => c.Chapters)
                    .ThenInclude(ch => ch.Contributions)
                        .ThenInclude(con => con.Votes)
                .Include(c => c.Chapters)
                    .ThenInclude(ch => ch.Contributions)
                        .ThenInclude(con => con.Comments)
                .FirstOrDefaultAsync(c => c.CreationId == id);

            if (creation == null)
                throw new Exception("Creation not found.");

            return creation;
        }


        public async Task<Creation> CreateCreationAsync(CreationDto dto)
        {
            var authorExists = await _context.Users.AnyAsync(u => u.AuthorId == dto.AuthorId);
            if (!authorExists)
            {
                throw new Exception("Author not found. Please provide a valid AuthorId.");
            }
            Console.WriteLine($"Received AuthorId: {dto.AuthorId}");

            // Step 1: Map DTO to entity (ignored fields will remain default)
            var creation = _mapper.Map<Creation>(dto);

            // Step 2: Set the system-managed fields
            creation.CreationId = Guid.NewGuid(); // or let EF generate
            creation.CreatedAt = DateTime.UtcNow;
            creation.ModifiedAt = DateTime.UtcNow;
            creation.VotingStartDate = DateTime.UtcNow.AddDays(14); // based on your platform logic
            creation.VotingEndDate = creation.VotingStartDate.AddDays(7);

            // Step 3: Save to database
            _context.Creations.Add(creation);
            await _context.SaveChangesAsync();

            return creation;
        }

        public async Task<Creation> UpdateCreationAsync(Guid id, CreationDto dto)
        {
            var existing = await _context.Creations.FindAsync(id);

            if (existing == null)
            {
                // If not found, return null
                return null;
            }

            // Map the DTO to the entity
            var creation = _mapper.Map<Creation>(dto);

            // Update the fields for the existing record
            existing.Title = creation.Title;
            existing.ModifiedAt = DateTime.UtcNow;
            existing.VotingStartDate = creation.VotingStartDate.ToString() != string.Empty ? creation.VotingStartDate : existing.VotingStartDate;
            existing.VotingEndDate = creation.VotingEndDate.ToString() != string.Empty ? creation.VotingEndDate : existing.VotingEndDate;


                    // Save the changes to the database
            await _context.SaveChangesAsync();
            return existing;
       }




        public async Task<bool> DeleteCreationAsync(Guid id)
        {
            var creation = await _context.Creations.FindAsync(id);
            if (creation == null) return false;

            _context.Creations.Remove(creation);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Creation>> GetCreationsByUserIdAsync(Guid userId)
        {
            return await _context.Creations
                .Where(c => c.AuthorId == userId)
                .ToListAsync();
        }
    }
}
