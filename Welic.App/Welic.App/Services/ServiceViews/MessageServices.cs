using System.Threading.Tasks;
using Welic.App.Services.ServicesViewModels;

namespace Welic.App.Services.ServiceViews
{
    public class MessageServices : IMessageService
    {
        public async Task ShowOkAsync(string Message)
        {
            await App.Current.MainPage.DisplayAlert("Welic", Message, "OK");            
        }

        public async Task<bool> ShowOkAsync(string title, string Message, string ok, string cancel)
        {
            return await App.Current.MainPage.DisplayAlert(title, Message, ok, cancel);
        }

        public async Task ShowOkAsync(string title, string Message, string ok)
        {
            await App.Current.MainPage.DisplayAlert(title, Message, ok);
        }

        public MessageServices()
        {

        }
    }
}
