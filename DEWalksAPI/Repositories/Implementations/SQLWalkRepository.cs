using DEWalksAPI.Data;
using DEWalksAPI.Models.Domain;
using DEWalksAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DEWalksAPI.Repositories.Implementations
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly DEWalksDbContext dbContext;

        public SQLWalkRepository(DEWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Walk>> GetAllWalksAsync()
        {
            var walks = await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
            if(walks == null)
            {
                return null;
            }

            return walks;
        }

        public async Task<Walk?> GetWalkByIdAsync(Guid Id)
        {
            var walk =  await dbContext.Walks.Include(d => d.Difficulty).Include(r => r.Region).FirstOrDefaultAsync(w => w.Id == Id);

            if(walk == null)
            {
                return null;
            }

            return walk;
        }

        public async Task<Walk> CreateWalkAsync(Walk walk)
        {
            if (walk == null)
            {
                return null;
            }

            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();

            return await dbContext.Walks
                .Include(w => w.Difficulty)
                .Include(w => w.Region)
                .FirstOrDefaultAsync(w => w.Id == walk.Id);
        }

        public async Task<Walk> UpdateWalkByIdAsync(Guid Id, Walk walk)
        {
            var existingWalk = await dbContext.Walks
                .Include(w => w.Difficulty)  
                .Include(w => w.Region)     
                .FirstOrDefaultAsync(w => w.Id == Id);

            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;

            await dbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<Walk> DeleteWalkAsync(Guid Id)
        {
            var walk = dbContext.Walks.FirstOrDefault(w => w.Id == Id);

            if(walk == null)
            {
                return null;
            }

            dbContext.Walks.Remove(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        
    }
}
