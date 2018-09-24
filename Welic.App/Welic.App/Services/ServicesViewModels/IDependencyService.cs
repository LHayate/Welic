using System;
using System.Collections.Generic;
using System.Text;

namespace Welic.App.Services.ServicesViewModels
{
    public interface IDependencyService
    {
        T Get<T>() where T : class;
    }
}
