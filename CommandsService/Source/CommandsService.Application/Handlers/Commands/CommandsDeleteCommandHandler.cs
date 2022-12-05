using AutoMapper;
using CommandsService.Application.Common.Exceptions;
using CommandsService.Application.Models.Commands;
using CommandsService.Core.Entities;
using CommandsService.Persistence.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsService.Application.Handlers.Commands
{
    public class CommandsDeleteCommandHandler : IRequestHandler<CommandsDeleteCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CommandsDeleteCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CommandsDeleteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.Commands.GetOneAsync(filter => filter.Id == request.Id && filter.IsDeleted == false, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Command), request.Id);

            entity.IsDeleted = true;

            _uow.Commands.Update(entity);

            await _uow.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
