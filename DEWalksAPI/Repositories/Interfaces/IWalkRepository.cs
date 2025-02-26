using DEWalksAPI.Models.Domain;

namespace DEWalksAPI.Repositories.Interfaces
{
    public interface IWalkRepository
    {
        public Task<List<Walk>> GetAllWalksAsync();
        public Task<Walk?> GetWalkByIdAsync(Guid Id);
        public Task<Walk> CreateWalkAsync(Walk walk);
        public Task<Walk> UpdateWalkByIdAsync(Guid Id,Walk walk);
        public Task<Walk> DeleteWalkAsync(Guid Id);
    }
}
