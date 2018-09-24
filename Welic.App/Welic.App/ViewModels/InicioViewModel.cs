using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Welic.App.Exception;
using Welic.App.Models.Usuario;
using Welic.App.Services;
using Welic.App.Services.ServicesViewModels;
using Welic.App.Services.ServiceViews;
using Welic.App.ViewModels.Base;
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


        public InicioViewModel()
        {

            LoginEmailCommand = new Command(async () => await LoginEmail());
            LoginFacebookCommand = new Command(async () => await LoginFacebook());

        }

        private async Task LoginFacebook()
        {
            try
            {
                await NavigationService.NavigateToAsync<LoginExternoViewModel>();
            }
            catch (ServiceAuthenticationException e)
            {
                Console.WriteLine(e);
                await MessageService.ShowOkAsync("Erro ao tentar solicitar a pagina. " + e.Message);
            }
        }

        private async Task LoginEmail()
        {
            try
            {
                
                await NavigationService.NavigateToAsync<LoginViewModel>();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                await MessageService.ShowOkAsync("Erro ao tentar solicitar a pagina. " + e.Message);
            }
           
        }
        public List<UserDto> LoadAsync()
        {
            DatabaseManager dbManager = new DatabaseManager();
            var usu = dbManager.database.Table<UserDto>()
                .Where(x => x.Conectado == true)
                .ToList();
            return usu;
        }
    }
}
