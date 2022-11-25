using Microsoft.EntityFrameworkCore;
using PlatformService.Persistence.EntityFramework.Repositories;
using PlatformService.Persistence.Interfaces;
using PlatformService.Persistence.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Persistence.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private bool _isDisposed = false;

        public IPlatformRepository Platforms { get; private set; }

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

            Platforms = new PlatformRepository(appDbContext);
        }

        public async Task CommitAsync(CancellationToken cancellatonToken)
        {
            await _appDbContext.SaveChangesAsync(cancellatonToken);
        }

        protected virtual void Cleanup(bool isDisposing)
        {
            if (_isDisposed)
                return;

            if (isDisposing)
                _appDbContext.Dispose();

            _isDisposed = true;
        }

        public void Dispose()
        {
            Cleanup(true);
            GC.SuppressFinalize(this);
        }
    }
}
