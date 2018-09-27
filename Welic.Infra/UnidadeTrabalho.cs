using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio;
using Welic.Infra.Context;

namespace Welic.Infra
{
    public class UnidadeTrabalho : IUnidadeTrabalho
    {
        private readonly AuthContext _contexto;

        public UnidadeTrabalho(AuthContext contexto)
        {
            _contexto = contexto;
        }

        public void Commit()
        {
            _contexto.SaveChanges();
            _contexto.Database.CurrentTransaction?.Commit();
        }

        public void Rollback()
        {
            _contexto.Database.CurrentTransaction?.Rollback();
        }

        public void BeginTran()
        {
            if (_contexto.Database.CurrentTransaction == null)
            {
                _contexto.Database.BeginTransaction();
            }
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
