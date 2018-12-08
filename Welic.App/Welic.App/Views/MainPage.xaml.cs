using Welic.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Welic.App.Models.Usuario;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Welic.App.Services.ServicesViewModels;

namespace Welic.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();        
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Split;

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
                        MenuPages.Add(id, new NavigationPage(new ListLivePage()));
                        break;
                    case (int)MenuItemType.Settings:
                        MenuPages.Add(id, new NavigationPage(new ConfigPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.SignOff:
                        await Deslogar();
                        break;
                    case (int)MenuItemType.NewLive:
                        MenuPages.Add(id, new NavigationPage(new CreateLivePage()));
                        break;
                    case (int)MenuItemType.Cursos:
                        MenuPages.Add(id, new NavigationPage(new ListOfCoursesPage()));
                        break;
                    case (int)MenuItemType.EBooks:
                        MenuPages.Add(id, new NavigationPage(new CreateEbookPage()));
                        break;
                    case (int)MenuItemType.Schedule:
                        MenuPages.Add(id, new NavigationPage(new ListSchedulePage()));
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
        public async Task Deslogar()
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
            catch (AppCenterException ex)
            {
                return;
            }
        }
    }
}