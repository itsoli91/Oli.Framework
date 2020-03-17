using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Oli.Framework.DataProvider.EntityFramework
{
    public abstract class Context : DbContext, IContext
    {
        protected Context(DbContextOptions options) : base(options)
        {
        }

       public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public new EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Modified;
            return Entry(entity);
        }
    }
}