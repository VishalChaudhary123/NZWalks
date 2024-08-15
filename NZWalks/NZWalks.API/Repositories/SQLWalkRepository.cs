using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _db;
        public SQLWalkRepository(NZWalksDbContext db)
        {
            _db = db;
        }
        public async Task<Walk> CreateWalkAsync(Walk walk)
        {
            await _db.Walks.AddAsync(walk);
            _db.SaveChanges();
            return walk;
        }

        public async Task<Walk?> DeelteWalkAsync(Guid id)
        {
            var getwalk = await _db.Walks.FirstOrDefaultAsync(temp => temp.Id == id);
            if (getwalk == null)
            {
                return null;
            }

           _db.Walks.Remove(getwalk);
            await _db.SaveChangesAsync();

            return getwalk;

        }

        public async Task<List<Walk>> GetAllWalksAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1,  int pageSize = 5)
        {

            var walks = _db.Walks.Include("Difficulty").Include("Region"). AsQueryable();

            // Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            
            {
                // WIll enter over here if both are not null or whitespace


                if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
               
            
            }


            // Sorting
            if(string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x =>x.Name);
                }
                else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            // Paggination

            var skipResults = (pageNumber - 1) * pageSize;



            return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
            //var allWalks = _db.Walks.Include("Difficulty").Include("Region").ToListAsync();
            //return allWalks;
        }

        public async Task<Walk?> GetWalkByIdAsync(Guid id)
        {
           var Walk =  await _db.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(temp => temp.Id == id);
            if (Walk == null) { return null; }
            return Walk;
        }

        public async Task<Walk?> UpdateWalkAsync(Guid id, Walk walk)
        {
            var getwalk = await _db.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (getwalk == null) { return null; }

            getwalk.Name = walk.Name;
            getwalk.Description = walk.Description;
            getwalk.LengthInKm = walk.LengthInKm;
            getwalk.WalkImageUrl = walk.WalkImageUrl;
            getwalk.DifficultyId = walk.DifficultyId;
            getwalk.RegionId = walk.RegionId;

            await _db.SaveChangesAsync();
            return getwalk;


        }
    }
}
