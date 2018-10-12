using System;
using System.Threading.Tasks;
using Welic.App.Models.Usuario;
using Welic.App.Services;
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


        private UserDto _userDto;

        public UserDto UserDto
        {
            get => _userDto;
            set => _userDto = value;
        }

        public MenuViewModel()
        {
           
            
            _userDto = (new UserDto()).LoadAsync();


           
            _nomeCompleto = _userDto.NomeCompleto;
            _cpf = _userDto.Id.ToString();
            _email = _userDto.Email ?? _userDto.UserName;
            

            
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
                //var resposta = await MessageService.ShowOkAsync("Desconectar?", "Será necessário logar novamente", "OK", "Cancelar");
                return  (new UserDto()).DesconectarUsuario() ;
            }
            catch (System.Exception)
            {
                return false;                
            }
        }

    }
}
