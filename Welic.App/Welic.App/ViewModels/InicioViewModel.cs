using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Welic.App.Exception;
using Welic.App.Models.Config;
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
        public Command CreateAccountCommand => new Command(() => CreateAccount());
        private DatabaseManager _dbManager;

        private void CreateAccount()
        {
            NavigationService.NavigateToAsync<RegisterViewModel>();
        }

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
            catch (System.Exception e)
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

        public async Task<bool> LoadAsync()
        {            
            _dbManager = new DatabaseManager();
            var usu = _dbManager.database.Table<UserDto>()
                .Where(x => x.RememberMe)
                .ToList();

            if (usu.Count > 0)
            {
                await (new UserDto()).SyncedUser();
                return true;
            }
                
            return false;
        }

        public bool ValidaBiometric()
        {
            _dbManager = new DatabaseManager();
            var usu = new UserDto().LoadAsync();
            var config = _dbManager.database.Table<ConfigDto>()            
                .Where(x => x.Biometria && x.UserId == usu.Id)
                .ToList();

            return config.Count > 0;
            
            return false;
        }
    }
}
