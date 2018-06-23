#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EducationInfo.Core;
using EducationInfo.Core.Entities;


#endregion

namespace EducationInfo.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Fields

        private readonly EducationInfoContext context;
        
        private bool _disposed;
        private Hashtable _repositories;

        
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        #endregion Private Fields

        #region Constuctor/Dispose

        public UnitOfWork(EducationInfoContext context)
        {
            this.context = context;
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                context.Dispose();
            }
            _disposed = true;
        }

        #endregion Constuctor/Dispose
        
        public void Save()
        {
            context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return context.SaveChangesAsync();
        }

        public Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            return context.SaveChangesAsync(cancellationToken);
        }

        //private IRepository<NoteInfo> _noteInfoRepository;

        //public IRepository<NoteInfo> NoteInfoRepository
           // => _noteInfoRepository ?? (_noteInfoRepository = new Repository<NoteInfo>(context));

        /*public IRepository<TEntity Repository<TEntity() where T : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof (T).Name;

            if (_repositories.ContainsKey(type))
            {
                return (IRepository<TEntity) _repositories[type];
            }

            var repositoryType = typeof (IRepository<TEntity);
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context));

            return (IRepository<TEntity) _repositories[type];
        }*/

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            IRepository<TEntity> repo = new Repository<TEntity>(context);
            repositories.Add(typeof(TEntity), repo);
            return repo;
        }
        /*
         * public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
         public IRepository<TEntity Repository<TEntity() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepository<TEntity;
            }

            IRepository<TEntity repo = new GenericRepository<TEntity(entities);
            repositories.Add(typeof(T), repo);
            return repo;
        }*/
    }
}
