using System.Threading.Tasks;
using Welic.App.Models.Usuario;

namespace Welic.App.Services.ServicesViewModels
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(UserDto usuario);
    }
}
