using AutoMapper;
using ApplicationRequests = CommandsService.Application.Models.Platforms;
using PortsDtos = CommandsService.Infrastructure.Interfaces;

namespace CommandsService.Infrastructure.Implementation.MappingProfiles
{
    internal class PlatformsMappingProfile : Profile
    {
        public PlatformsMappingProfile()
        {
            CreateMap<PortsDtos.PlatformsGetAllDto, ApplicationRequests.PlatformsCreateCommand>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
