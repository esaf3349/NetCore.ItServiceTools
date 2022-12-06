using AutoMapper;
using CommandsService.Application.Common.Exceptions;
using CommandsService.Application.Models.Commands;
using CommandsService.Application.ViewModels.Commands;
using CommandsService.Core.Entities;
using CommandsService.Persistence.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsService.Application.Handlers.Commands
{
    public class CommandsGetByIdHandler : IRequestHandler<CommandsGetByIdQuery, CommandsGetByIdVm>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CommandsGetByIdHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CommandsGetByIdVm> Handle(CommandsGetByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _uow.Commands.GetOneAsync(filter => filter.Id == request.Id && filter.IsDeleted == false, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Command), request.Id);

            var vm = _mapper.Map<CommandsGetByIdVm>(entity);

            return vm;
        }
    }
}
