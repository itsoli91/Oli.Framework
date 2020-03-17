using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Oli.Framework.Core.Lifetime;
using Oli.Framework.Domain;

namespace Oli.Framework.DataProvider.EntityFramework
{
    public class UnitOfWork : Disposable, IUnitOfWork<IContext>
    {
        protected readonly IContext Context;
        public UnitOfWork(IContext context)
        {
            Context = context;
        }

        protected override void DisposeCore()
        {
            Context.Dispose();
        }

        public void ChangeEntityState<TEntity, TKey>(TEntity entity, EntityState entityState) where TEntity : class, IEntity<TKey>
        {
            switch (entityState)
            {
                case EntityState.Added:
                    Context.Set<TEntity>().Add(entity);
                    break;
                case EntityState.Edited:
                    Context.Update(entity);
                    break;
                case EntityState.Removed:
                    Context.Set<TEntity>().Remove(entity);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(entityState), entityState, null);
            }
        }

        public void Commit()
        {
            var entities = Context.ChangeTracker.Entries()
                .Where(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added || e.State == Microsoft.EntityFrameworkCore.EntityState.Modified)
                .Select(e => e.Entity)
                .ToList();

            foreach(var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext);
            }

            Context.SaveChanges();
        }

        public IEntityConfiguration GetEntityConfiguration<TEntity, TKey>() where TEntity : IEntity<TKey>
        {
            throw new NotImplementedException();
        }

        public IContext GetContext()
        {
            return Context;
        }
    }
}
