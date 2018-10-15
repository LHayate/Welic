using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Services.API;

namespace Welic.App.Models.Schedule
{
    public class ScheduleDto
    {
        public int ScheduleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Prince { get; set; }
        public DateTime DateEvent { get; set; }
        public bool Private { get; set; }
        public bool Ativo { get; set; }

        public ScheduleDto()
        {
            
        }

        public async Task<ObservableCollection<ScheduleDto>> GetListLive()
        {
            try
            {
                var list = await WebApi.Current.GetListAsync<ScheduleDto>("Schedule/GetList");
                return list;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }





    }
}
