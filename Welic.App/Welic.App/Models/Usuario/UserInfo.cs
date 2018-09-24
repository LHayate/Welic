using System;
using System.Collections.Generic;
using System.Text;

namespace Welic.App.Models.Usuario
{
    class UserInfo
    {
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public byte[] ImagemPerfil { get; set; }
        public string NomeImage { get; set; }
        public DateTime UltimoAcesso { get; set; }
    }
}
