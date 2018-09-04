using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Services.MessageServices.ServicesViewModels;

namespace Welic.App.Services.MessageServices.ServiceViews
{
    public class MessageServices : IMessageService
    {
        public async Task ShowAsync(string Message)
        {
            await App.Current.MainPage.DisplayAlert("Welic", Message, "OK");
        }
        public MessageServices()
        {

        }
    }
}
