using AutoMapper;
using CommandsService.Application.Dtos.Platforms;
using CommandsService.Application.Models.Platforms;
using CommandsService.Application.ViewModels.Platforms;
using CommandsService.Core.Entities;

namespace CommandsService.Application.MappingProfiles
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

        }
    }
}
