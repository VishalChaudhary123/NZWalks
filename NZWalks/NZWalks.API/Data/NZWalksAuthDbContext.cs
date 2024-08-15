using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext<IdentityUser>
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                base.OnModelCreating(modelBuilder);
                
                var readerRoleId = "0ED02379-7E8A-45C3-BBA4-8AE60D46DC19";
                var writerRoleId = "C43B0A5C-BF8C-429A-861A-BA3CA05CDDCC";
                var role = new List<IdentityRole>
                { 
                            new IdentityRole
                            {
                              Id= readerRoleId,
                              ConcurrencyStamp = readerRoleId,
                              Name = "Reader",
                              NormalizedName = "Reader".ToUpper()
                            },
                            new IdentityRole
                            {
                              Id= writerRoleId,
                              ConcurrencyStamp = writerRoleId,
                              Name = "Writer",
                              NormalizedName = "Writer".ToUpper()
                            }
                
                };

              // Seeding roles
              modelBuilder.Entity<IdentityRole>().HasData(role);

               

           
        }
    }
}
