using System.Collections.Generic;
using Welic.Dominio.Utilitarios.Comandos;

namespace Welic.Dominio.Utilitarios.Servicos
{
    public interface IServicoUtilitario
    {
        List<ComandoMesAno> ListarMesAno(ComandoListarMesAno comando);
    }
}