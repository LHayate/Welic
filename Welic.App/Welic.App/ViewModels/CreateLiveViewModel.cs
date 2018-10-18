using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Models.Live;
using Welic.App.Services;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class CreateLiveViewModel : BaseViewModel
    {

        public Command CreatCommand => new Command(async () => CreateNew());

       
        public string TextButton { get; set; }
        public string TitleNavigation { get; set; }
        public string Icon { get; set; }

        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title , value);
        }
        private string _description;

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description , value);
        }

        private string _price;

        public string Price
        {
            get => _price;
            set => SetProperty(ref _price , value);
        }

        private string _themes;

        public string Themes
        {
            get => _themes;
            set => SetProperty(ref _themes , value);
        }

        private bool _chat;

        public bool Chat
        {
            get => _chat;
            set => SetProperty(ref _chat , value);
        }


        public CreateLiveViewModel()
        {
            TitleNavigation = "Creat New Live";
            Icon = Util.ImagePorSistema("LogoWelic72x72.png");
            TextButton = "Criar";
            Chat = true;
        }

        private async void CreateNew()
        {
            try
            {
                if (IsBusy)
                    return;

                this.IsBusy = true;
                var live = new LiveDto
                {
                    Title = _title,
                    Description = _description,
                    Price = decimal.Parse(_price),
                    Themes = _themes,
                    Chat = _chat,
                    UrlDestino = "https://www.youtube.com/watch?v=29fejX2UPoQ&list=RDMMcPJUBQd-PNM&index=27",

                };

                var ret = await (new LiveDto()).Save(live);

                if (ret != null)
                    await NavigationService.NavigateModalToAsync<LiveViewModel>();
                
            }
            catch (System.Exception e)
            {
                IsBusy = false;
                Console.WriteLine(e);
                await MessageService.ShowOkAsync("Erro", "Erro ao Criar","OK");
            }
            
        }

    }
}
