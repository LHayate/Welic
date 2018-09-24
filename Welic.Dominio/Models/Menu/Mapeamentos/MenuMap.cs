using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Menu.Enums;

namespace Welic.Dominio.Models.Menu.Mapeamentos
{
    public class MenuMap
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
        public string IconMenu { get; set; }
    }
}
