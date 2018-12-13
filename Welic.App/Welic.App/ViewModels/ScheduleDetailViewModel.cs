using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AppCenter;
using Welic.App.Helpers.Resources;
using Welic.App.Models.Schedule;
using Welic.App.Services;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class ScheduleDetailViewModel: BaseViewModel
    {

        private string _AppTitle;

        public string AppTitle
        {
            get => _AppTitle;
            set => SetProperty(ref _AppTitle, value);
        }

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
              
        private string _image;

        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        private ScheduleDto _schedule;

        private string _dateEvent;

        public string DateEvent
        {
            get { return _dateEvent; }
            set { _dateEvent = value; }
        }

        private bool _BoolModificar;

        public bool BoolModificar
        {
            get => _BoolModificar;
            set => SetProperty(ref _BoolModificar , value);
        }

        public ScheduleDetailViewModel(params object[] obj)
        {           
            PreencheTela((ScheduleDto) obj[0]);

            if (obj.Length > 1)
            {
                BoolModificar = (bool) obj[1];
            }
            else
            {
                BoolModificar = true;
            }
        }

        private void PreencheTela(ScheduleDto scheduleDto)
        {
            _schedule = scheduleDto;
            Image = Util.ImagePorSistema("iScheduleList");
            _AppTitle = AppResources.Schedule;            

            _description = scheduleDto.Description;
            _title = scheduleDto.Title;
            _dateEvent = scheduleDto.DateEvent.ToShortDateString();
        }

        public async void LoadTela()
        {
           this.PreencheTela(await new ScheduleDto().GetListById(_schedule));
        }

        public Command ReturnCommand => new Command(ReturnDetail);
        
        private async void ReturnDetail()
        {
            await NavigationService.ReturnModalToAsync(true);
        }

        public Command EditCommand => new Command(Edit);

        private async  void Edit()
        {
            object[] obj= new[] {_schedule};
                            
            await NavigationService.NavigateModalToAsync<CreateScheduleViewModel>(obj);
        }

        public Command ExcluirCommand => new Command(delete);

        private async void delete()
        {
            try
            {
                var result = await MessageService.ShowOkAsync(AppResources.Delete, $"{AppResources.Confirm_Delete} {AppResources.Schedule}",
                    AppResources.Yes, AppResources.No);

                if (result)
                    if (await new ScheduleDto().DeleteAsync(_schedule))
                        await NavigationService.ReturnModalToAsync(true);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                await MessageService.ShowOkAsync($"{AppResources.Error_Deleting} {AppResources.Schedule}");
            }
            

            
        }
    }
}
