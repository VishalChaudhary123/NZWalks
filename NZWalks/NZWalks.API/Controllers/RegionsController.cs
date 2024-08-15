using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegionsController : ControllerBase
    {

        // Injecting DBContex
        private readonly NZWalksDbContext _db;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _autoMapper;
        private readonly ILogger<RegionsController> _logger;
        public RegionsController(NZWalksDbContext db, IRegionRepository regionRepository, IMapper autoMapper , ILogger<RegionsController> logger)
        {
            _db = db;
            _regionRepository = regionRepository;
            _autoMapper = autoMapper;
            _logger = logger;
        }
        [HttpGet]
        // GET ALL REGIONS
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                // Get the data from database  - Domain model
                var regionsDomain = await _regionRepository.GetAllAsync();


                // Map Domain Model to RegionDTOResponse
                var regionDTO = _autoMapper.Map<List<RegionDTOResponse>>(regionsDomain);

                // Return DTO
                return Ok(regionDTO);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Get Single Region (Get Region By Id)
        [HttpGet]
        [Route("{id:guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            // Get the mathcing data from database - Domain model

            var regionDomain = await _regionRepository.GetRegionByIdAsync(id);

            if (regionDomain == null)
            { return NotFound(); }

           
            var regionDTO = _autoMapper.Map<RegionDTOResponse>(regionDomain);
            //Return DTO
            return Ok(regionDTO);
        }

        // To Create New Region

        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        // In a POST method, we get the response FromBody
        public async Task<IActionResult> CreateRegion([FromBody] RegionDTOAddRequest request)
        {
            // Map or Convert the DTO to Domain model

            
                var regionDomainModel = _autoMapper.Map<Region>(request);

                // Use Domain model to create Region

                regionDomainModel = await _regionRepository.CreateRegionAsync(regionDomainModel);

                // Map Domain Model back to DTO

                var regionDTO = _autoMapper.Map<RegionDTOResponse>(regionDomainModel);

                // Showing the result to the client
                return CreatedAtAction(nameof(GetRegionById), new { id = regionDTO.Id }, regionDTO);
           
        }

        // Update Region
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
       // [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] RegionDTOUpdateRequest requestDTo)
        {
                var requestedDomainModel = _autoMapper.Map<Region>(requestDTo);

                var regionDomainModel = await _regionRepository.UpdateRegionAsync(id, requestedDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound();
                }
                var regionDTO = _autoMapper.Map<RegionDTOResponse>(regionDomainModel);
                return Ok(regionDTO);

           
        }

        // Delete a Region
        [HttpDelete]
        [Route("{id:guid}")]
        //[Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            // Checking
            var regionDomainModel = await _regionRepository.DeleteRegionAsync(id);

            if (regionDomainModel == null)
            {

                    return NotFound();
            }


            // Return the deleted region back

            // Map Domain model to DTO

           
            var regionDTO = _autoMapper.Map<RegionDTOResponse>(regionDomainModel);
            return Ok(regionDTO);
        }
    }
}
