using System;
using Welic.App.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.AppCenter;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Welic.App.Models.Menu;
using Welic.App.Models.Usuario;
using Welic.App.Services;
using Welic.App.ViewModels;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Welic.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage => Application.Current.MainPage as MainPage;        

        public MenuPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.Resolve<MenuViewModel>();// new MenuViewModel();          

        }

        async void  Menu_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is HomeMenuItem lc)                                      
                await RootPage.NavigateFromMenu((int)lc.Id);

            ((ListView)sender).SelectedItem = null;
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var select = await DisplayActionSheet("Foto", "Cancel", "OK", new string[] { "Usar Camera", " Selecionar Imagem" });

                if (select == null)
                    return;

                if (select.Contains("Cancel"))
                    return;

                MediaFile file;

                if (select.Contains("Camera"))
                {
                    await CrossMedia.Current.Initialize();

                    if (!CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.Current.IsCameraAvailable)
                    {
                        await DisplayAlert("Ops", "Nenhuma câmera detectada.", "OK");

                        return;
                    }

                    file = await CrossMedia.Current.TakePhotoAsync(
                        new StoreCameraMediaOptions
                        {
                            Directory = "Resources",
                            Name = "Perfil.png",
                            PhotoSize = PhotoSize.Small,
                            CompressionQuality = 50,
                            DefaultCamera = CameraDevice.Front,
                            AllowCropping = true,
                        });
                    if (file == null)
                        return;


                    //(BindingContext as MenuViewModel)?.AlterPhoto();
                    //circleImage.Source = ImageSource.FromUri(new Uri(user.ImagePerfil));
                    circleImage.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        return stream;
                    });

                    await (new UserDto()).RegisterPhoto(file);

                }
                else if (select.Contains("Selecionar"))
                {
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                        return;
                    }

                    file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                    {
                        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

                    });
                    if (file == null)
                        return;

                    circleImage.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();

                        return stream;
                    });

                    await (new UserDto()).RegisterPhoto(file);
                }              
            }
            catch (System.Exception ex)
            {
                AppCenterLog.Error("FotoMenu", $"{ex.Message}-{ex.InnerException.Message}");
                await App.Current.MainPage.DisplayAlert("Ops", "Erro ao tirar fotos." + ex.Message, "OK");
            }
        }

        private async void LogOff_OnClicked(object sender, EventArgs e)
        {
            try
            {
                //Pergunta ao Usuario se pode efetuar a troca
                var resposta = await Application.Current.MainPage.DisplayAlert("Desconectar?", "Será necessário logar novamente", "OK", "Cancelar").ConfigureAwait(true);
                if (resposta)
                {
                    await (new UserDto()).DesconectarUsuario();
                    App.Current.MainPage = new NavigationPage(new InicioPage());
                }
            }
            catch (System.Exception ex)
            {
                AppCenterLog.Error("LogOff", $"{ex.Message}-{ex.InnerException.Message}");
                return;
            }
        }        
    }
}