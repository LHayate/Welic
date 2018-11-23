using System;
using System.Data;
using Welic.Dominio.Patterns.Repository.Pattern.Infrastructure;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;

namespace Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        void Dispose(bool disposing);
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IObjectState;
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}