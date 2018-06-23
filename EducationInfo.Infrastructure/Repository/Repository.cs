#region

using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using EducationInfo.Core;
using Microsoft.EntityFrameworkCore;


#endregion

namespace EducationInfo.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly EducationInfoContext context;
        private readonly DbSet<TEntity> dbSet;
        
        public Repository(EducationInfoContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public TEntity GetById(int? Id)
        {
           return dbSet.Find(Id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbSet.AsNoTracking();
        }
        public IQueryable<TEntity> GetBy(Func<TEntity, bool> predicate = null)
        {
            if (predicate != null)
            {
                return dbSet.Where(predicate).AsQueryable();
            }

            return dbSet.AsNoTracking();
        }        
        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public void Delete(int Id)
        {
            var entity = dbSet.Find(Id);
            Delete(entity);
        }
        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }
        public virtual IRepositoryQuery<TEntity> Query()
        {
            var repositoryGetFluentHelper = new RepositoryQuery<TEntity>(this);
            return repositoryGetFluentHelper;
        }

        internal IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includeProperties = null,
            int? page = null,
            int? pageSize = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (includeProperties != null)
                includeProperties.ForEach(i => query = query.Include(i));

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            if (page != null && pageSize != null)
                query = query
                    .Skip((page.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value);

            return query;
        }
        internal async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includeProperties = null,
            int? page = null,
            int? pageSize = null)
        {
            return Get(filter, orderBy, includeProperties, page, pageSize).AsEnumerable();
        }

    }
}
