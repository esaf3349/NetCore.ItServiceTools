using CommandsService.Core.Entities.Common;
using CommandsService.Persistence.Interfaces.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsService.Persistence.EntityFramework.Repositories.Common
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected AppDbContext _dbContext;
        protected DbSet<TEntity> _dbSet;
        private bool _isDisposed = false;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual int Add(TEntity entity)
        {
            _dbSet.Add(entity);

            return entity.Id;
        }

        public virtual void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task<TEntity> GetOneAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public virtual async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FirstAsync(filter, cancellationToken);
        }

        public virtual async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> filter, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(filter).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        }

        protected virtual void Cleanup(bool isDisposing)
        {
            if (_isDisposed)
                return;

            if (isDisposing)
                _dbContext.Dispose();

            _isDisposed = true;
        }

        public void Dispose()
        {
            Cleanup(true);
            GC.SuppressFinalize(this);
        }
    }
}
