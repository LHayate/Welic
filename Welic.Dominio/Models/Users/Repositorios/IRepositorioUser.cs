using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Welic.Dominio.Models.Users.Repositorios
{
    public interface IRepositorioUser
    {
        UserMap Save(UserMap userDto);
        UserMap GetById(UserMap userDto);
        void Delete(string id);
    }
}
