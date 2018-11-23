using System;
using Welic.Dominio.Patterns.Repository.Pattern.Infrastructure;

namespace Welic.Dominio.Patterns.Repository.Pattern.DataContext
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
        void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, IObjectState;
        void SyncObjectsStatePostCommit();
    }
}