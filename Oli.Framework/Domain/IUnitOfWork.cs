using System;

namespace Oli.Framework.Domain
{
    public interface IUnitOfWork<out TContext> : IDisposable
    {
        void ChangeEntityState<TEntity>(TEntity entity, EntityState entityState) where TEntity : class, IEntity;
        void Commit();
        IEntityConfiguration GetEntityConfiguration<TEntity>() where TEntity : IEntity;
        TContext GetContext();
    }
}