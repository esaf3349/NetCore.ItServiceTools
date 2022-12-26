using AutoMapper;
using ApplicationDtos = PlatformService.Application.Dtos.Platforms;
using PortsDtos = PlatformService.Infrastructure.Interfaces;

namespace PlatformService.Infrastructure.Implementation.MappingProfiles
{
    internal class PlatformsMappingProfile : Profile
    {
        public PlatformsMappingProfile()
        {
            CreateMap<ApplicationDtos.PlatformsGetAllDto, PortsDtos.PlatformsGetAllDto>();
        }
    }
}
