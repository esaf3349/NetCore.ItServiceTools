using CommandsService.Core.Entities;
using CommandsService.Persistence.EntityFramework.EntityConfigs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommandsService.Persistence.EntityFramework.EntityConfigs
{
    public class CommandEntityConfig : BaseEntityConfig<Command>
    {
        public override void Configure(EntityTypeBuilder<Command> builder)
        {
            base.Configure(builder);

            builder.Property(command => command.Subject)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(command => command.Expression)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(command => command.Platform)
                .WithMany(platform => platform.Commands)
                .HasForeignKey(command => command.PlatformId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
