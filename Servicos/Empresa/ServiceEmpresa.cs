using Infra.Context;
using Welic.Dominio.Models.Empresa.Map;
using Welic.Dominio.Models.Empresa.Service;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Services.Empresa
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
