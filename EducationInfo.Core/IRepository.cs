using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EducationInfo.Core
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int? Id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetBy(Func<TEntity, bool> predicate = null);        
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int Id);
        void Delete(TEntity entity);
        IRepositoryQuery<TEntity> Query();

    }
}