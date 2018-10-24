using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Menu.Enums;
using Welic.Dominio.Models.Menu.Mapeamentos;

namespace Welic.Dominio.Models.Menu.Dtos
{
    public class MenuDto
    {
        public int Id { get; set; }        

        public string Title { get; set; }
        public string IconMenu { get; set; }        

        public string Descricao => $"{Nivel}-{Title}";        

        public int? MenuDadId { get; set; }

        public string ComandoDeAcesso { get; private set; }

        public static Func<MenuMap, MenuDto> Map()
        {
            return m => new MenuDto
            {
                Id = m.Id,
                MenuDadId = m.MenuDadId,
                Title = m.Title,
                ComandoDeAcesso = m.ComandoDeAcesso,
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
                ComandoDeAcesso = m.ComandoDeAcesso,
                Nivel = m.Nivel
            };
        }

        public string Nivel { get; set; }
    }
}
