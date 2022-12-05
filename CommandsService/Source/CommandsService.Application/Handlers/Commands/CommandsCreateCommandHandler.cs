using AutoMapper;
using CommandsService.Application.Models.Commands;
using CommandsService.Core.Entities;
using CommandsService.Persistence.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsService.Application.Handlers.Commands
{
    internal class CommandsCreateCommandHandler : IRequestHandler<CommandsCreateCommand, int>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CommandsCreateCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<int> Handle(CommandsCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Command>(request);

            entity.IsDeleted = false;

            _uow.Commands.Add(entity);

            await _uow.CommitAsync(cancellationToken);

            return entity.Id;
        }
    }
}
