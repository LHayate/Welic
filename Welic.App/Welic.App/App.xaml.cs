using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Welic.App.Models.Location;
using Welic.App.Models.Usuario;
using Welic.App.Services.ServicesViewModels;
using Welic.App.Services.ServiceViews;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Welic.App.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Welic.App
{
    public partial class App : Application
    {
        ISettingsService _settingsService;
        public App()
        {
            LiveReload.Init();
            
            InitializeComponent();

            RegisterService();

            if (Device.RuntimePlatform == Device.UWP)
            {
                InitNavigation();
            }                     
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }
        private void RegisterService()
        {
            _settingsService = ViewModelLocator.Resolve<ISettingsService>();
            if (!_settingsService.UseMocks)
                ViewModelLocator.UpdateDependencies(_settingsService.UseMocks);                       
        }

        protected override async void OnStart()
        {
            base.OnStart();

            if (Device.RuntimePlatform != Device.UWP)
            {
                MainPage = new NavigationPage(new InicioPage());
            }

            if (_settingsService.AllowGpsLocation && !_settingsService.UseFakeLocation)
            {
                await GetGpsLocation();
            }
            if (!_settingsService.UseMocks && !string.IsNullOrEmpty(_settingsService.AuthAccessToken))
            {
                await SendCurrentLocation();
            }

            base.OnResume();
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        public static async Task NavigateToProfile(UserDto userDto, string message = null)
        {
            await App.Current.MainPage.Navigation.PushAsync(new MainPage(userDto));
        }
        public static Action HideLoginView
        {
            get
            {
                return new Action(() => App.Current.MainPage.Navigation.PopModalAsync());
            }
        }
        private async Task GetGpsLocation()
        {
            var dependencyService = ViewModelLocator.Resolve<IDependencyService>();
            var locator = dependencyService.Get<ILocationServiceImplementation>();

            if (locator.IsGeolocationEnabled && locator.IsGeolocationAvailable)
            {
                locator.DesiredAccuracy = 50;

                try
                {
                    var position = await locator.GetPositionAsync();
                    _settingsService.Latitude = position.Latitude.ToString();
                    _settingsService.Longitude = position.Longitude.ToString();
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            else
            {
                _settingsService.AllowGpsLocation = false;
            }
        }

        private async Task SendCurrentLocation()
        {
            var location = new Location
            {
                Latitude = double.Parse(_settingsService.Latitude, CultureInfo.InvariantCulture),
                Longitude = double.Parse(_settingsService.Longitude, CultureInfo.InvariantCulture)
            };

            var locationService = ViewModelLocator.Resolve<ILocationService>();
            await locationService.UpdateUserLocation(location, _settingsService.AuthAccessToken);
        }
    }
}
