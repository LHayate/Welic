using System;
using Welic.App.Models;
using System.Collections.Generic;
using System.IO;
using Microsoft.AppCenter;
using Plugin.Media;
using Plugin.Media.Abstractions;
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

        //private readonly ObservableCollection<GroupHomeMenuItem> GroupMenu;

        private UserDto _userdto;

        public MenuPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.Resolve<MenuViewModel>();// new MenuViewModel();

            LoadingImage();

            //GroupMenu = new ObservableCollection<GroupHomeMenuItem>
            //{
            //    new GroupHomeMenuItem("Add Conteudo",Util.ImagePorSistema("iGalery"))
            //    {
            //        new HomeMenuItem {Id = MenuItemType.Galery, Title="Galery", IconMenu = Util.ImagePorSistema("iGalery") },
            //    },
            //};
            //TODO: Quando for implementado algo modificar menu para apresentar o menu
            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem{Id = MenuItemType.Browse, Title="Home", IconMenu = Util.ImagePorSistema("iHome")},
                new HomeMenuItem {Id = MenuItemType.Cursos, Title="Cursos", IconMenu = Util.ImagePorSistema("iIPathCourse") },
                new HomeMenuItem {Id = MenuItemType.NewLive, Title="New Video", IconMenu = Util.ImagePorSistema("iNewVideo") },
                new HomeMenuItem {Id = MenuItemType.EBooks, Title="New e-Book", IconMenu = Util.ImagePorSistema("iAddPdf") },
                new HomeMenuItem {Id = MenuItemType.Schedule, Title="Nova Agenda", IconMenu = Util.ImagePorSistema("iScheduleMenu") },
                new HomeMenuItem {Id = MenuItemType.Galery, Title="Galery", IconMenu = Util.ImagePorSistema("iGalery") },                                
                //new HomeMenuItem {Id = MenuItemType.Notifications, Title="Notifications", IconMenu = Util.ImagePorSistema("iNotification") },
                //new HomeMenuItem {Id = MenuItemType.Tickets, Title="Tickets", IconMenu = Util.ImagePorSistema("iTicket") },               
                new HomeMenuItem {Id = MenuItemType.Settings, Title="Settings", IconMenu = Util.ImagePorSistema("iSettings") },                
                new HomeMenuItem {Id = MenuItemType.About, Title="About", IconMenu = Util.ImagePorSistema("iAbout") }
            };

            ListViewMenu.ItemsSource = menuItems;
            //ListViewMenu.ItemsSource = menuItems;
            
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                try
                {
                    if (e.SelectedItem == null)
                        return;

                    var id = (int)((HomeMenuItem)e.SelectedItem).Id;                    
                    await  RootPage.NavigateFromMenu(id);
                    ListViewMenu.SelectedItem = null;
                }
                catch (AppCenterException exception)
                {
                    Console.WriteLine(exception);
                   
                }
                
            };

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

        private void LoadingImage()
        {
            try
            {
                _userdto = (new UserDto()).LoadAsync();

                if (_userdto.ImagemPerfil != null)
                {
                    CircleImage.Source = ImageSource.FromStream(() => new MemoryStream(_userdto.ImagemPerfil));
                }
                else
                {
                    CircleImage.Source = ImageSource.FromResource(Util.ImagePorSistema("perfil_Padrao"));
                }
            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private async void Button_OnClicked(object sender, EventArgs e)
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
                        Name = "Perfil.png",
                        PhotoSize = PhotoSize.Small,
                        CompressionQuality = 50,
                        DefaultCamera = CameraDevice.Front,
                        AllowCropping = true,
                    });

                if (file == null)
                    return;

                await (new UserDto()).RegisterPhoto(file);

               
                CircleImage.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });


                //var memoryStream = new MemoryStream();

                //file.GetStream().CopyTo(memoryStream);
                //file.Dispose();
                //CircleImage.Source = ImageSource.FromStream(() => new MemoryStream(memoryStream.ToArray()));
            }
            catch (AppCenterException ex)
            {
                await App.Current.MainPage.DisplayAlert("Ops", "Erro ao Tentar abrir a camera." + ex.Message, "OK");
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
                    await(new UserDto()).DesconectarUsuario();
                    App.Current.MainPage = new NavigationPage(new InicioPage());
                }
            }
            catch (AppCenterException ex)
            {
                return;
            }
        }
    }
}