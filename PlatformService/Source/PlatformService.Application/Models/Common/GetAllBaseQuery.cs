using MediatR;
using PlatformService.Application.Common.Interfaces;

namespace PlatformService.Application.Models.Common
{
    public abstract class GetAllBaseQuery<TViewModel> : IRequest<TViewModel>, IGetAllQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
