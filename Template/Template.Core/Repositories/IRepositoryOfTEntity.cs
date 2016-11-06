using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Template.Core.Entities;

namespace Template.Core.Repositories
{
    /// <summary>
    /// A shortcut of <see cref="IRepository{TEntity,TPrimaryKey}"/> for most used primary key type (<see cref="int"/>).
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : class, IEntity<int>
    {

    }

    /// <summary>
    /// This interface is implemented by all repositories to ensure implementation of fixed methods.
    /// </summary>
    /// <typeparam name="TEntity">Main Entity type this repository works on</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        #region Create/Add
        int Add(TEntity entity);

        Task<int> AddAsync(TEntity entity);

        int AddRange(IEnumerable<TEntity> entities);

        Task<int> AddRangeAsync(IEnumerable<TEntity> entities);
        #endregion

        #region Retrieve
        #region First And FirstOrDefault
        TEntity First();

        Task<TEntity> FirstAsync();

        TEntity First(TPrimaryKey id);

        Task<TEntity> FirstAsync(TPrimaryKey id);

        TEntity First(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity FirstOrDefault();

        Task<TEntity> FirstOrDefaultAsync();

        TEntity FirstOrDefault(TPrimaryKey id);

        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region Last
        TEntity Last();

        Task<TEntity> LastAsync();

        TEntity Last(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> LastAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity LastOrDefault();

        Task<TEntity> LastOrDefaultAsync();

        TEntity LastOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region Single
        TEntity Single(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region GetAllList And GetList
        List<TEntity> GetAllList();

        Task<List<TEntity>> GetAllListAsync();

        List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);

        List<TEntity> GetList(Func<IQueryable<TEntity>, IQueryable<TEntity>> func);

        Task<List<TEntity>> GetListAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func);
        #endregion
        #endregion

        #region Update
        int Update(TEntity entity);

        Task<int> UpdateAsync(TEntity entity);

        int UpdateFirst(TEntity entity, Expression<Func<TEntity, bool>> predicate);

        Task<int> UpdateFirstAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate);

        int UpdateFirstOrNot(TEntity entity, Expression<Func<TEntity, bool>> predicate);

        Task<int> UpdateFirstAsyncOrNot(TEntity entity, Expression<Func<TEntity, bool>> predicate);

        int UpdateRange(IEnumerable<TEntity> entities);

        Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities);
        #endregion

        #region Delete/Remove
        int Remove(TEntity entity);

        Task<int> RemoveAsync(TEntity entity);

        int Remove(TPrimaryKey id);

        Task<int> RemoveAsync(TPrimaryKey id);

        int RemoveFirst(Expression<Func<TEntity, bool>> predicate);

        Task<int> RemoveFirstAsync(Expression<Func<TEntity, bool>> predicate);

        int RemoveFirstOrNot(Expression<Func<TEntity, bool>> predicate);

        Task<int> RemoveFirstOrNotAsync(Expression<Func<TEntity, bool>> predicate);

        int RemoveRange(IEnumerable<TEntity> entities);

        Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities);

        int RemoveRange(Expression<Func<TEntity, bool>> predicate);

        Task<int> RemoveRangeAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region Aggregates/Count
        int Count();

        Task<int> CountAsync();

        int Count(Expression<Func<TEntity, bool>> predicate);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        long LongCount();

        Task<long> LongCountAsync();

        long LongCount(Expression<Func<TEntity, bool>> predicate);

        Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion
    }
}
