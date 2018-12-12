using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Curso.Map;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Welic.Dominio.Models.Curso.Service
{
    public interface ICursoService: IService<CursoMap>
    {
        List<CursoMap> SearchBooks(string text);
    }
}
