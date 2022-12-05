using CommandsService.Core.Entities.Common;
using System.Collections.Generic;

namespace CommandsService.Core.Entities
{
    public class Platform : BaseEntity
    {
        public int ExternalId { get; set; }
        public string Name { get; set; }

        public ICollection<Command> Commands { get; set; } = new HashSet<Command>();
    }
}
