using AutoMapper;
using DEWalksAPI.Models.Domain;
using DEWalksAPI.Models.DTO;

namespace DEWalksAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Region
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();

            // Walk
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();

            // Difficulty
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
        }
    }
}
