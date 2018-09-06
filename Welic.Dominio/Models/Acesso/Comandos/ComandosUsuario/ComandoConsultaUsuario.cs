using System;

namespace Welic.Dominio.Models.Acesso.Comandos.ComandoUsuario
{
    public class ComandoConsultaUsuario
    {
        public string Usuario { get; set; }
        public string Situacao { get; set; }
        public DateTime? UltimoAcesso { get; set; }
    }
}