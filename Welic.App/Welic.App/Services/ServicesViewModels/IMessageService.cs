using System.Threading.Tasks;

namespace Welic.App.Services.ServicesViewModels
{
    public interface IMessageService
    {
        Task ShowOkAsync(string Message);
        Task<bool> ShowOkAsync(string title, string Message, string ok, string cancel);
        Task ShowOkAsync(string title, string Message, string ok);
    }
}
