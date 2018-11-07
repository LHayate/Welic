using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Menu.Enums;
using Welic.Dominio.Models.Menu.Mapeamentos;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Menu.Dtos
{
    public class MenuDto : Entity
    {
        public int Id { get; set; }        

        public string Title { get; set; }
        public string IconMenu { get; set; }        

        public string Descricao => $"{Nivel}-{Title}";        

        public int? MenuDadId { get; set; }

        public string Action { get; set; }
        public string Controller { get; set; }

        public static Func<MenuMap, MenuDto> Map()
        {
            return m => new MenuDto
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
        public static Func<Entidades.Menu, MenuDto> MapEntity()
        {
            return m => new MenuDto
            {
                Id = m.Id,
                MenuDadId = m.MenuDadId,
                Title = m.Title,
                Action = m.Action,
                Controller = m.Controller,
                IconMenu = m.IconMenu,
                Nivel = m.Nivel
            };
        }

        public string Nivel { get; set; }
    }
}
