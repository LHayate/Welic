using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Welic.App.Services.MessageServices.ServicesViewModels;
using Welic.App.Views;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class InicioViewModel :BaseViewModel
    {
        public Command LoginEmailCommand { get; set; }
        public Command LoginFacebookCommand { get; set; }
        public Command LoginGoogleCommand { get; set; }
        public Command CreateAccountCommand { get; set; }
        public Command TermsUseCommand { get; set; }

        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;
        public InicioViewModel()
        {
            _messageService = DependencyService.Get<IMessageService>();
            _navigationService = DependencyService.Get<INavigationService>();
            LoginEmailCommand = new Command(async () => await LoginEmail());
            LoginFacebookCommand = new Command(async () => await LoginFacebook());

        }

        private async Task LoginFacebook()
        {
            try
            {
                await _navigationService.NavigateToAsync<LoginExternoViewModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await _messageService.ShowOkAsync("Erro ao tentar solicitar a pagina. " + e.Message);
            }
        }

        private async Task LoginEmail()
        {
            try
            {
                
                await _navigationService.NavigateToAsync<LoginViewModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await _messageService.ShowOkAsync("Erro ao tentar solicitar a pagina. " + e.Message);
            }
           
        }       
    }
}
