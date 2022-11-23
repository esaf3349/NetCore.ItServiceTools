﻿using AutoMapper;
using MediatR;
using PlatformService.Application.Models.Platforms;
using PlatformService.Core.Entities;
using PlatformService.Persistence.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Application.Handlers.Platforms
{
    public class PlatformsCreateCommandHandler : IRequestHandler<PlatformsCreateCommand, int>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PlatformsCreateCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<int> Handle(PlatformsCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Platform>(request);

            entity.IsDeleted = false;

            await _uow.Platforms.Add(entity);
            await _uow.Commit(cancellationToken);

            return entity.Id;
        }
    }
}