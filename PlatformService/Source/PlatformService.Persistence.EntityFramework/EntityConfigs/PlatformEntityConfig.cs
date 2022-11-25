using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatformService.Core.Entities;
using PlatformService.Persistence.EntityFramework.EntityConfigs.Common;

namespace PlatformService.Persistence.EntityFramework.EntityConfigs
{
    public class PlatformEntityConfig : BaseEntityConfig<Platform>
    {
        public override void Configure(EntityTypeBuilder<Platform> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Publisher)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Cost)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
