using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Welic.Dominio.Models.Users.Servicos
{
    public interface IAspNetUserService : IService<AspNetUser>
    {
    }
}
