namespace CommandsService.Application.Common.Interfaces
{
    public interface IGetAllQuery
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}
