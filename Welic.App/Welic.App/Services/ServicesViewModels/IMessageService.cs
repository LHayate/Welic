using System.Threading.Tasks;

namespace Welic.App.Services.ServicesViewModels
{
    public interface IMessageService
    {
        Task ShowOkAsync(string Message);
    }
}
