using CommandsService.Core.Interfaces;

namespace CommandsService.Core.Entities.Common
{
    public class BaseEntity : IIntKeyIdentifiable, ISoftDeletable
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
