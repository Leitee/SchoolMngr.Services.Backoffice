/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.DAL.Repository
{
    using Microsoft.EntityFrameworkCore.Storage;
    using Pandora.NetStdLibrary.Base.Abstractions;
    using Pandora.NetStdLibrary.Base.Abstractions.DataAccess;
    using Pandora.NetStdLibrary.Base.Abstractions.DomainModel;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class ApplicationUow<TContext> : IApplicationUow, IDisposable where TContext : SchoolDbContext
    {
        private readonly TContext _dbContext;
        private readonly IRepositoryProvider<TContext> _repositoryProvider;

        public ApplicationUow(TContext context, IRepositoryProvider<TContext> repositoryProvider)
        {
            _dbContext = context;
            _repositoryProvider = repositoryProvider;
        }

        /// <summary>
        /// Save pending changes to the database and return true if there was at least 1 row affected
        /// </summary>
        public bool Commit()
        {
            //System.Diagnostics.Debug.WriteLine("Committed");
            return _dbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// Save pending changes to the database asyncly and return the amount of affected rows
        /// </summary>
        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// For transaction handling
        /// </summary>
        /// <returns></returns>
        public IDbContextTransaction StartTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        /// <summary>
        /// For transaction handling asyncly
        /// </summary>
        /// <returns></returns>
        public async Task<IDbContextTransaction> StartTransactionAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }

        #region IDisposable
        //TODO: see Dispose pattern
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext?.Dispose();
            }
            disposed = true;
        }
        #endregion

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity
        {
            return _repositoryProvider.GetRepositoryForEntityType<TEntity>();
        }

        public T GetIdentityRepo<T>() where T : class
        {
            return _repositoryProvider.GetRepository<T>();
        }
    }
}
