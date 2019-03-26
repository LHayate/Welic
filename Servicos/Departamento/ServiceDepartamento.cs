using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Departamento.Map;
using Welic.Dominio.Models.Departamento.Service;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Services.Departamento
{
    public class ServiceDepartamento: Service<DepartamentoMap>,IServiceDepartamento
    {
        public ServiceDepartamento(IRepositoryAsync<DepartamentoMap> repository) : base(repository)
        {
        }
    }
}
