﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Menu.Dtos;

namespace Welic.Dominio.Models.Menu.Repositorios
{
    public interface IRepositorioMenu
    {
        MenuDto ConsultarMenu();
    }
}