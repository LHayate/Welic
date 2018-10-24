using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Menu.Dtos;
using Welic.Dominio.Models.Menu.Mapeamentos;

namespace Welic.Dominio.Models.Menu.Repositorios
{
    public interface IRepositorioMenu
    {        
        List<MenuMap> GetAllMenu();
        void SaveMenuUser(int idUser, List<MenuMap> NewMenuUser);
        List<MenuMap> GetbyIdUser(int idUser);
        List<MenuMap> GetListbyIdByList(List<int> listaDeIds);
    }
}
