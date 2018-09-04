using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Dtos;

namespace Welic.App.Services
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(UserDto usuario);
    }
}
