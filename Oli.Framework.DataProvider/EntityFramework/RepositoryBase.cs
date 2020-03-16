using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Oli.Framework.Core.Lifetime;
using Oli.Framework.Domain;

namespace Oli.Framework.DataProvider.EntityFramework
{
    public abstract class RepositoryBase<TEntity> : Disposable, IRepository<TEntity> where TEntity : Entity, new()
    {
        private readonly IUnitOfWork<IContext> _unitOfWork;

        protected RepositoryBase(IUnitOfWork<IContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected virtual DbSet<TEntity> ObjectSet => _unitOfWork.GetContext().Set<TEntity>();

        public virtual void Add(TEntity entity)
        {
            ObjectSet.Add(entity);
        }

        public void Edit(TEntity entity)
        {
            _unitOfWork.GetContext().Update(entity);
        }

        public IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> where = null)
        {
            var query = where == null ? ObjectSet : ObjectSet.Where(where);

            return query;
        }

        public virtual TEntity GetById(Guid id)
        {
            return ObjectSet.Find(id);
        }

        public virtual void Remove(TEntity entity)
        {
            ObjectSet.Remove(entity);
        }

        public virtual void RemoveById(Guid id)
        {
            var entity = GetById(id);
            Remove(entity);
        }

        protected override void DisposeCore()
        {
            _unitOfWork?.Dispose();
        }

        public TEntity GetBySequentialId(long id)
        {
            return ObjectSet.FirstOrDefault(e => e.SequentialId == id);
        }

        public void RemoveBySequentialId(long id)
        {
            var entity = GetBySequentialId(id);
            Remove(entity);
        }
    }
}