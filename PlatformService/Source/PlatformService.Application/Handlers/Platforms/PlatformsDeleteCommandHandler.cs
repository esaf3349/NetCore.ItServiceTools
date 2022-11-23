﻿using AutoMapper;
using MediatR;
using PlatformService.Application.Common.Exceptions;
using PlatformService.Application.Models.Platforms;
using PlatformService.Core.Entities;
using PlatformService.Persistence.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Application.Handlers.Platforms
{
    public class PlatformsDeleteCommandHandler : IRequestHandler<PlatformsDeleteCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PlatformsDeleteCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(PlatformsDeleteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.Platforms.GetOne(filter => filter.Id == request.Id && filter.IsDeleted == false);

            if (entity == null)
                throw new NotFoundException(nameof(Platform), request.Id);

            entity.IsDeleted = true;

            await _uow.Platforms.Update(entity);
            await _uow.Commit(cancellationToken);

            return Unit.Value;
        }
    }
}
