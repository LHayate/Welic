using System;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Plugin.DeviceInfo;
using Welic.App.Models.Dispositivos.Dto;
using Welic.App.Models.Usuario;
using Welic.App.Services;
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
        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }
        private string _lastName;

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
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
        private string _confirmPassword;

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }
        private string _phoneNumber;

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value;
        }
        private string _localization;            


        public Command RegisterCommand => new Command(async () => await Register());

        private async Task Register()
        {
            try
            {

                if (string.IsNullOrEmpty(FirstName))
                {
                    await App.Current.MainPage.DisplayAlert("Welic", "Necessary Inform the First Name", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(LastName))
                {
                    await App.Current.MainPage.DisplayAlert("Welic", "Necessary Inform the Last Name", "OK");
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
                if (!Password.Equals(ConfirmPassword))
                {
                    await App.Current.MainPage.DisplayAlert("Welic", "Senhas não Coincidem", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(PhoneNumber))
                {
                    await App.Current.MainPage.DisplayAlert("Welic", "Necessary Inform the Phone Number", "OK");
                    return;
                }               

                if (IsBusy)
                    return;

                this.IsBusy = true;


                var usuario = new UserDto
                {                    
                    NickName = EmailAdress,
                    Password = Password,
                    Email = EmailAdress,                    
                    FullName = $"{_firstName} {_lastName}" ,
                    PhoneNumber = PhoneNumber,
                    PhoneNumberConfirmed = PhoneNumber,   
                    FirstName = _firstName,
                    LastName = _lastName,
                    //ImagemPerfil = Util.SetImageDefault(),                    

                };

                if (CrossConnectivity.Current.IsConnected)
                {
                    this.RegisterCommand.ChangeCanExecute();

                    await usuario.Register(usuario);                    

                    if (await WebApi.Current.AuthenticateAsync(usuario))
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

                        //Criar Usuario
                        //await WebApi.Current.PostAsync<UserDto>($"Account/Register", usuario);

                        var user = await WebApi.Current.PostAsync<UserDto>($"User/save",usuario);

                        await NavigationService.NavigateModalToAsync<MainViewModel>();
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

        public RegisterViewModel()
        {
            
        }
    }
}
