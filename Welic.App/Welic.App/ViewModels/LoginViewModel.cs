using System;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Plugin.DeviceInfo;
using Welic.App.Models.Dispositivos.Dto;
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
                if (string.IsNullOrEmpty(userLogin))
                {
                    await App.Current.MainPage.DisplayAlert("Welic", "Necessário Informar o E-mail", "OK");
                    return;
                }

                if (string.IsNullOrEmpty(Senha))
                {
                    await App.Current.MainPage.DisplayAlert("Welic", "Necessário Informar a Senha", "OK");
                    return;
                }

                if (IsBusy)
                    return;

                this.IsBusy = true;

                UserDto usuario = new UserDto
                {
                    UserName = UserLogin,
                    Password = Senha
                };

                if (CrossConnectivity.Current.IsConnected)
                {
                    this.LoginCommand.ChangeCanExecute();
                    if (!await WebApi.Current.AuthenticateAsync(usuario))
                        throw new Exception("Erro ao Tentar Autenticar o Usuario");

                    //Informações da plataforma e dispositivo
                    DispositivoDto dis = new DispositivoDto();
                    //dis.Plataforma = CrossDeviceInfo.Current.Platform.ToString();
                    //dis.DeviceName = CrossDeviceInfo.Current.DeviceName;
                    //dis.Versao = CrossDeviceInfo.Current.Version;
                    //dis.Id = CrossDeviceInfo.Current.Id;

                    // await WebApi.Current.PostAsync<DispositivoDto>("dispositivo/salvar", dis);

                    await _navigationService.NavigateToAsync<LoginExternoViewModel>();








                    await App.Current.MainPage.DisplayAlert("Welic", "Logado", "OK");
                    //await _messageService.ShowAsync("Logou");
                    //await _navigationService.NavigateToAsync<T>();
                }

                IsBusy = false;
            }
            catch (InvalidOperationException ex)
            {
                await _messageService.ShowOkAsync(ex.Message);
            }
            catch (Exception ex)
            {
                await _messageService.ShowOkAsync(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
