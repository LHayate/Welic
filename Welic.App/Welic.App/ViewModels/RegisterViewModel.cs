using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Merq;
using Plugin.Connectivity;
using Plugin.DeviceInfo;
using Welic.App.Exception;
using Welic.App.Models.Dispositivos.Dto;
using Welic.App.Models.Usuario;
using Welic.App.Services.API;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string _fullName;

        public string FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName , value);
        }
        private string _emailAdress;

        public string EmailAdress
        {
            get => _emailAdress;
            set => _emailAdress = value;
        }
        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password , value);
        }
        private string _phoneNumber;

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value;
        }
        private string _localization;

        public string Localization
        {
            get => _localization;
            set => _localization = value;
        }

        public Command RegisterCommand => new Command(async () => await Register());

        private async Task Register()
        {
            try
            {
                if (string.IsNullOrEmpty(FullName))
                {
                    await App.Current.MainPage.DisplayAlert("Welic", "Necessary Inform the Full Name", "OK");
                    return;
                }

                if (string.IsNullOrEmpty(EmailAdress))
                {
                    await App.Current.MainPage.DisplayAlert("Welic", "Necessary inform the E-mail Adress", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(Password))
                {
                    await App.Current.MainPage.DisplayAlert("Welic", "Necessary Inform the Password", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(PhoneNumber))
                {
                    await App.Current.MainPage.DisplayAlert("Welic", "Necessary Inform the Phone Number", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(Localization))
                {
                    await App.Current.MainPage.DisplayAlert("Welic", "Necessary Inform the Localization", "OK");
                    return;
                }

                if (IsBusy)
                    return;

                this.IsBusy = true;


                var usuario = new UserDto
                {
                    UserName = EmailAdress,
                    Password = Password,
                    Email = Password,
                    ConfirmPassword = Password,
                    NomeCompleto = FullName,
                    PhoneNumber = PhoneNumber,
                    PhoneNumberConfirmed = PhoneNumber,
                    RememberMe = true
                };

                if (CrossConnectivity.Current.IsConnected)
                {
                    this.RegisterCommand.ChangeCanExecute();

                    if (await WebApi.Current.AuthenticateAsync(usuario))
                    {
                        usuario.RegistrarUsuario();
                        //Informações da plataforma e dispositivo
                        DispositivoDto dis = new DispositivoDto();
                        dis.Plataforma = CrossDeviceInfo.Current.Platform.ToString();
                        dis.DeviceName = CrossDeviceInfo.Current.DeviceName;
                        dis.Versao = CrossDeviceInfo.Current.Version;
                        dis.Id = CrossDeviceInfo.Current.Id;

                        await WebApi.Current.PostAsync<DispositivoDto>("dispositivo/salvar", dis);


                        //Criar Usuario
                        await WebApi.Current.PostAsync<UserDto>($"Account/Register", usuario);

                        var user = await WebApi.Current.PostAsync<UserDto>($"User/save",usuario);

                        object[] param = new object[] { user };

                        await NavigationService.NavigateModalToAsync<MainViewModel>();
                    }
                    else
                    {
                        throw new ServiceAuthenticationException("Erro ao Tentar Autenticar o Usuario");
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

        public RegisterViewModel()
        {
            
        }
    }
}
