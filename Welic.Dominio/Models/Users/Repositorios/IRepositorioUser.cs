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
        void Save(AspNetUser userMap);
        AspNetUser GetById(string id);
        List<AspNetUser> GetAll();
        void Delete(string id);
        AspNetUser GetByEmail(string email);
        AspNetUser GetByName(string name);
        List<GroupUserMap> GetGroupUser();
    }
}
