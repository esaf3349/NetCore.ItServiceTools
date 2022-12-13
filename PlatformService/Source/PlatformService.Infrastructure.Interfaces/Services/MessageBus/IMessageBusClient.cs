using PlatformService.Infrastructure.Interfaces.Dtos.MessageBus.MessageBusClient;
using System;

namespace PlatformService.Infrastructure.Interfaces.Services.MessageBus
{
    public interface IMessageBusClient : IDisposable
    {
        void PlatformsPublish(PlatformsPublishDto platform);
    }
}
