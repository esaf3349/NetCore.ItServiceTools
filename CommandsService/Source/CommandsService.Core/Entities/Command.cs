using CommandsService.Core.Entities.Common;

namespace CommandsService.Core.Entities
{
    public class Command : BaseEntity
    {
        public string Subject { get; set; }
        public string Expression { get; set; }

        public int PlatformId { get; set; }

        public Platform Platform { get; set; }
    }
}
