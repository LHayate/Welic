using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ImageCircle.Forms.Plugin.Abstractions;
using Plugin.Connectivity;
using Plugin.DeviceInfo;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Welic.App.Exception;
using Welic.App.Models.Dispositivos.Dto;
using Welic.App.Models.Usuario;
using Welic.App.Services;
using Welic.App.Services.API;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class EditProfileViewModel: BaseViewModel
    {
        public Command ReturnToMenuCommand => new Command(async () => await ReturnToMenu());
        public Command SaveInfosCommand => new Command(async () => await SaveInfos());
        public Command AlterPhotoCommand => new Command(async () => await PictureNewPhoto());

        

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
            var user = LoadingUser();
            Email = user.Email;
            FirstName = Util.BuscaPrimeiroNome(user.NomeCompleto);
            LastName = user.NomeCompleto;
            Identity = user.Id.ToString();
            PhoneNumber = user.PhoneNumber;
            Password = user.Password;
            ConfirmPassword = user.ConfirmPassword;

            try
            {                
                if (user.ImagemPerfil != null)
                {
                    _image = new Image();
                    Stream stream = new MemoryStream(user.ImagemPerfil);
                    _image = new Image { Source = ImageSource.FromStream(() => stream) };
                }
                else
                {

                    _image = new Image { Source = ImageSource.FromResource(Util.ImagePorSistema("perfil")) };
                    //Stream stream = new MemoryStream(img.Source);
                    //_image = new Image { Source = ImageSource.FromStream(() => stream) };                                    
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }        

        private UserDto LoadingUser()
        {
            UserDto = new UserDto();

            return UserDto.LoadAsync();            
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
                    UserDto.RegistrarUsuario();
          
            }

            IsBusy = false;

        }
        private async Task PictureNewPhoto()
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.Current.IsCameraAvailable)
                {
                    await App.Current.MainPage.DisplayAlert("Ops", "Nenhuma câmera detectada.", "OK");

                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        Directory = "Resources",
                        Name = "Perfil.png"
                    });

                if (file == null)
                    return;

                var user = new UserDto();

                if (await user.RegisterPhoto(file))
                    _image.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    });
            }
            catch (System.Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Ops", "Erro ao Tentar abrir a camera." + ex.Message, "OK");
            }
        }
    }
}
