using System;
using System.Globalization;
using System.Threading.Tasks;
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
        private byte[] _image;

        public byte[] Image
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
            _userDto = (new UserDto()).LoadAsync();

            _image = _userDto.ImagemPerfil;
            _nomeCompleto = $"{_userDto.FirstName} {_userDto.LastName}";
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
            catch (System.Exception ex)
            {
                return false;                
            }
        }

    }
}
