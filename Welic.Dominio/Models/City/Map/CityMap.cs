using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.City.Map
{
    public class CityMap: Entity
    {
        public int IdCity { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public int Cep { get; set; }
    }
}
