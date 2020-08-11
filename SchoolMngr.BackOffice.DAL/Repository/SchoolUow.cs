/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.DAL.Repository
{
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.Logging;
    using Pandora.NetStdLibrary.Base.Abstractions;
    using Pandora.NetStdLibrary.Base.Abstractions.DataAccess;
    using Pandora.NetStdLibrary.Base.Abstractions.DomainModel;
    using System;
    using System.Threading.Tasks;

    public class SchoolUow : IApplicationUow, IDisposable
    { 
        private readonly SchoolDbContext _dbContext;
        private readonly IEFRepositoryProvider<SchoolDbContext> _repositoryProvider;
        private readonly ILogger<SchoolUow> _logger;

        public SchoolUow(
            SchoolDbContext context,
            IEFRepositoryProvider<SchoolDbContext> repositoryProvider,
            ILogger<SchoolUow> logger)
        {
            _dbContext = context;
            _repositoryProvider = repositoryProvider;
            _logger = logger;
        }

        public bool Commit()
        {
            ///TODO: manage auditable entities on commit
            _logger.LogInformation("Unit of work Commited");
            return _dbContext.SaveChanges() > 0;
        }

        public async Task<bool> CommitAsync()
        {
            _logger.LogInformation("Unit of work Commited");
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public IDbContextTransaction StartTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> StartTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity
        {
            _logger.LogInformation($"Getting repository entity of type {typeof(TEntity)}");
            return _repositoryProvider.GetEFRepositoryForEntityType<TEntity>();
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

    }
}
