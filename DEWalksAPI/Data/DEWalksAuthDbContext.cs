using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DEWalksAPI.Data
{
    public class DEWalksAuthDbContext : IdentityDbContext
    {
        public DEWalksAuthDbContext(DbContextOptions<DEWalksAuthDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "b7f3a9e2-1c5d-4e8a-bf48-9a3c2d7f89d6";
            var writerRoleId = "3e72b1c4-9d8f-4a6a-837b-5f12e9a8d3f7";

            var roles = new List<IdentityRole>
            {
                new IdentityRole {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                    
                },
                new IdentityRole {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()

                },

            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
