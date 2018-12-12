using System;
using Welic.App.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.AppCenter;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Welic.App.Models.Menu;
using Welic.App.Models.Usuario;
using Welic.App.Services;
using Welic.App.ViewModels;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;


namespace Welic.App.Views
{
    

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage => Application.Current.MainPage as MainPage;
        ObservableCollection<HomeMenuItem> menuItems;        
        
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
            //menuItems = new ObservableCollection<HomeMenuItem>
            //{
            //    new HomeMenuItem{Id = MenuItemType.Browse, Title="Home", IconMenu = Util.ImagePorSistema("iHome"), Category = new Category { CategoryId = 1, Title = "Home" }},
            //    new HomeMenuItem {Id = MenuItemType.Cursos, Title="Cursos", IconMenu = Util.ImagePorSistema("iIPathCourse"), Category = new Category { CategoryId = 2, Title = "Criar" } },
            //    new HomeMenuItem {Id = MenuItemType.NewLive, Title="New Video", IconMenu = Util.ImagePorSistema("iNewVideo"), Category = new Category { CategoryId = 2, Title = "Criar" } },
            //    new HomeMenuItem {Id = MenuItemType.EBooks, Title="New e-Book", IconMenu = Util.ImagePorSistema("iAddPdf"), Category = new Category { CategoryId = 2, Title = "Criar" } },
            //    new HomeMenuItem {Id = MenuItemType.Schedule, Title="Nova Agenda", IconMenu = Util.ImagePorSistema("iScheduleMenu"), Category = new Category { CategoryId = 2, Title = "Criar" } },
            //    new HomeMenuItem {Id = MenuItemType.Galery, Title="Galery", IconMenu = Util.ImagePorSistema("iGalery"), Category = new Category { CategoryId = 3, Title = "Galeria" } },                                
            //    //new HomeMenuItem {Id = MenuItemType.Notifications, Title="Notifications", IconMenu = Util.ImagePorSistema("iNotification") },
            //    //new HomeMenuItem {Id = MenuItemType.Tickets, Title="Tickets", IconMenu = Util.ImagePorSistema("iTicket") },               
            //    new HomeMenuItem {Id = MenuItemType.Settings, Title="Settings", IconMenu = Util.ImagePorSistema("iSettings"), Category = new Category { CategoryId = 4, Title = "Settings" } },
            //    new HomeMenuItem {Id = MenuItemType.About, Title="About", IconMenu = Util.ImagePorSistema("iAbout"), Category = new Category { CategoryId = 4, Title = "About" } }
            //};


            //var group = menuItems.OrderBy(x => x.Category.CategoryId)
            //    .GroupBy(x => x.Category)
            //    .Select(x => new Grouping<SelectedHeaderViewModel, HomeMenuItem>(
            //        new SelectedHeaderViewModel{IsSelected = false, Menu = x.Key}, x));
                
                
                
            //MyCharts = new ObservableCollection<Grouping<SelectedHeaderViewModel, HomeMenuItem>>();
            //group.ForEach(x=> MyCharts.Add(x));

            //ListViewMenu.ItemsSource = MyCharts;
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
        

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var select = await DisplayActionSheet("Foto", "Cancel", "OK", new string[] {"Usar Camera", " Selecionar Imagem"});

                if (select.Contains("Cancel"))
                    return;

                MediaFile file ;

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
                else if(select.Contains("Selecionar"))
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
            catch (AppCenterException ex)
            {
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
                    await(new UserDto()).DesconectarUsuario();
                    App.Current.MainPage = new NavigationPage(new InicioPage());
                }
            }
            catch (AppCenterException ex)
            {
                return;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
        }
    }
}