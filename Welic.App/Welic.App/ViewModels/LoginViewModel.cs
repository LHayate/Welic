using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Services.API;
using Welic.App.Services.MessageServices.ServicesViewModels;
using Welic.Dominio.Models.Users.Dtos;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class LoginViewModel :BaseViewModel
    {
        private string userLogin;

        public string UserLogin
        {
            get { return userLogin; }
            set { this.SetProperty(ref userLogin, value); }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set { SetProperty(ref senha, value); }
        }

        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;

        public LoginViewModel()
        {
            _messageService = DependencyService.Get<IMessageService>();
            _navigationService = DependencyService.Get<INavigationService>();
            UserLogin = "LucasA";
            senha = "Teste2";

            LoginCommand = new Command(async () => await Login());
        }


        public Command LoginCommand
        {
            get;
            set;
        }
        
        private async Task Login()
        {
            try
            {
                if (IsBusy)
                    return;

                this.IsBusy = true;

                UserDto usuario = new UserDto
                {
                    UserName = UserLogin,
                    Password = Senha
                };


                this.LoginCommand.ChangeCanExecute();
                if(!await WebApi.Current.AuthenticateAsync(usuario))
                    throw new Exception("Erro ao Tentar Autenticar o Usuario");

                await App.Current.MainPage.DisplayAlert("Welic", "Logado", "OK");
                //await _messageService.ShowAsync("Logou");
                //await _navigationService.NavigateToAsync<T>();
            }
            catch (InvalidOperationException ex)
            {
                await _messageService.ShowAsync(ex.Message);
            }
            catch (Exception ex)
            {
                await _messageService.ShowAsync(ex.Message);
            }
        }
    }
}
