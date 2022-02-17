
namespace SchoolMngr.Services.Backoffice.DAL.Repository
{
    using Codeit.Enterprise.Base.Abstractions.DataAccess;
    using Codeit.Enterprise.Base.Abstractions.DomainModel;
    using Codeit.Enterprise.Base.DataAccess;
    using Codeit.Enterprise.Base.DomainModel;
    using Microsoft.EntityFrameworkCore;
    using SchoolMngr.Services.Backoffice.DAL.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    public class BackofficeEFRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity<Guid>
    {
        protected readonly BackofficeDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BackofficeEFRepository(BackofficeDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<IQueryable<TEntity>> AllAsync(CancellationToken cancellationToken = default)
        {
            return await AllAsync(null, null, cancellationToken, null);
        }

        public async Task<IQueryable<TEntity>> AllAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy, CancellationToken cancellationToken = default, params Expression<Func<IIncludable<TEntity>, IIncludable>>[] includes)
        {
            try
            {
                return await Task.Run(() =>
                {
                    IQueryable<TEntity> entities = _dbSet.IncludeMultiple(includes).AsNoTracking();

                    if (predicate != null)
                    {
                        entities = entities.Where(predicate);
                    }

                    return orderBy != null ? orderBy(entities) : entities;
                }, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex);
            }
        }

        public async Task<IPagedListEntity<TEntity>> AllPagedAsync(int skip, int take, int pageSize, int currentPage,
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            CancellationToken cancellationToken = default,
            params Expression<Func<IIncludable<TEntity>, IIncludable>>[] includes)
        {
            try
            {
                IQueryable<TEntity> entities = _dbSet.IncludeMultiple(includes).AsNoTracking();

                if (predicate != null)
                {
                    entities = entities.Where(predicate);
                }

                var totalCount = entities.Count();
                var totalPages = Math.Ceiling((double)totalCount / pageSize);

                return await Task.Run(() =>
                {
                    return new PagedListEntity<TEntity>
                    {
                        PagedEntities = orderBy != null
                            ? orderBy(entities).Skip(skip).Take(take)
                            : entities.Skip(skip).Take(take),
                        CollectionLength = totalCount,
                        CurrentPage = currentPage,
                        RowsPerPage = pageSize,
                        TotalPages = totalPages
                    };
                }, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex);
            }
        }

        public async Task<TEntity> FindAsync(Guid pId)
        {
            return await FindAsync(x => x.Id.Equals(pId));
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<IIncludable<TEntity>, IIncludable>>[] includes)
        {
            try
            {
                return await _dbSet.IncludeMultiple(includes).AsNoTracking()
                        .FirstOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex);
            }
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex);
            }
        }

        public async Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex);
            }
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            try
            {
                var result = await Task.Run(() => _dbSet.Add(entity));
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            TEntity entity = await GetByIdAsync(id);
            await DeleteAsync(entity);
        }

        public async Task DeleteAsync(TEntity entityToDelete)
        {
            try
            {
                //Remove logically
                if (entityToDelete is IDeleteableEntity entity)
                {
                    entity.Deleted = true;
                    await UpdateAsync(entityToDelete);
                }
                else
                {
                    await Task.Run(() =>
                    {
                        _dbSet.Attach(entityToDelete);
                        _dbSet.Remove(entityToDelete);
                    });
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex);
            }
        }

        public async Task UpdateAsync(TEntity entityToUpdate)
        {
            try
            {
                //To avoid error due EF is already traking this entity 
                var trackedEntity = _dbContext.ChangeTracker.Entries<TEntity>()
                    .SingleOrDefault(e => e.Entity.Id == entityToUpdate.Id && e.State != EntityState.Detached);
                if (trackedEntity != null)
                    trackedEntity.State = EntityState.Detached;

                await Task.Run(() =>
                {
                    _dbContext.Update(entityToUpdate);
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex);
            }
        }

        public async Task<int> GetCountAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCountByExpressionAsync(null, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex);
            }
        }

        public async Task<int> GetCountByExpressionAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbSet.CountAsync(predicate, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex);
            }
        }

        public async Task<IQueryable<TEntity>> ExecuteQueryAsync(string query, CancellationToken cancellationToken = default, params object[] paramaters)
        {
            try
            {
                return await Task.Run(() => _dbSet.FromSqlRaw(query, paramaters), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex);
            }
        }

        public async Task<List<TEntity>> ExecSp(string spName, CancellationToken cancellationToken = default, params object[] parameters)
        {
            try
            {
                var tEntity = new List<TEntity>();
                var spResult = await Task.Run(() => _dbSet.FromSqlRaw($"EXEC {spName}", parameters), cancellationToken);
                foreach (var item in spResult)
                {
                    tEntity.Add(item);
                }

                return tEntity;
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex);
            }
        }

        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbSet.AnyAsync(predicate, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new DataAccessLayerException(ex);
            }
        }
    }
}
