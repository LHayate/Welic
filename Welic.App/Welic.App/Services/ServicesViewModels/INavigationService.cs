using System.Threading.Tasks;
using Welic.App.ViewModels.Base;

namespace Welic.App.Services.ServicesViewModels
{
    public interface INavigationService
    {
        Task InitializeAsync();
        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task NavigateToAsync<TViewModel>(object[] parameter) where TViewModel : BaseViewModel;

        Task NavigateModalToAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task NavigateModalToAsync<TViewModel>(object[] parameter) where TViewModel : BaseViewModel;
        Task RemoveLastFromBackStackAsync();

        Task RemoveBackStackAsync();
    }
}
