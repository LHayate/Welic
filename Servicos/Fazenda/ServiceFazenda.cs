using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Models.Fazenda.Map;
using Dominio.Models.Fazenda.Service;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Services.Fazenda
{
    public class ServiceFazenda : Service<FazendasMap>, IServiceFazenda
    {
        public ServiceFazenda(IRepositoryAsync<FazendasMap> repository) : base(repository)
        {
        }
    }
}
