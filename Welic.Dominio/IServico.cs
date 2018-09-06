using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welic.Dominio
{
    public interface IServico
    {
        void Rollback(string mensagem);
        void Rollback();
        bool Valido();
        void BeginTran();
        bool Commit();
    }
}
