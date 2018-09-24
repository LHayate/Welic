using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Menu.Enums;

namespace Welic.Dominio.Models.Menu.Entidades
{
    public class Menu
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
        public string IconMenu { get; set; }
        public string Usuario { get; set; }

    }
}
