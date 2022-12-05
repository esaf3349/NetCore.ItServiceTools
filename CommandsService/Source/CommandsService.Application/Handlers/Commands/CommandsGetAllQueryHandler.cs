using AutoMapper;
using CommandsService.Application.Dtos.Commands;
using CommandsService.Application.Models.Commands;
using CommandsService.Application.ViewModels.Commands;
using CommandsService.Persistence.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsService.Application.Handlers.Commands
{
    internal class CommandsGetAllQueryHandler : IRequestHandler<CommandsGetAllQuery, CommandsGetAllVm>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CommandsGetAllQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CommandsGetAllVm> Handle(CommandsGetAllQuery request, CancellationToken cancellationToken)
        {
            if (request.PageNumber < 1) request.PageNumber = 1;
            if (request.PageSize < 1) request.PageSize = 20;

            var commands = await _uow.Commands.GetManyAsync(filter => filter.IsDeleted == false, request.PageNumber, request.PageSize, cancellationToken);
            var dtos = _mapper.Map<IEnumerable<CommandsGetAllDto>>(commands).ToArray();
            var vm = new CommandsGetAllVm
            {
                Commands = dtos
            };

            return vm;
        }
    }
}
