﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Welic.Dominio.Models.Users.Repositorios
{
    public interface IRepositorioUser
    {
        void Save(UserMap userMap);
        UserMap GetById(int id);
        void Delete(int id);
        UserMap GetByEmail(string email);
    }
}