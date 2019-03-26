using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Segurança.Map;
using Welic.Dominio.Models.Segurança.Service;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Services.Seguranca
{
    public class ServicePermission : Service<PermissionMap>,IServicePermission
    {
        public ServicePermission(IRepositoryAsync<PermissionMap> repository) : base(repository)
        {
        }
    }
}
