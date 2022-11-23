using PlatformService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlatformService.Persistence.Interfaces.Repositories.Common
{
    public interface IGenericRepository<TEntity> where TEntity : IIntKeyIdentifiable
    {
        Task<bool> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(int id);
        Task<TEntity> GetOne(int id);
        Task<TEntity> GetOne(Expression<Func<TEntity, bool>> filter);
        Task<IEnumerable<TEntity>> GetMany(Expression<Func<TEntity, bool>> filter, int pageNumber, int pageSize);
    }
}
