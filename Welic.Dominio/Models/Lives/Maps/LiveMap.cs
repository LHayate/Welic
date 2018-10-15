﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Schedule.Maps;

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


        //public ScheduleMap Lives { get; set; }
    }
}
