﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.ConfigApp.Map;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Welic.Dominio.Models.ConfigApp.Service
{
    public interface IConfigAppService : IService<ConfigAppMap>
    {
    }
}
