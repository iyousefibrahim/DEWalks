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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            // Easy, Medium, Hard
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48434"),
                    Name = "Hard"
                }
            };

            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);



            // Seed data for Regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    Name = "Bayern",
                    Code = "BY",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/84/Neuschwanstein_Castle_LOC_print.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Berlin",
                    Code = "BE",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/a/a6/Berliner_Fernsehturm_abends.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Hamburg",
                    Code = "HH",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/f/f3/Speicherstadt%2C_Hamburg.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Nordrhein-Westfalen",
                    Code = "NW",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/2b/K%C3%B6lner_Dom_und_Hohenzollernbr%C3%BCcke_abends.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Sachsen",
                    Code = "SN",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3b/Bastei_2006.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Baden-Württemberg",
                    Code = "BW",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/83/Heidelberg_Schloss_und_Alte_Br%C3%BCcke.jpg"
                }
            };


            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
