using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Acesso.Dtos;

namespace Welic.Dominio.Models.Acesso.Servicos
{
    public interface IServicoDispositivo
    {
        DispositivoDto ConsultarPorId(string id);
        DispositivoDto Salvar(DispositivoDto dispositivoDto);
        DispositivoDto Alterar(DispositivoDto dispositivoDto);
    }
}
