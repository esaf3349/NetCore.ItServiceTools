namespace CommandsService.Application.Dtos.Commands
{
    public class CommandsGetAllDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Expression { get; set; }
        public int PlatformId { get; set; }
    }
}
