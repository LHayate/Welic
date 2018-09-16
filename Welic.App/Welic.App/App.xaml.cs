using System;
using System.Threading.Tasks;
using Welic.App.Services.MessageServices.ServicesViewModels;
using Welic.App.Services.MessageServices.ServiceViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Welic.App.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Welic.App
{
    public partial class App : Application
    {

        public App()
        {
            LiveReload.Init();
            
            InitializeComponent();

            RegisterService();
            //MainPage = new MainPage();
            //MainPage = new LoginPage();
            MainPage = new NavigationPage( new InicioPage());
        }

       

        private void RegisterService()
        {
            DependencyService.Register<INavigationService, NavigationService>();
            DependencyService.Register<IMessageService, MessageServices>();

        }

        protected override void OnStart()
        {
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
        public static async Task NavigateToProfile(string message = null)
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
    }
}
