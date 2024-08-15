using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles :Profile
    {

        public AutoMapperProfiles()
        {
            // Properties names must be same for mapping
            CreateMap<Region,RegionDTOResponse>().ReverseMap();
            CreateMap<RegionDTOAddRequest,Region>().ReverseMap();
            CreateMap<RegionDTOUpdateRequest, Region>().ReverseMap();

            // Walks

            CreateMap<Walk, WalkDTOAddRequest>().ReverseMap();
            CreateMap<Walk, WalkDTOResponse>().ReverseMap();
            CreateMap<Walk, WalkDTOUpdateRequest>().ReverseMap();

            // Difficulty

            CreateMap<Difficulty, DifficultyDTOResponse>().ReverseMap();

            
        }
    }
}
