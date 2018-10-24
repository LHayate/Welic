using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Welic.App.Models.Location;
using Welic.App.Models.Usuario;
using Welic.App.Services.Navigation;
using Welic.App.Services.ServicesViewModels;
using Welic.App.Services.ServiceViews;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Welic.App.Views;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using Device = Xamarin.Forms.Device;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Welic.App
{
    public partial class App : Application
    {
        ISettingsService _settingsService;
        public App()
        {
            //LiveReload.Init();
            
            InitializeComponent();

            RegisterService();

            if (Device.RuntimePlatform == Device.UWP)
            {
                MainPage = new NavigationPage(new InicioPage());
            }                     
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

            Distribute.ReleaseAvailable = OnReleaseAvailable;
            AppCenter.Start("android=c5af2cb6-5d85-4121-b124-601deccc544e;" +
                            "uwp={Your UWP App secret here};" +
                            "ios={Your iOS App secret here}",
                typeof(Analytics), typeof(Crashes), typeof(Distribute));

           
            

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
            await App.Current.MainPage.Navigation.PushAsync(new MainPage());
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

        bool OnReleaseAvailable(ReleaseDetails releaseDetails)
        {
            // Look at releaseDetails public properties to get version information, release notes text or release notes URL
            string versionName = releaseDetails.ShortVersion;
            string versionCodeOrBuildNumber = releaseDetails.Version;
            string releaseNotes = releaseDetails.ReleaseNotes;
            Uri releaseNotesUrl = releaseDetails.ReleaseNotesUrl;

            // custom dialog
            var title = "Version " + versionName + " available!";
            Task answer;

            // On mandatory update, user cannot postpone
            if (releaseDetails.MandatoryUpdate)
            {
                answer = Current.MainPage.DisplayAlert(title, releaseNotes, "Download and Install");
            }
            else
            {
                answer = Current.MainPage.DisplayAlert(title, releaseNotes, "Download and Install", "Maybe tomorrow...");
            }
            answer.ContinueWith((task) =>
            {
                // If mandatory or if answer was positive
                if (releaseDetails.MandatoryUpdate || (task as Task<bool>).Result)
                {
                    // Notify SDK that user selected update
                    Distribute.NotifyUpdateAction(UpdateAction.Update);
                }
                else
                {
                    // Notify SDK that user selected postpone (for 1 day)
                    // Note that this method call is ignored by the SDK if the update is mandatory
                    Distribute.NotifyUpdateAction(UpdateAction.Postpone);
                }
            });

            // Return true if you are using your own dialog, false otherwise
            return true;
        }
    }
}
