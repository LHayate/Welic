using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Welic.App.Models.Usuario;
using Welic.App.Services;
using Welic.App.Services.ServicesViewModels;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        //public Command EditProfileCommand { get; set; }
        public Command EditProfileCommand => new Command(async () => await SendToEditProfile());


        private string _nomeCompleto;

        public string NomeCompleto
        {
            get => _nomeCompleto;
            set => SetProperty(ref _nomeCompleto, value);
        }
        private string _cpf;

        public string Cpf
        {
            get => _cpf;
            set => SetProperty(ref _cpf, value);
        }
        private string _email;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        private string _image;

        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        private string _lastAcess;

        public string LastAcess
        {
            get => _lastAcess;
            set => SetProperty(ref _lastAcess, value);
        }


        private UserDto _userDto;

        public UserDto UserDto
        {
            get => _userDto;
            set => _userDto = value;
        }
        
        public MenuViewModel()
        {
            Image = null;
            _userDto = (new UserDto()).LoadAsync();

            Image = _userDto.ImagePerfil?? "https://welic.app/Arquivos/Icons/perfil_Padrao.png";
            NomeCompleto = $"{_userDto.FirstName} {_userDto.LastName}";
            //_cpf = _userDto.Id;
            _email = _userDto.Email ?? _userDto.NickName;
            _lastAcess = _userDto.LastAccessDate.ToString(CultureInfo.InvariantCulture);
        }
        private async Task SendToEditProfile()
        {
            if (_userDto.Email != null)
                await NavigationService.NavigateModalToAsync<EditProfileViewModel>();
        }

        public async Task<bool> Deslogar()
        {
            try
            {
                //Pergunta ao Usuario se pode efetuar a troca
                var resposta = await  MessageService.ShowOkAsync("Desconectar?", "Será necessário logar novamente", "OK", "Cancelar").ConfigureAwait(true);
                //return await (new UserDto()).DesconectarUsuario();
                return true;
            }
            catch (AppCenterException ex)
            {
                return false;                
            }
        }

        public void AlterPhoto()
        {
            _userDto = (new UserDto()).LoadAsync();
            Image = _userDto.ImagePerfil;
        }
        //public Command TakeFotoCommand =>

        //public async  Task TakeFoto()
        //{
        //    try
        //    {
        //        var select = await App.Current.MainPage.DisplayActionSheet("Foto", "Cancel", "OK", new string[] { "Usar Camera", " Selecionar Imagem" });

        //        if (select.Contains("Cancel"))
        //            return;

        //        MediaFile file;

        //        if (select.Contains("Camera"))
        //        {
        //            await CrossMedia.Current.Initialize();

        //            if (!CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.Current.IsCameraAvailable)
        //            {
        //                await MessageService.ShowOkAsync("Ops", "Nenhuma câmera detectada.", "OK");

        //                return;
        //            }

        //            file = await CrossMedia.Current.TakePhotoAsync(
        //                new StoreCameraMediaOptions
        //                {
        //                    Directory = "Resources",
        //                    Name = "Perfil.png",
        //                    PhotoSize = PhotoSize.Small,
        //                    CompressionQuality = 50,
        //                    DefaultCamera = CameraDevice.Front,
        //                    AllowCropping = true,
        //                });
        //            if (file == null)
        //                return;

        //            await(new UserDto()).RegisterPhoto(file);

        //            _userDto = (new UserDto()).LoadAsync();

        //            Image = _userDto.ImagePerfil;
        //            //circleImage.Source = ImageSource.FromStream(() =>
        //            //{
        //            //    var stream = file.GetStream();
        //            //    file.Dispose();
        //            //    return stream;
        //            //});

        //        }
        //        else if (select.Contains("Selecionar"))
        //        {
        //            if (!CrossMedia.Current.IsPickPhotoSupported)
        //            {
        //                await MessageService.ShowOkAsync("Photos Not Supported", ":( Permission not granted to photos.", "OK");
        //                return;
        //            }

        //            file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
        //            {
        //                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

        //            });
        //            if (file == null)
        //                return;

        //            await(new UserDto()).RegisterPhoto(file);
        //            _userDto = (new UserDto()).LoadAsync();

        //            Image = _userDto.ImagePerfil;

        //            //circleImage.Source = ImageSource.FromStream(() =>
        //            //{
        //            //    var stream = file.GetStream();
        //            //    file.Dispose();
        //            //    return stream;
        //            //});
        //        }




        //        //CircleImage.Source = ImageSource.FromStream(() =>
        //        //{
        //        //    var stream = file.GetStream();
        //        //    file.Dispose();
        //        //    return stream;
        //        //});


        //        //var memoryStream = new MemoryStream();

        //        //file.GetStream().CopyTo(memoryStream);
        //        //file.Dispose();
        //        //CircleImage.Source = ImageSource.FromStream(() => new MemoryStream(memoryStream.ToArray()));
        //    }
        //    catch (AppCenterException ex)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Ops", "Erro ao tirar fotos." + ex.Message, "OK");
        //    }
        //}
    }
}
