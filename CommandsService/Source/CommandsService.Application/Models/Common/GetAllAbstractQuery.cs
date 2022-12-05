using CommandsService.Application.Common.Interfaces;
using MediatR;

namespace CommandsService.Application.Models.Common
{
    public abstract class GetAllAbstractQuery<TViewModel> : IRequest<TViewModel>, IGetAllQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
