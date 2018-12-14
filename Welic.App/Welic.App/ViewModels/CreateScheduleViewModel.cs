using System;
using Welic.App.Helpers.Resources;
using Welic.App.Models.Schedule;
using Welic.App.Models.Usuario;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class CreateScheduleViewModel: BaseViewModel
    {

        public Command CreatCommand { get; set; }    

        
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

        private bool _Ativo;
        public bool Ativo
        {
            get => _Ativo;
            set => SetProperty(ref _Ativo, value);
        }

        private string _pathFiles;
        public string PathFiles
        {
            get => _pathFiles;
            set => SetProperty(ref _pathFiles, value);
        }       

        public ScheduleDto Dto { get; set; }
        

        public CreateScheduleViewModel(params object[] obj)
        {
           
            if (obj.Length <= 0)
            {
                CreatCommand = new Command(CreateNew);
            }
            else
            {
                Dto = (ScheduleDto)obj[0];
                CreatCommand = new Command(Edit);

                _dateEvent = Dto.DateEvent;
                _title = Dto.Title;
                _Ativo = Dto.Ativo;
                _description = Dto.Description;
                
            }
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

                var ret = await new ScheduleDto().Create(course);


                if (ret != null)
                {
                    await MessageService.ShowOkAsync(AppResources.Success, $"{AppResources.Schedule} {AppResources.Success_Create}", "OK");

                    await NavigationService.ReturnModalToAsync(true);
                }
                else
                {
                    throw new System.Exception($"{AppResources.Error_Create} {AppResources.Schedule}");
                }
                                   

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                await MessageService.ShowOkAsync($"{AppResources.Error_Create} {AppResources.Schedule}");
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async void Edit()
        {

            try
            {
                if (IsBusy)
                    return;
                
                IsBusy = true;

                Dto.DateEvent = _dateEvent;
                Dto.Description = Description;
                Dto.Title = Title;
                Dto.Ativo = Ativo;                                

                var ret = await new ScheduleDto().Edit(Dto);


                if (ret != null)
                {
                    await MessageService.ShowOkAsync(AppResources.Success, $"{AppResources.Video} {AppResources.Success_Change}", "OK");
                    
                }
                else
                {
                    throw new System.Exception($"{AppResources.Error_Change} {AppResources.Schedule}");
                }


            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                await MessageService.ShowOkAsync($"{AppResources.Error_Change} {AppResources.Schedule}");
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
