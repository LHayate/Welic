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
        //List<MenuMap> GetAllMenu();
        void SaveMenuUser(string idUser, List<MenuMap> NewMenuUser);
        //List<MenuMap> GetbyIdUser(string idUser);        
        //List<MenuMap> GetListbyIdByList(List<int> listaDeIds);
        //void Save(MenuMap menuMap);
        //MenuMap GetById(int id);
    }
}
