using AutoMapper;
using CommandsService.Application.Dtos.Commands;
using CommandsService.Application.Models.Commands;
using CommandsService.Application.ViewModels.Commands;
using CommandsService.Core.Entities;

namespace CommandsService.Application.MappingProfiles
{
    internal class CommandsMappingProfile : Profile
    {
        public CommandsMappingProfile()
        {
            CreateAppMaps();
            CreateInfraMaps();
        }

        private void CreateAppMaps()
        {
            CreateMap<CommandsCreateCommand, Command>();
            CreateMap<Command, CommandsGetByIdVm>();
            CreateMap<Command, CommandsGetAllDto>();
        }

        private void CreateInfraMaps()
        {

        }
    }
}
