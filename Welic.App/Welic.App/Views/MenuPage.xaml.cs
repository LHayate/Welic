using System;
using Welic.App.Models;
using System.Collections.Generic;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Welic.App.Models.Usuario;
using Welic.App.Services.API;
using Welic.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Welic.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        readonly List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = new MenuViewModel();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Home", IconMenu = "ihouse.png"},
                new HomeMenuItem {Id = MenuItemType.Galery, Title="Galery", IconMenu = "movie_projector_40.png" },
                new HomeMenuItem {Id = MenuItemType.Notifications, Title="Notifications", IconMenu = "Notification_icon.png" },
                new HomeMenuItem {Id = MenuItemType.Tickets, Title="Tickets", IconMenu = "iShopping_Cart.png" },
                new HomeMenuItem {Id = MenuItemType.Videos, Title="Videos", IconMenu = "iMonitor24.png" },
                new HomeMenuItem {Id = MenuItemType.Settings, Title="Settings", IconMenu = "iConfiguracao.png" },
                new HomeMenuItem {Id = MenuItemType.SignUp, Title="Sign Up", IconMenu = "iVoltar24.png" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About", IconMenu = "information24.png" }
            };

            ListViewMenu.ItemsSource = menuItems;
            
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
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
                        Name = "Perfil.png"
                    });

                if (file == null)
                    return;

                var user = new UserDto();
                                
                if(await user.RegisterPhoto(file))
                    CircleImage.Source = ImageSource.FromStream(() =>
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