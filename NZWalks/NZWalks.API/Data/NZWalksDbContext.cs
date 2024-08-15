using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext>  dbContextOptions) : base(dbContextOptions) { }
            
        public DbSet<Difficulty> Difficulties { get; set; }   
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk>  Walks { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed the data for Difficulties
            // Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty
                {
                     Id = Guid.Parse("A7784749-1D36-41B4-9C5C-C7547835AF90"),
                     Name = "Easy"
                },
                 new Difficulty
                {
                     Id = Guid.Parse("DA435085-FA7B-478E-A975-EEA82C2CBDE6"),
                     Name = "Medium"
                },
                  new Difficulty
                {
                     Id = Guid.Parse("68CEDBFC-F43F-4F96-870E-41F1296FFD4F"),
                     Name = "Hard"
                }
            };

            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Regions 

            var regions = new List<Region>()
            { 
                new Region 
                {
                     Id = Guid.Parse("0922D3CA-37DF-44E0-8874-297FFDDE3399"),
                      Name = "Auckland",
                      Code = "AKL", 
                      RegionImageUrl = "https://www.distantjourneys.co.uk/wp-content/uploads/2018/03/auckland-sky-tower-at-night-new-zealand.jpg"
                },
                 new Region
                {
                     Id = Guid.Parse("56ECD709-DC48-4AD0-AE72-DB687141244D"),
                      Name = "Northland",
                      Code = "NTL",
                      RegionImageUrl = "https://www.civitatis.com/f/australia/byron-bay/byron-bay-m.jpg"
                },
                new Region
                {
                     Id = Guid.Parse("7B8308D4-2CAE-4658-873F-B43435504E7B"),
                      Name = "Bey of Plenty",
                      Code = "BOP",
                      RegionImageUrl = "https://lp-cms-production.imgix.net/image_browser/GettyImages-103581610.jpg?auto=format&fit=crop&sharp=10&vib=20&ixlib=react-8.6.4&w=850&q=20&dpr=5"
                },
                 new Region
                {
                     Id = Guid.Parse("0541FD0D-403E-4783-95D2-877848F49773"),
                      Name = "Wellington", Code = "WGN",
                      RegionImageUrl = "https://th.bing.com/th/id/OIP.58LIsvmhTiieG_6pTm7FIAHaE8?rs=1&pid=ImgDetMain"
                },
                 new Region
                {
                     Id = Guid.Parse("F6605D3F-0269-46D8-A023-A12A20810B6D"),
                      Name = "Nelson",
                     Code = "NSN",
                      RegionImageUrl = "https://th.bing.com/th/id/OIP.FRYxO84ju7dLdC8ymUSCpwHaEK?rs=1&pid=ImgDetMain"
                },
                  new Region
                {
                     Id = Guid.Parse("80853B49-C740-4A7A-9A0B-BBF8D07BE58E"),
                      Name = "Southland",
                      Code = "STL",
                      RegionImageUrl = "https://th.bing.com/th/id/OIP.9O3-I4uO5XgoQ9QmGIKi6QHaEK?rs=1&pid=ImgDetMain"
                }


            };

            modelBuilder.Entity<Region>().HasData(regions);

        }
    }

    
}
