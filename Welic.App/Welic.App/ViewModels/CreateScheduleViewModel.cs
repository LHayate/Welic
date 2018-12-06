using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Welic.App.Models.Live;
using Welic.App.Models.Schedule;
using Welic.App.Models.Usuario;
using Welic.App.Services;
using Welic.App.Services.API;
using Welic.App.ViewModels.Base;
using Welic.App.Views;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class CreateScheduleViewModel: BaseViewModel
    {

        public Command CreatCommand => new Command(CreateNew);        

        
        private string _path;

        public string TextButton { get; set; }
        public string TitleNavigation { get; set; }
        public string Icon { get; set; }

        private string _title;
        public new string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private decimal _price;
        public decimal Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        private string _themes;
        public string Themes
        {
            get => _themes;
            set => SetProperty(ref _themes, value);
        }

        private bool _chat;
        public bool Chat
        {
            get => _chat;
            set => SetProperty(ref _chat, value);
        }

        private string _pathFiles;
        public string PathFiles
        {
            get => _pathFiles;
            set => SetProperty(ref _pathFiles, value);
        }
        private bool _MenuVisivel;

        public bool MenuVisivel
        {
            get => _MenuVisivel;
            set => SetProperty(ref _MenuVisivel, value);
        }


        public ScheduleDto Dto { get; set; }
        public CreateScheduleViewModel()
        {
            
        }

        private DateTime _dateEvent;

        public DateTime DateEvent
        {
            get => _dateEvent;
            set => SetProperty(ref _dateEvent , value);
        }


        private async void CreateNew()
        {
           
            try
            {
                if (IsBusy)
                    return;

                var user = new UserDto().LoadAsync();
                IsBusy = true;
               

                var course = new ScheduleDto()
                {
                    Description = _description,
                    Price = _price,                    
                    Title = _title,
                    TeacherId = user.Id,
                    Ativo = true,
                    DateEvent = _dateEvent,                    
                };

                await new ScheduleDto().Create(course);
                await MessageService.ShowOkAsync("Create", "Curso Criado com Sucesso", "OK");

                App.Current.MainPage = new MainPage();
                //await NavigationService.ReturnModalToAsync(true);

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                await MessageService.ShowOkAsync("Erro ao criar Schedule");
            }
            finally
            {
                IsBusy = false;
            }
        }
        public Command ReturnCommand => new Command(Return);

        private async void Return()
        {
            await NavigationService.ReturnModalToAsync(true);
        }
    }
}
