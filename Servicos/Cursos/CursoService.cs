using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Curso.Map;
using Welic.Dominio.Models.Curso.Service;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Servicos.Cursos
{
    public class CursoService : Service<CursoMap>, ICursoService
    {        
        public CursoService(IRepositoryAsync<CursoMap> repository) : base(repository)
        {
        }
        
    }
}
