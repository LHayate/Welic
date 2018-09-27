using System.Threading.Tasks;
using Welic.App.ViewModels.Base;

namespace Welic.App.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();
        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task ReturnToAsync(bool animation);
        Task NavigateToAsync<TViewModel>(object[] parameter) where TViewModel : BaseViewModel;

        Task NavigateModalToAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task ReturnModalToAsync(bool animation);
        Task NavigateModalToAsync<TViewModel>(object[] parameter) where TViewModel : BaseViewModel;
        Task RemoveLastFromBackStackAsync();

        Task RemoveBackStackAsync();
    }
}
