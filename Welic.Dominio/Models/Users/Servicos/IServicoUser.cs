using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Comandos;
using Welic.Dominio.Models.Users.Dtos;

namespace Welic.Dominio.Models.Users.Servicos
{
    public interface IServiceUser
    {
        UserDto Save(UserDto userDto);        
        UserDto GetById(int id);
        List<UserDto> GetAll();
        void Delete(int id);
        UserDto GetByEmail(string email);
        UserDto GetByName(string name);
        Users.Entidades.User Autenticar(ComandUser comando);
        IEnumerable<GroupUserDto> GetGroupUser();        

    }
}
