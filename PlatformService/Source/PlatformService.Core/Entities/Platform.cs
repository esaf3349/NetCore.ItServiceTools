using PlatformService.Core.Entities.Common;

namespace PlatformService.Core.Entities
{
    public class Platform : BaseEntity
    {
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Cost { get; set; }
    }
}
