using System;

namespace Oli.Framework.Domain
{
    public interface IUnitOfWork<out TContext> : IDisposable
    {
        void ChangeEntityState<TEntity, TKey>(TEntity entity, EntityState entityState) where TEntity : class, IEntity<TKey>;
        void Commit();
        IEntityConfiguration GetEntityConfiguration<TEntity, TKey>() where TEntity : IEntity<TKey>;
        TContext GetContext();
    }
}