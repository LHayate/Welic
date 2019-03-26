using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.ConfigApp.Map;
using Welic.Dominio.Models.ConfigApp.Service;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Services.ConfigApp
{
    public class ServiceConfigApp: Service<ConfigAppMap>, IConfigAppService
    {
        public ServiceConfigApp(IRepositoryAsync<ConfigAppMap> repository) : base(repository)
        {
        }
    }
}
