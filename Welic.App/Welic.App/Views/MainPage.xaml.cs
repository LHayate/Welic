using Welic.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Welic.App.Models.Usuario;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Welic.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();        
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }


        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new HomePage()));
                        break;
                    case (int)MenuItemType.Galery:
                        MenuPages.Add(id, new NavigationPage(new GaleryPage()));
                        break;
                    case (int)MenuItemType.Notifications:
                        MenuPages.Add(id, new NavigationPage(new NotificationPage()));
                        break;
                    case (int)MenuItemType.Tickets:
                        MenuPages.Add(id, new NavigationPage(new TicketPage()));
                        break;
                    case (int)MenuItemType.Videos:
                        MenuPages.Add(id, new NavigationPage(new VideoPage()));
                        break;
                    case (int)MenuItemType.Settings:
                        MenuPages.Add(id, new NavigationPage(new ConfigPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}