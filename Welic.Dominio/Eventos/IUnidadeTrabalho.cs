using System;

namespace Welic.Dominio
{
    public interface IUnidadeTrabalho : IDisposable
    {
        void Commit();
        void Rollback();
        void BeginTran();
    }
}