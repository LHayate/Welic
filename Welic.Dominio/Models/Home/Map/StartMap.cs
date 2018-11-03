using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Home.Map
{
    public class StartMap : Entity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descript { get; set; }
        public byte[] Image { get; set; }
        public bool Visualized { get; set; }
    }
}
