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
        public MessageServices()
        {

        }
    }
}
