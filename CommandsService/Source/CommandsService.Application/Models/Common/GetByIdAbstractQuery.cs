using CommandsService.Application.Common.Interfaces;
using MediatR;

namespace CommandsService.Application.Models.Common
{
    public abstract class GetByIdAbstractQuery<TViewModel> : IRequest<TViewModel>, IGetByIdQuery
    {
        public int Id { get; set; }
    }
}
