using System;
using System.IO;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Welic.App.Models.Usuario;
using Welic.App.Services;
using Welic.App.Services.Criptografia;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class EditProfileViewModel: BaseViewModel
    {
        public Command ReturnToMenuCommand => new Command(async () => await ReturnToMenu());
        public Command SaveInfosCommand => new Command(async () => await SaveInfos());        

        

        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName , value);
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
            set { _password = value; }
        }
        private string _confirmPassword;

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { _confirmPassword = value; }
        }

        private UserDto UserDto { get; set; }

        private Image _image;

        public Image Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }



        public EditProfileViewModel()
        {
            if (LoadingUser())
            {
                try
                {
                    Email = UserDto.Email;
                    FirstName = Util.BuscaPrimeiroNome(UserDto.NomeCompleto);
                    LastName = UserDto.NomeCompleto;
                    Identity = UserDto.Id.ToString();
                    PhoneNumber = UserDto.PhoneNumber;
                    Password = Criptografia.Decriptar(UserDto.Password);
                    ConfirmPassword = Criptografia.Decriptar(UserDto.ConfirmPassword);
                
                    //if (UserDto.ImagemPerfil != null)
                    //{                                                            
                    //    _image = new Image {Source = ImageSource.FromStream(() => new MemoryStream(UserDto.ImagemPerfil))};
                    //}
                    //else
                    //{
                    //    _image = new Image {Source = ImageSource.FromResource(Util.ImagePorSistema("perfil"))};
                    //    Stream stream = new MemoryStream(Util.ImagePorSistema("perfil"));
                    //    _image = new Image { Source = ImageSource.FromStream(() => new MemoryStream(UserDto.ImagemPerfil)) };
                    //}
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

        }        

        private bool LoadingUser()
        {
            UserDto = new UserDto();
            UserDto = UserDto.LoadAsync();
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
                SaveInfosCommand.ChangeCanExecute();

                UserDto.Email = _email;
                UserDto.NomeCompleto = $"{FirstName} {LastName}";
                UserDto.Id = int.Parse(Identity);
                UserDto.PhoneNumber = PhoneNumber;
                UserDto.Password = Password;
                UserDto.ConfirmPassword = ConfirmPassword;
                UserDto.UserName = Email;       
                //TODO: Salvar Imagem quando Tirar uma Nova. 

                await UserDto.SyncedUser(UserDto);

            }

            IsBusy = false;            
        }        
    }
}
