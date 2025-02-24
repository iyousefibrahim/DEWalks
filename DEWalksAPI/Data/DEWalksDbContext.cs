using DEWalksAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DEWalksAPI.Data
{
    public class DEWalksDbContext : DbContext
    {
        public DEWalksDbContext(DbContextOptions contextOptions):base(contextOptions)
        {
            
        }

        public DbSet<Walk> Walks { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}
