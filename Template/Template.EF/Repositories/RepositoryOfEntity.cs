using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Template.Core.Entities;
using Template.Core.Repositories;

namespace Template.EF.Repositories
{
    public class Repository<TEntity> : Repository<TEntity, int> where TEntity : Entity
    {

    }

    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        #region Create/Add
        public int Add(TEntity entity)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                db.Set<TEntity>().Add(entity);
                return db.SaveChanges();
            }
        }

        public Task<int> AddAsync(TEntity entity)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                db.Set<TEntity>().Add(entity);
                return db.SaveChangesAsync();
            }
        }

        public int AddRange(IEnumerable<TEntity> entities)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                db.Set<TEntity>().AddRange(entities);
                return db.SaveChanges();
            }
        }

        public Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                db.Set<TEntity>().AddRange(entities);
                return db.SaveChangesAsync();
            }
        }
        #endregion

        #region Retrieve
        #region First And FirstOrDefault
        public TEntity First()
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().First();
            }
        }

        public Task<TEntity> FirstAsync()
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().FirstAsync();
            }
        }

        public TEntity First(TPrimaryKey id)
        {
            return First(CreateEqualityExpressionForId(id));
        }

        public Task<TEntity> FirstAsync(TPrimaryKey id)
        {
            return FirstAsync(CreateEqualityExpressionForId(id));
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().First(predicate);
            }
        }

        public Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().FirstAsync(predicate);
            }
        }

        public TEntity FirstOrDefault()
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().FirstOrDefault();
            }
        }

        public Task<TEntity> FirstOrDefaultAsync()
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().FirstOrDefaultAsync();
            }
        }

        public TEntity FirstOrDefault(TPrimaryKey id)
        {
            return FirstOrDefault(CreateEqualityExpressionForId(id));
        }

        public Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return FirstOrDefaultAsync(CreateEqualityExpressionForId(id));
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().FirstOrDefault(predicate);
            }
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().FirstOrDefaultAsync(predicate);
            }
        }
        #endregion

        #region Last
        public TEntity Last()
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().Last();
            }
        }

        public Task<TEntity> LastAsync()
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().Reverse().FirstAsync();
            }
        }

        public TEntity Last(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().Last(predicate);
            }
        }

        public Task<TEntity> LastAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().Reverse().FirstAsync(predicate);
            }
        }

        public TEntity LastOrDefault()
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().LastOrDefault();
            }
        }

        public Task<TEntity> LastOrDefaultAsync()
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().Reverse().FirstOrDefaultAsync();
            }
        }

        public TEntity LastOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().LastOrDefault(predicate);
            }
        }

        public Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().Reverse().FirstOrDefaultAsync(predicate);
            }
        }
        #endregion

        #region Single
        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().Single(predicate);
            }
        }

        public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().SingleAsync(predicate);
            }
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().SingleOrDefault(predicate);
            }
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().SingleOrDefaultAsync(predicate);
            }
        }
        #endregion

        #region GetAllList And GetList
        public List<TEntity> GetAllList()
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().ToList();
            }
        }

        public Task<List<TEntity>> GetAllListAsync()
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().ToListAsync();
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().Where(predicate).ToList();
            }
        }

        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().Where(predicate).ToListAsync();
            }
        }

        public List<TEntity> GetList(Func<IQueryable<TEntity>, IQueryable<TEntity>> func)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return func(db.Set<TEntity>()).ToList();
            }
        }

        public Task<List<TEntity>> GetListAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return func(db.Set<TEntity>()).ToListAsync();
            }
        }
        #endregion
        #endregion

        #region Update
        public int Update(TEntity entity)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChangesAsync();
            }
        }

        public int UpdateFirst(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                TEntity data = db.Set<TEntity>().First(predicate);
                entity.Id = data.Id;
                db.Entry(data).State = EntityState.Detached;
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public Task<int> UpdateFirstAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                TEntity data = db.Set<TEntity>().First(predicate);
                entity.Id = data.Id;
                db.Entry(data).State = EntityState.Detached;
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChangesAsync();
            }
        }

        public int UpdateFirstOrNot(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                TEntity data = db.Set<TEntity>().FirstOrDefault(predicate);
                int result;
                if (data == null)
                {
                    result = 0;
                }
                else
                {
                    entity.Id = data.Id;
                    db.Entry(data).State = EntityState.Detached;
                    db.Entry(entity).State = EntityState.Modified;
                    result = db.SaveChanges();
                }
                return result;
            }
        }

        public Task<int> UpdateFirstAsyncOrNot(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                TEntity data = db.Set<TEntity>().FirstOrDefault(predicate);
                Task<int> result;
                if (data == null)
                {
                    result = Task.FromResult(0);
                }
                else
                {
                    entity.Id = data.Id;
                    db.Entry(data).State = EntityState.Detached;
                    db.Entry(entity).State = EntityState.Modified;
                    result = db.SaveChangesAsync();
                }
                return result;
            }
        }

        public int UpdateRange(IEnumerable<TEntity> entities)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                foreach (TEntity entity in entities)
                {
                    db.Entry(entity).State = EntityState.Modified;
                }
                return db.SaveChanges();
            }
        }

        public Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                foreach (TEntity entity in entities)
                {
                    db.Entry(entity).State = EntityState.Modified;
                }
                return db.SaveChangesAsync();
            }
        }
        #endregion

        #region Delete/Remove
        public int Remove(TEntity entity)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                db.Set<TEntity>().Remove(entity);
                return db.SaveChanges();
            }
        }

        public Task<int> RemoveAsync(TEntity entity)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                db.Set<TEntity>().Remove(entity);
                return db.SaveChangesAsync();
            }
        }

        public int Remove(TPrimaryKey id)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                TEntity entity = db.Set<TEntity>().First(CreateEqualityExpressionForId(id));
                db.Set<TEntity>().Remove(entity);
                return db.SaveChanges();
            }
        }

        public Task<int> RemoveAsync(TPrimaryKey id)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                TEntity entity = db.Set<TEntity>().First(CreateEqualityExpressionForId(id));
                db.Set<TEntity>().Remove(entity);
                return db.SaveChangesAsync();
            }
        }

        public int RemoveFirst(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                TEntity entity = db.Set<TEntity>().First(predicate);
                db.Set<TEntity>().Remove(entity);
                return db.SaveChanges();
            }
        }

        public Task<int> RemoveFirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                TEntity entity = db.Set<TEntity>().First(predicate);
                db.Set<TEntity>().Remove(entity);
                return db.SaveChangesAsync();
            }
        }

        public int RemoveFirstOrNot(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                TEntity entity = db.Set<TEntity>().FirstOrDefault(predicate);
                int result;
                if (entity == null)
                {
                    result = 0;
                }
                else
                {
                    db.Set<TEntity>().Remove(entity);
                    result = db.SaveChanges();
                }
                return result;
            }
        }

        public Task<int> RemoveFirstOrNotAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                TEntity entity = db.Set<TEntity>().FirstOrDefault(predicate);
                Task<int> result;
                if (entity == null)
                {
                    result = Task.FromResult(0);
                }
                else
                {
                    db.Set<TEntity>().Remove(entity);
                    result = db.SaveChangesAsync();
                }
                return result;
            }
        }

        public int RemoveRange(IEnumerable<TEntity> entities)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                db.Set<TEntity>().RemoveRange(entities);
                return db.SaveChanges();
            }
        }

        public Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                db.Set<TEntity>().RemoveRange(entities);
                return db.SaveChangesAsync();
            }
        }

        public int RemoveRange(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                var entities = db.Set<TEntity>().Where(predicate);
                db.Set<TEntity>().RemoveRange(entities);
                return db.SaveChanges();
            }
        }

        public Task<int> RemoveRangeAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                var entities = db.Set<TEntity>().Where(predicate);
                db.Set<TEntity>().RemoveRange(entities);
                return db.SaveChangesAsync();
            }
        }
        #endregion

        #region Aggregates/Count
        public int Count()
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().Count();
            }
        }

        public Task<int> CountAsync()
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().CountAsync();
            }
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().Count(predicate);
            }
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().CountAsync(predicate);
            }
        }

        public long LongCount()
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().LongCount();
            }
        }

        public Task<long> LongCountAsync()
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().LongCountAsync();
            }
        }

        public long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().LongCount(predicate);
            }
        }

        public Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().LongCountAsync(predicate);
            }
        }
        #endregion
        protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TPrimaryKey))
                );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
    }
}
