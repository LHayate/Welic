using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Welic.App.Services.MessageServices.ServicesViewModels
{
    public interface IMessageService
    {
        Task ShowOkAsync(string Message);
    }
}
