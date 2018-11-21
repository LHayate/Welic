using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Menu.Dtos;
using Welic.Dominio.Models.Menu.Enums;
using Welic.Dominio.Models.Menu.Mapeamentos;

namespace Welic.Dominio.Models.Menu.Entidades
{
    public class Menu
    {
        public int Id { get; set; }        

        public string Title { get; set; }
        public string IconMenu { get; set; }
                    
        public string Nivel { get; private set; }

        public string Action { get; private set; }
        public string Controller { get; set; }
        //public int? GroupAcess { get; set; }
        public int? MenuDadId { get; private set; }
        
        

        public Menu()
        {
            
        }
        
        public static Func<MenuMap, Menu> Map()
        {
            return m => new Menu
            {
                Id = m.Id,
                MenuDadId = m.DadId,
                Title = m.Title,
                Action = m.Action,
                Controller = m.Controller,
                IconMenu = m.IconMenu,
                Nivel = m.Nivel
            };
        }

    }
}
