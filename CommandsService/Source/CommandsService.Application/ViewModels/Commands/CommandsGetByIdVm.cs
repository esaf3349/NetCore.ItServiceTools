namespace CommandsService.Application.ViewModels.Commands
{
    public class CommandsGetByIdVm
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Expression { get; set; }
        public int PlatformId { get; set; }
    }
}
