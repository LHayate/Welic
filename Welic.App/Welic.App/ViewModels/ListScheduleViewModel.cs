using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Welic.App.Models.Course;
using Welic.App.Models.Live;
using Welic.App.Models.Schedule;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class ListScheduleViewModel : BaseViewModel
    {
        public Command AddNewCommand => new Command(AddNew);        

        private ObservableCollection<ScheduleDto> _listStart;

        public ObservableCollection<ScheduleDto> ListStart
        {
            get => _listStart;
            set => SetProperty(ref _listStart, value);
        }

        public ListScheduleViewModel()
        {
            Atualizando = true;

            SetListSchedule();

            Atualizando = false;
        }

        public async Task SetListSchedule()
        {
            ListStart = await new ScheduleDto().GetListByUser();
            IsBusy = ListStart.Count <= 0;
        }

        private void AddNew()
        {
            NavigationService.NavigateModalToAsync<CreateScheduleViewModel>();
        }

        public void OpenSchedule(ScheduleDto Schedule)
        {
            object[] obj = new[] { Schedule };

            NavigationService.NavigateModalToAsync<CourseDetailViewModel>(obj);
        }

        public async void Delete(ScheduleDto schedule)
        {
            await new ScheduleDto().DeleteAsync(schedule);
        }

        private bool _atualizando = false;
        public bool Atualizando
        {
            get { return _atualizando; }
            set
            {
                SetProperty(ref _atualizando, value);
            }
        }
        public ICommand AtualizarCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Atualizando = true;

                    await SetListSchedule();

                    Atualizando = false;
                });
            }
        }
    }
}
