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
        DispositivosMap Gravar(DispositivosMap dispositivoMap);
        DispositivosMap Alterar(DispositivosMap dispositivoMap);
        DispositivosMap BuscarPorId(string Id);
    }
}
