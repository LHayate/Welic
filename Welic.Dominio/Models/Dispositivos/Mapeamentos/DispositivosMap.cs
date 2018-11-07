using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Acesso.Mapeamentos
{
    public class DispositivosMap : Entity
    {

        public string Id { get; set; }
        public string Plataforma { get; set; }
        public string DeviceName { get; set; }
        public string Version { get; set; }
        public string Sharedkey { get; set; }
        public string Status { get; set; }
        public string NameUser { get; set; }
        public DateTime DateSynced { get; set; }
        public DateTime DateLastSynced { get; set; }
        public string EmailUsuario { get; set; }
    }
}
