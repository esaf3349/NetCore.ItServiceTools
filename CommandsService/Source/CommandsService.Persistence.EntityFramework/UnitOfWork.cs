using CommandsService.Persistence.Interfaces.Repositories;
using CommandsService.Persistence.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using CommandsService.Persistence.EntityFramework.Repositories;

namespace CommandsService.Persistence.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private bool _isDisposed = false;

        public ICommandRepository Commands { get; private set; }
        public IPlatformRepository Platforms { get; private set; }

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

            Commands = new CommandRepository(appDbContext);
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
