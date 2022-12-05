using CommandsService.Core.Entities.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CommandsService.Persistence.EntityFramework.EntityConfigs.Common
{
    public abstract class BaseEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.IsDeleted).IsRequired();
        }
    }
}
