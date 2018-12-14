using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Plugin.Connectivity;
using Welic.App.Helpers.Resources;
using Welic.App.Models.Usuario;
using Welic.App.Services;
using Welic.App.Services.Criptografia;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class EditProfileViewModel: BaseViewModel
    {
        #region Fields and properts
        public Command ReturnToMenuCommand => new Command(async () => await ReturnToMenu());
        public Command SaveInfosCommand => new Command(async () => await SaveInfos());
        
        private string _nickName;
        public string NickName
        {
            get => _nickName;
            set => SetProperty(ref _nickName, value);
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
            set => SetProperty(ref _lastName , value);
        }

        private string _identity;
        public string Identity
        {
            get => _identity;
            set => SetProperty(ref _identity , value);
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber , value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email , value);
        }

        private string _password;
        public string Password
        {
            get { return _password; }
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
            get { return _confirmPassword; }
            set { _confirmPassword = value; }
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

        private UserDto UserDto { get; set; }

        private string _image;
        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }
        private List<string> _ItemsRoles;

        public List<string> ItemsRoles
        {
            get => _ItemsRoles;
            set => SetProperty(ref _ItemsRoles, value);
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
            set => SetProperty(ref _DateBirthday, value);
        }
        #endregion

        public EditProfileViewModel()
        {
            //add itens roles 
            ItemsRoles = new List<string>();
            ItemsRoles.Add(AppResources.Teacher);
            ItemsRoles.Add(AppResources.Student);
            ItemsRoles.Add($"{AppResources.Student} {AppResources.And} {AppResources.Teacher}");

            //Add Itens Gender
            _ItemsGender = new List<string>();
            _ItemsGender.Add(AppResources.Male);
            _ItemsGender.Add(AppResources.Female);
            _ItemsGender.Add(AppResources.Undefined);

            Image = null;
            if (LoadingUser())
            {
                try
                {
                    _image = UserDto.ImagePerfil?? "https://welic.app/Arquivos/Icons/perfil_Padrao.png";
                    
                    Email = UserDto.Email;
                    FirstName = UserDto.FirstName;
                    LastName = UserDto.LastName;                    
                    PhoneNumber = UserDto.PhoneNumber;
                    Email = UserDto.Email;
                    Password = UserDto.Password.Substring(0,15);
                    ConfirmPassword = UserDto.Password.Substring(0,15);
                    NickName = UserDto.NickName;
                    DateBirthday = UserDto.DateOfBirth;
                    SelectedGender = UserDto.Gender ;
                    SelectedRole = UserDto.Profession;
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e);
                    return;
                }
            }
        }        

        private bool LoadingUser()
        {
            UserDto = (new UserDto()).LoadAsync();            
            return UserDto.Email != null;
        }

        private async Task ReturnToMenu()
        {
            await NavigationService.ReturnModalToAsync(true);
        }


        private async Task SaveInfos()
        {
            if (IsBusy)
                return;

            this.IsBusy = true;
            
            if (CrossConnectivity.Current.IsConnected)
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
                if (string.IsNullOrEmpty(Email))
                {
                    await App.Current.MainPage.DisplayAlert(AppResources.Error, AppResources.Require_Email, "OK");
                    return;
                }
                if (string.IsNullOrEmpty(PhoneNumber))
                {
                    await App.Current.MainPage.DisplayAlert(AppResources.Error, AppResources.Requite_phone, "OK");
                    return;
                }

                SaveInfosCommand.ChangeCanExecute();

                UserDto.NickName = NickName;
                UserDto.FullName = $"{FirstName} {LastName}";
                UserDto.FirstName = _firstName;
                UserDto.LastName = _lastName;
                UserDto.DateOfBirth = DateBirthday;
                UserDto.Gender = SelectedGender;
                UserDto.Profession = SelectedRole;
                UserDto.Email = _email;
                UserDto.PhoneNumber = PhoneNumber;
                UserDto.Password = Password;                
                                                                                                
                
                await UserDto.RegisterUserManager(UserDto);

                await MessageService.ShowOkAsync(AppResources.Success_Change);

                await NavigationService.ReturnModalToAsync(true);
            }

            IsBusy = false;            
        }        
    }
}
