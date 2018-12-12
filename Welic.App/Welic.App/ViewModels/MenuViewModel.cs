using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Welic.App.Models;
using Welic.App.Models.Menu;
using Welic.App.Models.Usuario;
using Welic.App.Services;
using Welic.App.Services.ServicesViewModels;
using Welic.App.ViewModels.Base;
using Welic.App.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Welic.App.ViewModels
{
    public class SelectedHeaderViewModel
    {
        public bool IsSelected { get; set; }

        public Category Category { get; set; }

        public HomeMenuItem Menu { get; set; }
    }
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

        private string _lastAcess;

        public string LastAcess
        {
            get => _lastAcess;
            set => SetProperty(ref _lastAcess, value);
        }


        private UserDto _userDto;

        public UserDto UserDto
        {
            get => _userDto;
            set => _userDto = value;
        }
        
        public MenuViewModel()
        {
            Image = null;
            _userDto = (new UserDto()).LoadAsync();

            Image = _userDto.ImagePerfil?? "https://welic.app/Arquivos/Icons/perfil_Padrao.png";
            NomeCompleto = $"{_userDto.FirstName} {_userDto.LastName}";
            //_cpf = _userDto.Id;
            _email = _userDto.Email ?? _userDto.NickName;
            _lastAcess = _userDto.LastAccessDate.ToString(CultureInfo.InvariantCulture);


           // MyCharts = new ObservableCollection<Grouping<SelectedHeaderViewModel, HomeMenuItem>>();
           // menuItems = new ObservableCollection<HomeMenuItem>
           // {
           //     //new HomeMenuItem{Id = MenuItemType.Browse, Title="Home", IconMenu = Util.ImagePorSistema("iHome"), Category = new Category { CategoryId = 1, Title = "Home" }},
           //     new HomeMenuItem {Id = MenuItemType.Cursos, Title="Cursos", IconMenu = Util.ImagePorSistema("iIPathCourse"), Category = new Category { CategoryId = 2, Title = "Criar" } },
           //     new HomeMenuItem {Id = MenuItemType.NewLive, Title="New Video", IconMenu = Util.ImagePorSistema("iNewVideo"), Category = new Category { CategoryId = 2, Title = "Criar" } },
           //     new HomeMenuItem {Id = MenuItemType.EBooks, Title="New e-Book", IconMenu = Util.ImagePorSistema("iAddPdf"), Category = new Category { CategoryId = 2, Title = "Criar" } },
           //     new HomeMenuItem {Id = MenuItemType.Schedule, Title="Nova Agenda", IconMenu = Util.ImagePorSistema("iScheduleMenu"), Category = new Category { CategoryId = 2, Title = "Criar" } },
           //     new HomeMenuItem {Id = MenuItemType.Galery, Title="Galery", IconMenu = Util.ImagePorSistema("iGalery"), Category = new Category { CategoryId = 3, Title = "Galeria" } },                                
           //     //new HomeMenuItem {Id = MenuItemType.Notifications, Title="Notifications", IconMenu = Util.ImagePorSistema("iNotification") },
           //     //new HomeMenuItem {Id = MenuItemType.Tickets, Title="Tickets", IconMenu = Util.ImagePorSistema("iTicket") },               
           //     //new HomeMenuItem {Id = MenuItemType.Settings, Title="Settings", IconMenu = Util.ImagePorSistema("iSettings"), Category = new Category { CategoryId = 4, Title = "Settings" } },
           //     //new HomeMenuItem {Id = MenuItemType.About, Title="About", IconMenu = Util.ImagePorSistema("iAbout"), Category = new Category { CategoryId = 4, Title = "About" } }
           // };

           // var menuSimples = new ObservableCollection<HomeMenuItem>
           // {
           //     new HomeMenuItem{Id = MenuItemType.Browse, Title="Home", IconMenu = Util.ImagePorSistema("iHome")},
           //     new HomeMenuItem {Id = MenuItemType.Settings, Title="Settings", IconMenu = Util.ImagePorSistema("iSettings"), Category = new Category { CategoryId = 4, Title = "Settings" } },
           //     new HomeMenuItem {Id = MenuItemType.About, Title="About", IconMenu = Util.ImagePorSistema("iAbout"), Category = new Category { CategoryId = 4, Title = "About" } }
           // };

           //MyCharts.Add(
           //    new Grouping<SelectedHeaderViewModel, HomeMenuItem>(
           //        new SelectedHeaderViewModel()
           //        {
           //            IsSelected = true,
           //            Menu = new HomeMenuItem { Id = MenuItemType.Browse, Title = "Home", IconMenu = Util.ImagePorSistema("iHome") },
           //        },
           //        new HomeMenuItem { Id = MenuItemType.Browse, Title = "Home", IconMenu = Util.ImagePorSistema("iHome") }
           //            )
                               
           //    );

           

            //var group = menuItems.OrderBy(x => x.Category.CategoryId)
            //    .GroupBy(x => x.Category)
            //    .Select(x => new Grouping<SelectedHeaderViewModel, HomeMenuItem>(
            //        new SelectedHeaderViewModel { IsSelected = false, Category = x.Key }, x));
            

            //group.ForEach(x => MyCharts.Add(x));


            //ChartSelectedCommand = new AsyncCommand<HomeMenuItem>(ExecuteSelectedChartCommand, IsBusyStatus);
            ShowCommand = new Command<Grouping<SelectedHeaderViewModel, HomeMenuItem>>(ExecuteShowCommand);
        }
        private async Task SendToEditProfile()
        {
            if (_userDto.Email != null)
                await NavigationService.NavigateModalToAsync<EditProfileViewModel>();
        }

        public ObservableCollection<Grouping<SelectedHeaderViewModel, HomeMenuItem>> MyCharts { get; }
        ObservableCollection<HomeMenuItem> menuItems;

        public Command<Grouping<SelectedHeaderViewModel, HomeMenuItem>> ShowCommand { get; }

        public Command ChartSelectedCommand { get; }
       

        void ExecuteShowCommand(Grouping<SelectedHeaderViewModel, HomeMenuItem> obj)
        {
            if (obj is null) return;

            obj.Key.IsSelected = !obj.Key.IsSelected;

            if (obj.Count == 0)
                menuItems.Where(x => (x.Category.CategoryId.Equals(obj.Key.Category.CategoryId))).ForEach(obj.Add);
            else
                obj.Clear();
        }
        //async Task ExecuteSelectedChartCommand(HomeMenuItem url)
        //{
        //    if (!IsBusy)
        //    {
        //        try
        //        {
                    
        //            var id = (int)((HomeMenuItem)e.SelectedItem).Id;
        //            await RootPage.NavigateFromMenu(id);
        //        }
        //        catch (Exception ex)
        //        {

        //            await DisplayAlert("Erro", $"Erro:{ex.Message}", "Ok");
        //        }
        //        finally
        //        {
        //            IsBusy = false;
        //        }
        //    }
        //    return;
        //}

        public async Task<bool> Deslogar()
        {
            try
            {
                //Pergunta ao Usuario se pode efetuar a troca
                var resposta = await  MessageService.ShowOkAsync("Desconectar?", "Será necessário logar novamente", "OK", "Cancelar").ConfigureAwait(true);
                //return await (new UserDto()).DesconectarUsuario();
                return true;
            }
            catch (AppCenterException ex)
            {
                return false;                
            }
        }

        public void AlterPhoto()
        {
            _userDto = (new UserDto()).LoadAsync();
            Image = _userDto.ImagePerfil;
        }        
    }
}
