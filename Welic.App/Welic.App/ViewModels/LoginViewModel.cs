using System;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Plugin.DeviceInfo;
using Welic.App.Models.Dispositivos.Dto;
using Welic.App.Models.Usuario;
using Welic.App.Services.API;
using Welic.App.Services.Criptografia;
using Welic.App.Services.ServicesViewModels;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class LoginViewModel : BaseViewModel
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

        private readonly ISettingsService _settingsService;
        private readonly IOpenUrlService _openUrlService;
        private readonly IIdentityService _identityService;

        public LoginViewModel(ISettingsService settingsService, IOpenUrlService openUrlService,
            IIdentityService identityService)
        {
            _settingsService = settingsService;
            _openUrlService = openUrlService;
            _identityService = identityService;
        }        

        private string _authUrl;
        public string LoginUrl
        {
            get => _authUrl;
            set => SetProperty(ref _authUrl, value);
        }

        public Command LoginCommand => new Command(async () => await Login());


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
                    Id = 1,
                    UserName = UserLogin,
                    Password = Criptografia.Encriptar(Senha),
                    Email = UserLogin,
                    ConfirmPassword = Criptografia.Encriptar(Senha),
                    RememberMe = true
                };

                if (CrossConnectivity.Current.IsConnected)
                {
                    this.LoginCommand.ChangeCanExecute();

                    if (await WebApi.Current.AuthenticateAsync(usuario))
                    {
                        var userBanco = await (new UserDto()).GetUserbyServer(usuario.Email);

                        //usuario.RegistrarUsuario();
                        if (await usuario.RegisterUser(userBanco))
                        {
                            //Informações da plataforma e dispositivo
                            var dis = new DispositivoDto
                            {
                                Plataforma = CrossDeviceInfo.Current.Platform.ToString(),
                                DeviceName = CrossDeviceInfo.Current.DeviceName,
                                Version = CrossDeviceInfo.Current.Version,
                                Id = CrossDeviceInfo.Current.Id,
                                EmailUsuario = usuario.Email,
                                Status = "ATIVO"
                            };
                            
                            await WebApi.Current.PostAsync<DispositivoDto>("dispositivo/salvar", dis);

                            await NavigationService.NavigateModalToAsync<MainViewModel>();
                        }
                    }
                    else
                    {
                        throw new System.Exception("Erro ao Tentar Autenticar o Usuario");
                    }
                }

                IsBusy = false;
            }
            catch (InvalidOperationException ex)
            {
                await MessageService.ShowOkAsync(ex.Message);
            }
            catch (System.Exception ex)
            {
                await MessageService.ShowOkAsync(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
