using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Oli.Framework.DataProvider.EntityFramework
{
    public interface IContext : IDisposable
    {
        void ExecuteSqlRaw(string query, params object[] parameters);
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        ChangeTracker ChangeTracker { get; }

    }
}