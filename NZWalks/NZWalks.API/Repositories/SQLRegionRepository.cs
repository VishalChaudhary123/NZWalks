using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _db;

        public SQLRegionRepository(NZWalksDbContext db)
        {
            _db = db;
        }

        public async Task<List<Region>> GetAllAsync()
        {
           return await _db.Regions.ToListAsync();

           
        }

        public async Task<Region?> GetRegionByIdAsync(Guid Id)
        {
            return await _db.Regions.FirstOrDefaultAsync(r => r.Id == Id);
        }
        public async Task<Region> CreateRegionAsync(Region region)
        {
             await _db.Regions.AddAsync(region);
            await _db.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> UpdateRegionAsync(Guid Id, Region region)
        {
           var  existingRegion = await _db.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            if (existingRegion == null)
            {
                return null;    

            }
            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

           await _db.SaveChangesAsync();
            return existingRegion;
           
        }

        public async Task<Region?> DeleteRegionAsync(Guid Id)
        {
            var existingDomainModel = await _db.Regions.FirstOrDefaultAsync(x => x.Id == Id);

            if(existingDomainModel == null)
            {
                return null;
            }

            _db.Regions.Remove(existingDomainModel);
           await  _db.SaveChangesAsync();
            return existingDomainModel;
        }
    }
}
