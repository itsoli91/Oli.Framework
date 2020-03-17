using System;
using System.Linq;
using System.Linq.Expressions;

namespace Oli.Framework.Domain
{
    public interface IRepository<TEntity, in TKey> : IDisposable where TEntity : class, IEntity<TKey>
    {
        void Add(TEntity entity);

        void Edit(TEntity entity);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null);

        TEntity GetById(TKey id);
        void Remove(TEntity entity);
        void RemoveById(TKey id);
    }
}