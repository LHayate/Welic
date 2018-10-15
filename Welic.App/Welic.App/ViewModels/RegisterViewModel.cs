﻿using System;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Plugin.DeviceInfo;
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
        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
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
                    Id = int.Parse(_id),
                    UserName = EmailAdress,
                    Password = Password,
                    Email = Password,
                    ConfirmPassword = Password,
                    NomeCompleto = FullName,
                    PhoneNumber = PhoneNumber,
                    PhoneNumberConfirmed = PhoneNumber,                    

                };

                if (CrossConnectivity.Current.IsConnected)
                {
                    this.RegisterCommand.ChangeCanExecute();

                    if (await WebApi.Current.AuthenticateAsync(usuario))
                    {
                        await usuario.RegisterUser(usuario);

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
