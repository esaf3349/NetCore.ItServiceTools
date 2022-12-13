using AutoMapper;
using PlatformService.Application.Dtos.Platforms;
using PlatformService.Application.Models.Platforms;
using PlatformService.Application.ViewModels.Platforms;
using PlatformService.Core.Entities;
using PlatformService.Infrastructure.Interfaces.Dtos.Http.CommandsDataClient;
using PlatformService.Infrastructure.Interfaces.Dtos.MessageBus.MessageBusClient;

namespace PlatformService.Application.MappingProfiles
{
    internal class PlatformsMappingProfile : Profile
    {
        public PlatformsMappingProfile()
        {
            CreateAppMaps();
            CreateInfraMaps();
        }

        private void CreateAppMaps()
        {
            CreateMap<PlatformsCreateCommand, Platform>();
            CreateMap<Platform, PlatformsGetByIdVm>();
            CreateMap<Platform, PlatformsGetAllDto>();
        }

        private void CreateInfraMaps()
        {
            CreateMap<Platform, PlatformsCreateDto>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Platform, PlatformsPublishDto>();
        }
    }
}
