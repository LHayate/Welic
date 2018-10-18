using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Schedule.Maps;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Welic.Dominio.Models.Lives.Maps
{
    public class LiveMap
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Prince { get; set; }
        public string Themes { get; set; }
        public bool Chat { get; set; }
        public byte[] Print { get; set; }
        public string UrlDestino { get; set; }
                
        public UserMap Author { get; set; }

        //public ScheduleMap Lives { get; set; }
    }
}
