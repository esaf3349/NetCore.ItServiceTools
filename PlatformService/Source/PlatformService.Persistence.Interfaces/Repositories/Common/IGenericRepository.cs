using PlatformService.Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Persistence.Interfaces.Repositories.Common
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : IIntKeyIdentifiable
    {
        int Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> GetOneAsync(int id, CancellationToken cancellationToken);
        Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> filter, int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
