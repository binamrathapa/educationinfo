using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationInfo.Core
{
    public interface IRepositoryQuery<TEntity> where TEntity : class
    {
        IRepositoryQuery<TEntity> Filter(Expression<Func<TEntity, bool>> filter);
        IRepositoryQuery<TEntity> OrderBy(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
        IRepositoryQuery<TEntity> Include(Expression<Func<TEntity, object>> expression);
        IQueryable<TEntity> Get();
        Task<IEnumerable<TEntity>> GetAsync();
        /* IEnumerable<TEntity> GetPage(int page, int pageSize, out int totalCount);         
         
         IQueryable<TEntity> SqlQuery(string query, params object[] parameters);*/
    }
}