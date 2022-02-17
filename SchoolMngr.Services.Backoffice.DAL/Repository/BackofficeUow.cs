
namespace SchoolMngr.Services.Backoffice.DAL.Repository
{
    using Codeit.Enterprise.Base.Abstractions;
    using Codeit.Enterprise.Base.Abstractions.DataAccess;
    using Codeit.Enterprise.Base.Abstractions.DomainModel;
    using Codeit.Enterprise.Base.DataAccess;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;
    using SchoolMngr.Services.Backoffice.DAL.Context;
    using System;
    using System.Threading; 
    using System.Threading.Tasks;

    public class BackofficeUow : IApplicationUow
    {
        private readonly BackofficeDbContext _dbContext;
        private readonly IRepositoryProvider<BackofficeDbContext> _repositoryProvider;
        private readonly ILogger<BackofficeUow> _logger;

        public BackofficeUow(
            BackofficeDbContext context,
            IRepositoryProvider<BackofficeDbContext> repositoryProvider,
            ILoggerFactory loggerFactory)
        {
            _dbContext = context;
            _repositoryProvider = repositoryProvider;
            _logger = (loggerFactory ?? NullLoggerFactory.Instance).CreateLogger<BackofficeUow>();
        }

        //Call dispose method on destructuring
        ~BackofficeUow() => Dispose(false);

        public bool Commit()
        {
            try
            {
                _logger.LogInformation("Unit of work Commited");
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex);
            }
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInformation("Unit of work Commited");
                return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex);
            }
        }

        public IDbContextTransaction StartTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> StartTransactionAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity<Guid>
        {
            try
            {
                _logger.LogInformation($"Getting repository entity of type {typeof(TEntity)}");
                return _repositoryProvider.GetRepositoryForEntityType<TEntity>();
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex);
            }
        }

        #region Disposable
        // To detect redundant calls
        private bool _disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _dbContext?.Dispose();
            }

            _disposed = true;
        }
        #endregion

    }
}
