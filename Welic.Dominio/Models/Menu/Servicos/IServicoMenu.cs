using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Menu.Command;
using Welic.Dominio.Models.Menu.Dtos;

namespace Welic.Dominio.Models.Menu.Servicos
{
    public interface IServicoMenu
    {        

        List<MenuDto> GetMenuComplet();
        List<MenuDto> GetMenuByUser(string email);
        List<MenuDto> GetMenuByUserId(int id);
        void SaveMenuUser(CommandMenu menuUser);
        void SaveMenu(MenuDto menuDto);
        MenuDto GetbyId(int id);

    }
}
