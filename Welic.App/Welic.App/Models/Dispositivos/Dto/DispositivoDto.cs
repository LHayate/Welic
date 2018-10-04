using System;
using System.Linq;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Welic.App.Services.ServiceViews;

namespace Welic.App.Models.Dispositivos.Dto
{
    public class DispositivoDto
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

        private DatabaseManager _dbManager;

        public DispositivoDto()
        {
            
        }       
    }
}
