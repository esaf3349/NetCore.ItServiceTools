using MediatR;

namespace CommandsService.Application.Models.Common
{
    public abstract class GetAllBaseQuery<TViewModel> : IRequest<TViewModel>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
