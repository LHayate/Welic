using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Home.Map;

namespace Welic.Dominio.Models.Home.Servico
{
    public interface IServiceStart
    {
        StartMap GetById(int id);
        List<StartMap> GetListaStart();

    }
}
