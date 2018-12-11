using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Menu.Dtos;
using Welic.Dominio.Models.Menu.Mapeamentos;

namespace Welic.Dominio.Models.Menu.Command
{
    public class CommandMenu
    {
        public string NameUser { get; set; }
        public List<MenuMap> MenuUser { get; set; }
    }
}
