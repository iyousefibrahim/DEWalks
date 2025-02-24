using Microsoft.EntityFrameworkCore;

namespace DEWalksAPI.Data
{
    public class DEWalksDbContext : DbContext
    {
        public DEWalksDbContext(DbContextOptions contextOptions):base(contextOptions)
        {
            
        }
    }
}
