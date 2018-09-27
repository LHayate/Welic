using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Dtos;

namespace Welic.Dominio.Models.User.Servicos
{
    public interface IServicoLogin
    {
        UserDto Save(UserDto userDto);
        UserDto GetById(int id);
        void Delete(int id);
        UserDto GetByEmail(string email);

    }
}
