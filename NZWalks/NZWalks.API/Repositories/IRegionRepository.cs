using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
     /// <summary>
     /// Gets the list of all Regions
     /// </summary>
     /// <returns>Returns all regions</returns>
       Task<List<Region>> GetAllAsync();


        /// <summary>
        /// Gets the region object based on provided Id
        /// </summary>
        /// <param name="Id">Region to retrieve</param>
        /// <returns>Returns the region object based on provided Id</returns>
        Task<Region?> GetRegionByIdAsync(Guid Id);

        /// <summary>
        /// Creates the new region object
        /// </summary>
        /// <param name="region">objec to create</param>
        /// <returns>Returns the newly create region object</returns>
        Task<Region> CreateRegionAsync(Region region);


        /// <summary>
        /// Method to update the existing Region object based on provided Id.
        /// </summary>
        /// <param name="Id">Objec to update </param>
        /// <param name="region">Information to update against the provided object Id</param>
        /// <returns>Returns the newly updated region object</returns>
        Task<Region?> UpdateRegionAsync(Guid Id,Region region);

        Task<Region?> DeleteRegionAsync(Guid Id);
    }
}
