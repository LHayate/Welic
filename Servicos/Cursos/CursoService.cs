using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Curso.Map;
using Welic.Dominio.Models.Curso.Service;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;
using Welic.Infra.Context;

namespace Servicos.Cursos
{
    public class CursoService : Service<CursoMap>, ICursoService
    {
        private AuthContext _context;
        public CursoService(IRepositoryAsync<CursoMap> repository, AuthContext context) : base(repository)
        {
            _context = context;
        }

        public List<CursoMap> SearchBooks(string text)
        {
            return _context.Curso
                .Where(map => map.Title.Contains(text))
                .OrderBy(x => x.Title)
                .ToList();
        }
    }
}
