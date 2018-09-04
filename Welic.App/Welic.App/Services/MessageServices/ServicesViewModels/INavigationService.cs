using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Welic.App.ViewModels;

namespace Welic.App.Services.MessageServices.ServicesViewModels
{
    public interface INavigationService
    {        
        Task InitializeAsync();
        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task NavigateToAsync<TViewModel>(object[] parameter) where TViewModel : BaseViewModel;
    }
}
