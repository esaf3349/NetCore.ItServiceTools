using PlatformService.Core.Interfaces;

namespace PlatformService.Core.Entities.Common
{
    public class BaseEntity : IIntKeyIdentifiable, ISoftDeletable
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
