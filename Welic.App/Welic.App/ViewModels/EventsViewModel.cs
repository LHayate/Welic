using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Models.Schedule;
using Welic.App.Services;
using Welic.App.ViewModels.Base;

namespace Welic.App.ViewModels
{
    public class EventsViewModel: BaseViewModel
    {
        

        public string Schedule{ get; private set; }
        public string ImageUrl { get; private set; }
        public ObservableCollection<ScheduleDto> ListSchedule { get; private set; }


        public EventsViewModel()
        {
            Schedule = Util.ImagePorSistema("iSchedule");
            ImageUrl = Util.ImagePorSistema("iScheduleList");
            ListSchedule = new ObservableCollection<ScheduleDto>();
            GetData();
        }

        public async Task GetData()
        {
            try
            {
                var list = await (new ScheduleDto()).GetListLive();
                foreach (var scheduleDto in list)
                {
                    ListSchedule.Add(scheduleDto);
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }
    }
}
