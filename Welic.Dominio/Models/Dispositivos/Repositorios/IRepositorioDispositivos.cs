using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Acesso.Mapeamentos;

namespace Welic.Dominio.Models.Acesso.Repositorios
{
    public interface IRepositorioDispositivos
    {
        void Gravar(DispositivosMap dispositivoMap);
        void Alterar(DispositivosMap dispositivoMap);
        DispositivosMap BuscarPorId(string Id);
    }
}
