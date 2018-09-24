using System;
using System.Collections.Generic;
using System.Text;
using Welic.App.Services.ServicesViewModels;

namespace Welic.App.Services.ServiceViews
{
    public class DependencyService : IDependencyService
    {
        public T Get<T>() where T : class
        {
            return Xamarin.Forms.DependencyService.Get<T>();
        }
    }
}
