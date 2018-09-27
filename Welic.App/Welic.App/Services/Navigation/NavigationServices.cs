using System;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using Welic.App.Exception;
using Welic.App.Services.ServicesViewModels;
using Welic.App.ViewModels;
using Welic.App.ViewModels.Base;
using Welic.App.Views;
using Xamarin.Forms;

namespace Welic.App.Services.Navigation
{
    public class NavigationService : INavigationService
    {        
        private readonly ISettingsService _settingsService;
        public NavigationService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public Task InitializeAsync()
        {
            if (string.IsNullOrEmpty(_settingsService.AuthAccessToken))
                return NavigateToAsync<InicioViewModel>();
            else
                return NavigateToAsync<MainViewModel>();
        }

        public async Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(CreatePage(typeof(TViewModel)));
            }
            catch (ServiceAuthenticationException e)
            {
                Console.WriteLine(e);
                throw;
            }            
        }

        public async  Task ReturnToAsync(bool animation = false) 
        {
            await Application.Current.MainPage.Navigation.PopAsync(animation);
        }

        public async Task NavigateModalToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushModalAsync(CreatePage(typeof(TViewModel)));
            }
            catch (ServiceAuthenticationException e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task ReturnModalToAsync(bool animation = false) 
        {
            await Application.Current.MainPage.Navigation.PopModalAsync(animation);
        }

        public async Task NavigateModalToAsync<TViewModel>(object[] parameter) where TViewModel : BaseViewModel
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(CreatePage(typeof(TViewModel), parameter));
        }

        public async Task NavigateToAsync<TViewModel>(object[] parameter) where TViewModel : BaseViewModel
        {
            await Application.Current.MainPage.Navigation.PushAsync(CreatePage(typeof(TViewModel), parameter));
        }

        public Task RemoveLastFromBackStackAsync()
        {
            if (Application.Current.MainPage is CustomNavigationView mainPage)
            {
                mainPage.Navigation.RemovePage(
                    mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        public Task RemoveBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as CustomNavigationView;

            if (mainPage != null)
            {
                for (int i = 0; i < mainPage.Navigation.NavigationStack.Count - 1; i++)
                {
                    var page = mainPage.Navigation.NavigationStack[i];
                    mainPage.Navigation.RemovePage(page);
                }
            }

            return Task.FromResult(true);
        }

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType, parameter);

            if (page is LoginPage)
            {
                Application.Current.MainPage = new CustomNavigationView(page);
            }
            else
            {
                var navigationPage = Application.Current.MainPage as CustomNavigationView;
                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    Application.Current.MainPage = new CustomNavigationView(page);
                }
            }

            await (page.BindingContext as BaseViewModel)?.InitializeAsync(parameter);
        }
        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (viewModelType.FullName != null)
            {                    
                var viewName1 = $"{viewModelType.Namespace?.Replace("Model", string.Empty)}.{viewModelType.Name.Replace("ViewModel", string.Empty)}Page";
                var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
                var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName1, viewModelAssemblyName);
                var viewType = Type.GetType(viewAssemblyName);
                return viewType;
            }

            return null;

        }

        private Page CreatePage(Type viewModelType, object parameter = null)
        {
            try
            {
                Type pageType = GetPageTypeForViewModel(viewModelType);
                if (pageType == null)
                {
                    throw new System.Exception($"Não encontrado a pagina Solicitada {viewModelType}");
                }

                Page page = Activator.CreateInstance(pageType) as Page;
                return page;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }
    }    
}
