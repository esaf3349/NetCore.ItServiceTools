using MediatR;

namespace CommandsService.Application.Models.Common
{
    public abstract class GetByIdBaseQuery<TViewModel> : IRequest<TViewModel>
    {
        public int Id { get; set; }
    }
}
