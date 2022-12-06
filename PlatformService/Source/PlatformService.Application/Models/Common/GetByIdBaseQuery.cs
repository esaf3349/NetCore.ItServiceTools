using MediatR;
using PlatformService.Application.Common.Interfaces;

namespace PlatformService.Application.Models.Common
{
    public abstract class GetByIdBaseQuery<TViewModel> : IRequest<TViewModel>, IGetByIdQuery
    {
        public int Id { get; set; }
    }
}
