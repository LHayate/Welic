using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welic.Dominio.Models.Home.Dtos
{
    public class StartDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descript { get; set; }
        public byte[] Image { get; set; }
        public bool Visualized { get; set; }
    }
}
