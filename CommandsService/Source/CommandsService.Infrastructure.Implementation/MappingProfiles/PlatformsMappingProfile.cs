using AutoMapper;
using CommandsService.Application.Models.Platforms;
using CommandsService.Infrastructure.Implementation.Dtos;

namespace CommandsService.Infrastructure.Implementation.MappingProfiles
{
    internal class PlatformsMappingProfile : Profile
    {
        public PlatformsMappingProfile()
        {
            CreateMap<PlatformsCreateEventDto, PlatformsCreateCommand>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
