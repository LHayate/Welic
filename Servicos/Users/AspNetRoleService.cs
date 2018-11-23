using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Models.Users.Servicos;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Servicos.Users
{
    public class AspNetRoleService : Service<AspNetRole>, IAspNetRoleService
    {
        public AspNetRoleService(IRepositoryAsync<AspNetRole> repository)
            : base(repository)
        {
        }
    }
}
