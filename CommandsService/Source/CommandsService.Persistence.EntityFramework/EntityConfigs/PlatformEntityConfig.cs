using CommandsService.Core.Entities;
using CommandsService.Persistence.EntityFramework.EntityConfigs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommandsService.Persistence.EntityFramework.EntityConfigs
{
    public class PlatformEntityConfig : BaseEntityConfig<Platform>
    {
        public override void Configure(EntityTypeBuilder<Platform> builder)
        {
            base.Configure(builder);

            builder.Property(platform => platform.Name)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(platform => platform.ExternalId)
                .IsRequired();

            builder.HasIndex(c => new { c.Name, c.IsDeleted });
        }
    }
}
