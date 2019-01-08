using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Empresa.Map;
using Welic.Dominio.Models.Empresa.Service;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;
using Welic.Infra.Context;

namespace Servicos.Empresa
{
    public class ServiceEmpresa: Service<EmpresaMap>, IServiceEmpresa
    {
        private AuthContext _context;
        public ServiceEmpresa(IRepositoryAsync<EmpresaMap> repository, AuthContext context) 
            : base(repository)
        {
            _context = context;
        }

        
    }
}
