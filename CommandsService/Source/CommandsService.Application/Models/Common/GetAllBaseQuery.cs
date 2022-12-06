using CommandsService.Application.Common.Interfaces;
using MediatR;

namespace CommandsService.Application.Models.Common
{
    public abstract class GetAllBaseQuery<TViewModel> : IRequest<TViewModel>, IGetAllQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
