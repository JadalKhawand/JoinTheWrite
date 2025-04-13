using JoinTheWrite.Models;
using JoinTheWrite.Models.Dto;

namespace JoinTheWrite.Services.WritingsService.CreationServices
{
    public interface ICreationService
    {
        Task<List<Creation>> GetAllCreationsAsync();
        Task<Creation> GetCreationByIdAsync(Guid id);
        Task<Creation> CreateCreationAsync(CreationDto creation);
        Task<Creation> UpdateCreationAsync(Guid id, CreationDto dto);

        Task<bool> DeleteCreationAsync(Guid id);
        Task<List<Creation>> GetCreationsByUserIdAsync(Guid userId);

    }
}
