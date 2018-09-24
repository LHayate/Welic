using System;
using System.Collections.Generic;
using System.Text;
using Welic.App.Services.ServicesViewModels;
using Xamarin.Forms;

namespace Welic.App.Services.ServiceViews
{
    class OpenUrlService : IOpenUrlService
    {
        public void OpenUrl(string url)
        {
            Device.OpenUri(new Uri(url));
        }
    }
}
