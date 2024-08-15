using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _autoMapper;
        private readonly IWalkRepository _walkRepository;
        public WalksController(IMapper automapper, IWalkRepository walkRepository)
        {
            _autoMapper = automapper;
            _walkRepository = walkRepository;
        }

        // GET ALL WALKS
        // GET : /api/walks?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAllWalks([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber =1,[FromQuery] int pageSize = 5)
        {
           var  walkDomainMode  =  await _walkRepository.GetAllWalksAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            // Map DTO to Domain Model
           var walkDTO = _autoMapper.Map<List<WalkDTOResponse>>(walkDomainMode);
            return Ok(walkDTO);

        }
        // CREATE WALK

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateWalk([FromBody] WalkDTOAddRequest walkDTOAddRequest)
        {
            // Map DTO to domain model

          var walkDomainModel =   _autoMapper.Map<Walk>(walkDTOAddRequest);

           var  walkDTO =  await _walkRepository.CreateWalkAsync(walkDomainModel);

            // Map Domain Model to DTO

            _autoMapper.Map<WalkDTOResponse>(walkDomainModel);

            return Ok();

        }


        // Getting Single Walk

        [HttpGet]
        [Route("{Id:guid}")]

        public async Task<IActionResult> GetWalkById([FromRoute] Guid Id)
        {
           var walkDomainModel = await _walkRepository.GetWalkByIdAsync(Id);

            if(walkDomainModel == null)
            {
                return NotFound();
            }
            // Map the Domain Model to DTO

              var   walkDTO=   _autoMapper.Map<WalkDTOResponse> (walkDomainModel);
            return Ok(walkDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, WalkDTOUpdateRequest walkDTOUpdateRequest)
        {
            //Map DTO to DOmain Model
           var walkDOmainModel =  _autoMapper.Map<Walk>(walkDTOUpdateRequest);

            walkDOmainModel = await _walkRepository.UpdateWalkAsync(id, walkDOmainModel);

            if(walkDOmainModel == null)
            {
                return NotFound();
            }

            // Map Domain model to DTO

          var walkDTO =   _autoMapper.Map<WalkDTOResponse>(walkDOmainModel);
            return Ok(walkDTO);
        }


        // DELETE A WALK BY ID

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
        {
          var walkDomainModel = await  _walkRepository.DeelteWalkAsync(id);


           if( walkDomainModel == null)
            {
                return NotFound();
            }
            // Map Domain model to DTO

           var walkDTO = _autoMapper.Map<WalkDTOResponse>( walkDomainModel);
            return Ok(walkDTO);

        }


    }
}
