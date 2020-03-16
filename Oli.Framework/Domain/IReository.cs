using System;
using System.Linq;
using System.Linq.Expressions;

namespace Oli.Framework.Domain
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class, IEntity
    {
        void Add(TEntity entity);

        void Edit(TEntity entity);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null);

        TEntity GetById(Guid id);
        TEntity GetBySequentialId(long id);

        void Remove(TEntity entity);
        void RemoveById(Guid id);
        void RemoveBySequentialId(long id);
    }
}