using AutoMapper;
using CommandsService.Application.Models.Platforms;
using CommandsService.Infrastructure.Implementation.Dtos;

namespace CommandsService.Entry.MappingProfiles.MessageBus
{
    internal class RabbitMqMappingProfile : Profile
    {
        public RabbitMqMappingProfile()
        {
            CreateMap<PlatformsCreateEventDto, PlatformsCreateCommand>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
