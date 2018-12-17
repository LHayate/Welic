using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Plugin.Connectivity;
using Plugin.DeviceInfo;
using Welic.App.Helpers.Resources;
using Welic.App.Models.Dispositivos.Dto;
using Welic.App.Models.Usuario;
using Welic.App.Services;
using Welic.App.Services.API;
using Welic.App.ViewModels.Base;
using Welic.App.Views;
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
        
        private string _phoneNumber;

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value;
        }
        private string _localization;

        private List<string> _ItemsRoles;

        public List<string> ItemsRoles
        {
            get => _ItemsRoles;
            set => SetProperty(ref _ItemsRoles , value);
        }

        private List<string> _ItemsGender;

        public List<string> ItemsGender
        {
            get => _ItemsGender;
            set => SetProperty(ref _ItemsGender, value);
        }

        private string SelectedGender;       


        int genderSelectedIndex;
        public int GenderSelectedIndex
        {
            get => genderSelectedIndex;
            set
            {
                if (genderSelectedIndex == value) return;
                genderSelectedIndex = value;

                // trigger some action to take such as updating other labels or fields
                OnPropertyChanged(nameof(GenderSelectedIndex));
                SelectedGender = _ItemsGender[genderSelectedIndex];
            }
        }

        private int SelectedRole;


        int roleSelectedIndex;
        public int RoleSelectedIndex
        {
            get
            {
                return roleSelectedIndex;
            }
            set
            {
                if (roleSelectedIndex != value)
                {
                    roleSelectedIndex = value;

                    // trigger some action to take such as updating other labels or fields
                    OnPropertyChanged(nameof(RoleSelectedIndex));
                    SelectedRole = roleSelectedIndex;
                }
            }
        }

        private DateTime? _DateBirthday;

        public DateTime? DateBirthday
        {
            get => _DateBirthday;
            set => SetProperty(ref _DateBirthday , value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                CharEspecial = false;
                CharMaiusculo = false;
                CharMinusculo = false;
                CharNumberLength = false;

                SetProperty(ref _password, value);

                if (Password != null || Password.Length < 0)
                {
                    //TODO: Validar as senhas
                    //if (Regex.IsMatch(Password, (@"[!""#$%&'()*+,-./:;?@[\\\]_`{|}~]")))
                    if (Regex.IsMatch(Password, (@"[^a-zA-Z0-9]")))
                        CharEspecial = true;

                    if (Regex.IsMatch(Password, (@"[A-Z]")))
                        CharMaiusculo = true;

                    if (Regex.IsMatch(Password, (@"[a-z]")))
                        CharMinusculo = true;

                    if (Regex.IsMatch(Password, (@"[0-9]")) && Password.Length >= 8)
                        CharNumberLength = true;
                }
            } 
        }
        private string _confirmPassword;

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {                
                SetProperty(ref _confirmPassword, value);
            } 
        }

        private bool _CharEspecial;

        public bool CharEspecial
        {
            get => _CharEspecial;
            set
            {                
                SetProperty(ref _CharEspecial, value);
            } 
        }

        private bool _CharMaiusculo;

        public bool CharMaiusculo
        {
            get => _CharMaiusculo;
            set
            {                
                SetProperty(ref _CharMaiusculo, value);
            } 
        }
        private bool _CharMinusculo;

        public bool CharMinusculo
        {
            get => _CharMinusculo;
            set
            {                
                SetProperty(ref _CharMinusculo, value);
            } 
        }
        private bool _CharNumberLength;

        public bool CharNumberLength
        {
            get => _CharNumberLength;
            set
            {
                
                SetProperty(ref _CharNumberLength, value);
            } 
        }



        public Command RegisterCommand => new Command(async () => await Register());

        private async Task Register()
        {
            try
            {
                if (string.IsNullOrEmpty(Password))
                {
                    await App.Current.MainPage.DisplayAlert(AppResources.Error, AppResources.Require_Password, "OK");
                    return;
                }
                if (!Password.Equals(ConfirmPassword))
                {
                    await App.Current.MainPage.DisplayAlert(AppResources.Error, AppResources.Password_not_Match, "OK");
                    return;
                }

                if (!Util.IsPasswordStrong(Password))
                {
                    await App.Current.MainPage.DisplayAlert(AppResources.Error, AppResources.Password_Weak, "OK");
                    return;
                }
                if (string.IsNullOrEmpty(FirstName))
                {
                    await App.Current.MainPage.DisplayAlert(AppResources.Error, AppResources.Require_FirstName, "OK");
                    return;
                }
                if (string.IsNullOrEmpty(LastName))
                {
                    await App.Current.MainPage.DisplayAlert(AppResources.Error, AppResources.Require_LastName, "OK");
                    return;
                }
                if (string.IsNullOrEmpty(EmailAdress))
                {
                    await App.Current.MainPage.DisplayAlert(AppResources.Error, AppResources.Require_Email, "OK");
                    return;
                }
                if (string.IsNullOrEmpty(PhoneNumber))
                {
                    await App.Current.MainPage.DisplayAlert(AppResources.Error, AppResources.Requite_phone, "OK");
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
                    FirstName = _firstName,
                    LastName = _lastName,                        
                    Gender = SelectedGender,

                    
                    DateOfBirth = DateBirthday,                         
                };
                switch (SelectedRole)
                {
                    case 0:
                        usuario.Profession = 2;
                        break;                   
                    case 2:
                        usuario.Profession = 4;
                        break;
                    default:                    
                        usuario.Profession = 3;
                        break;
                }

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

                        //var user = await WebApi.Current.PostAsync<UserDto>($"User/save",usuario);
                        Application.Current.MainPage = new MainPage();                        
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
            //add itens roles 
            ItemsRoles = new List<string>();
            ItemsRoles.Add(AppResources.Teacher);
            ItemsRoles.Add(AppResources.Student);
            //ItemsRoles.Add($"{AppResources.Student} {AppResources.And} {AppResources.Teacher}");

            //Add Itens Gender
            _ItemsGender = new List<string>();
            _ItemsGender.Add(AppResources.Male);
            _ItemsGender.Add(AppResources.Female);
            _ItemsGender.Add(AppResources.Undefined);
        }
    }
}
