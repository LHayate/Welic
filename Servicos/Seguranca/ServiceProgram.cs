using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Segurança.Map;
using Welic.Dominio.Models.Segurança.Service;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Servicos.Seguranca
{
    public class ServiceProgram : Service<ProgransMap>, IServiceProgram
    {
        public ServiceProgram(IRepositoryAsync<ProgransMap> repository) : base(repository)
        {
        }
    }
}
