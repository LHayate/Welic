using System;

namespace Welic.App.Models.Dispositivos.Dto
{
    public class DispositivoDto
    {
        public string Id { get; set; }
        public string Plataforma { get; set; }
        public string DeviceName { get; set; }
        public string Versao { get; set; }
        public string Sharedkey { get; set; }
        public string Situacao { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime Dt_Sincronismo { get; set; }
        public DateTime Dt_UltimoEnvio { get; set; }
        public string IdUsuario { get; set; }

    }
}
