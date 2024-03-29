﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welic.Dominio.Models.Acesso.Entidades
{
    public class Dispositivo
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
