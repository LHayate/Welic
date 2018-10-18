using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Services.API;
using static Welic.App.Services.API.WebApi;

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

        private List<ScheduleDto> _listItem;

        private List<ScheduleDto> ListItem
        {
            get => _listItem;
            set => _listItem = value;
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


        public async Task<List<ScheduleDto>> GetList(int pageIndex, int pageSize)
        {
            try
            {
                _listItem = await Current?.GetAsync<List<ScheduleDto>>("Schedule/GetList");
                return ListItem.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


    }
}
