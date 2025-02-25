using DEWalksAPI.Models.Domain;
using DEWalksAPI.Models.DTO;

namespace DEWalksAPI.Repositories.Interfaces
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllRegionsAsync();
        Task<Region?> GetRegionByIdAsync(Guid Id);
        Task<Region> CreateRegionAsync(Region region);

        Task<Region?> UpdateRegionByIdAsync(Guid Id, Region region);
        Task<Region?> DeleteAsync(Guid Id);
    }
}
