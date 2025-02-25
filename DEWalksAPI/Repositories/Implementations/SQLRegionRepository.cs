using DEWalksAPI.Data;
using DEWalksAPI.Models.Domain;
using DEWalksAPI.Models.DTO;
using DEWalksAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DEWalksAPI.Repositories.Implementations
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly DEWalksDbContext _Dbcontext;
        public SQLRegionRepository(DEWalksDbContext _Dbcontext)
        {
            this._Dbcontext = _Dbcontext;
        }

        public async Task<List<Region>> GetAllRegionsAsync()
        {
            // Get Data From DataBase (Domain Model)
            var regions = await _Dbcontext.Regions.ToListAsync();
            return regions;
        }

        public async Task<Region?> GetRegionByIdAsync(Guid Id)
        {
            return await _Dbcontext.Regions.FirstOrDefaultAsync(r => r.Id == Id);
            
        }

        public async Task<Region> CreateRegionAsync(Region region)
        {
            await _Dbcontext.Regions.AddAsync(region);
            await _Dbcontext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> UpdateRegionByIdAsync(Guid Id, Region region)
        {
            var existingRegion = await _Dbcontext.Regions.FirstOrDefaultAsync(r => r.Id == Id);

            if(existingRegion == null)
            {
                return null;
            }

            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await _Dbcontext.SaveChangesAsync();

            return existingRegion;
            
        }

        public async Task<Region?> DeleteAsync(Guid Id)
        {
            var region = await _Dbcontext.Regions.FirstOrDefaultAsync(r => r.Id == Id);
            if(region == null)
            {
                return null;
            }
            _Dbcontext.Regions.Remove(region);
            await _Dbcontext.SaveChangesAsync();
            return region;
        }
    }
}
