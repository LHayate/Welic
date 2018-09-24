using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Connectivity;
using Welic.App.ViewModels.Base;

namespace Welic.App.ViewModels
{
    public class MainViewModel :BaseViewModel
    {
        private string _nomeCompleto;
        private string _cpf;
        private byte[] _imagemPerfil;
        private string _nomeImage;
        private DateTime _ultimoAcesso;

        public string NomeCompleto
        {
            get => _nomeCompleto;
            set => SetProperty(ref _nomeCompleto, value);
        }

        public string Cpf
        {
            get => _cpf;
            set => SetProperty(ref _cpf, value);
        }

        public byte[] ImagemPerfil
        {
            get => _imagemPerfil;
            set => SetProperty(ref _imagemPerfil, value);
        }

        public string NomeImage
        {
            get => _nomeImage;
            set => SetProperty(ref _nomeImage, value);
        }

        public DateTime UltimoAcesso
        {
            get => _ultimoAcesso;
            set => SetProperty(ref _ultimoAcesso, value);
        }

        public MainViewModel()
        {
            if (CrossConnectivity.Current.IsConnected)
            {

                //var user = WebApi.Current.GetAsync<UserDto>($"Usuario/GetById/{}");









                //if ()
                //{
                //    usuario.RegistrarUsuario();
                //    await _navigationService.NavigateModalToAsync<MainViewModel>();
                //    //App.Current.MainPage = new MainPage();
                //}               


                ////Informações da plataforma e dispositivo
                //DispositivoDto dis = new DispositivoDto();
                ////dis.Plataforma = CrossDeviceInfo.Current.Platform.ToString();
                ////dis.DeviceName = CrossDeviceInfo.Current.DeviceName;
                ////dis.Versao = CrossDeviceInfo.Current.Version;
                ////dis.Id = CrossDeviceInfo.Current.Id;

                //// await WebApi.Current.PostAsync<DispositivoDto>("dispositivo/salvar", dis);

                //await _navigationService.NavigateModalToAsync<MainViewModel>();


            }


        }
    }
}
