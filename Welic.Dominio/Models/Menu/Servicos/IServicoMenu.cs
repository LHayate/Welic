using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Menu.Command;
using Welic.Dominio.Models.Menu.Dtos;
using Welic.Dominio.Models.Menu.Mapeamentos;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Welic.Dominio.Models.Menu.Servicos
{
    public interface IServicoMenu : IService<MenuMap>
    {

        //List<MenuDto> GetMenuComplet();
        List<MenuDto> GetMenuByUser(string email);
        List<MenuDto> GetMenuByUserId(string id);
        void SaveMenuUser(CommandMenu menuUser);
        //void SaveMenu(MenuDto menuDto);
        //MenuDto GetbyId(int id);

    }
}
