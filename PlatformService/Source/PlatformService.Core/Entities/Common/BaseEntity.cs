using PlatformService.Core.Common.Interfaces;

namespace PlatformService.Core.Entities.Common
{
    public class BaseEntity : IIntKeyIdentifiable, ISoftDeletable
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
