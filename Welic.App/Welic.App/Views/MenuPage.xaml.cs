using System;
using Welic.App.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Android;
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
        List<HomeMenuItem> menuItems;

        //public ObservableCollection<Grouping<SelectedHeaderViewModel, LocalChart>> MyCharts { get; }

        //private readonly ObservableCollection<GroupHomeMenuItem> GroupMenu;

        private UserDto _userdto;

        public MenuPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.Resolve<MenuViewModel>();// new MenuViewModel();


            //GroupMenu = new ObservableCollection<GroupHomeMenuItem>
            //{
            //    new GroupHomeMenuItem("Add Conteudo",Util.ImagePorSistema("iGalery"))
            //    {
            //        new HomeMenuItem {Id = MenuItemType.Galery, Title="Galery", IconMenu = Util.ImagePorSistema("iGalery") },
            //    },
            //};
            //TODO: Quando for implementado algo modificar menu para apresentar o menu
            //menuItems = new List<HomeMenuItem>
            //{
            //    new HomeMenuItem{Id = MenuItemType.Browse, Title="Home", IconMenu = Util.ImagePorSistema("iHome")},
            //    new HomeMenuItem {Id = MenuItemType.Cursos, Title="Cursos", IconMenu = Util.ImagePorSistema("iIPathCourse") },
            //    new HomeMenuItem {Id = MenuItemType.NewLive, Title="New Video", IconMenu = Util.ImagePorSistema("iNewVideo") },
            //    new HomeMenuItem {Id = MenuItemType.EBooks, Title="New e-Book", IconMenu = Util.ImagePorSistema("iAddPdf") },
            //    new HomeMenuItem {Id = MenuItemType.Schedule, Title="Nova Agenda", IconMenu = Util.ImagePorSistema("iScheduleMenu") },
            //    new HomeMenuItem {Id = MenuItemType.Galery, Title="Galery", IconMenu = Util.ImagePorSistema("iGalery") },                                
            //    //new HomeMenuItem {Id = MenuItemType.Notifications, Title="Notifications", IconMenu = Util.ImagePorSistema("iNotification") },
            //    //new HomeMenuItem {Id = MenuItemType.Tickets, Title="Tickets", IconMenu = Util.ImagePorSistema("iTicket") },               
            //    new HomeMenuItem {Id = MenuItemType.Settings, Title="Settings", IconMenu = Util.ImagePorSistema("iSettings") },
            //    new HomeMenuItem {Id = MenuItemType.About, Title="About", IconMenu = Util.ImagePorSistema("iAbout") }
            //};

            //ListViewMenu.ItemsSource = menuItems;
            //ListViewMenu.ItemsSource = menuItems;

            //ListViewMenu.ItemSelected += async (sender, e) =>
            //{
            //    try
            //    {
            //        if (e.SelectedItem == null)
            //            return;

            //        var id = (int)((HomeMenuItem)e.SelectedItem).Id;
            //        await RootPage.NavigateFromMenu(id);
            //        ListViewMenu.SelectedItem = null;
            //    }
            //    catch (System.Exception exception)
            //    {
            //        Console.WriteLine(exception);

            //    }

            //};

            //ListViewMenuGroup.ItemsSource = GroupMenu;
            ////ListViewMenu.ItemsSource = menuItems;

            //ListViewMenuGroup.ItemSelected += async (sender, e) =>
            //{
            //    if (e.SelectedItem == null)
            //        return;

            //    //var id = (int)((HomeMenuItem)e.SelectedItem).Id;
            //    //await RootPage.NavigateFromMenu(id);

            //};

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




                //CircleImage.Source = ImageSource.FromStream(() =>
                //{
                //    var stream = file.GetStream();
                //    file.Dispose();
                //    return stream;
                //});


                //var memoryStream = new MemoryStream();

                //file.GetStream().CopyTo(memoryStream);
                //file.Dispose();
                //CircleImage.Source = ImageSource.FromStream(() => new MemoryStream(memoryStream.ToArray()));
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}