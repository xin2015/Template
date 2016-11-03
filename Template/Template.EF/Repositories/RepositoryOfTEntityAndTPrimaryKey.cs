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
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        #region Select/Get/Query
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

        public T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return queryMethod(db.Set<TEntity>());
            }
        }

        #region First
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

        public TEntity FirstOrDefault(TPrimaryKey id)
        {
            return FirstOrDefault(CreateEqualityExpressionForId(id));
        }

        public Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return FirstOrDefaultAsync(CreateEqualityExpressionForId(id));
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity,bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().FirstOrDefault(predicate);
            }
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity,bool>> predicate)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                return db.Set<TEntity>().FirstOrDefaultAsync(predicate);
            }
        }
        #endregion

        #region Last
        public TEntity Last(TPrimaryKey id)
        {
            return Last(CreateEqualityExpressionForId(id));
        }

        public Task<TEntity> LastAsync(TPrimaryKey id)
        {
            return LastAsync(CreateEqualityExpressionForId(id));
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

        public TEntity LastOrDefault(TPrimaryKey id)
        {
            return LastOrDefault(CreateEqualityExpressionForId(id));
        }

        public Task<TEntity> LastOrDefaultAsync(TPrimaryKey id)
        {
            return LastOrDefaultAsync(CreateEqualityExpressionForId(id));
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
        public TEntity Single(TPrimaryKey id)
        {
            return Single(CreateEqualityExpressionForId(id));
        }

        public Task<TEntity> SingleAsync(TPrimaryKey id)
        {
            return SingleAsync(CreateEqualityExpressionForId(id));
        }

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

        public TEntity SingleOrDefault(TPrimaryKey id)
        {
            return SingleOrDefault(CreateEqualityExpressionForId(id));
        }

        public Task<TEntity> SingleOrDefaultAsync(TPrimaryKey id)
        {
            return SingleOrDefaultAsync(CreateEqualityExpressionForId(id));
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

        #endregion

        #region Add
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
        #endregion

        #region AddOrUpdate
        public int AddOrUpdate(TEntity entity)
        {
            using (DefaultDbContext db = new DefaultDbContext())
            {
                TEntity data = db.Set<TEntity>().FirstOrDefault(CreateEqualityExpressionForId(entity.Id));
                if (data == null) db.Set<TEntity>().Add(entity);
                else db.Entry(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public Task<int> AddOrUpdateAsync(TEntity entity)
        {
            TEntity data = FirstOrDefault(entity.Id);
            if (data == null) return AddAsync(entity);
            else return UpdateAsync(entity);
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
