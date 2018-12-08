using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Welic.App.Models.Usuario;
using Welic.App.Services.API;
using static Welic.App.Services.API.WebApi;

namespace Welic.App.Models.Schedule
{
    public class ScheduleDto
    {
        public int ScheduleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DateEvent { get; set; }
        public bool Private { get; set; }
        public bool Ativo { get; set; }
        public string TeacherId { get; set; }

        public ScheduleDto()
        {
            
        }

        private ObservableCollection<ScheduleDto> _listItem;

        private ObservableCollection<ScheduleDto> ListItem
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
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public async Task<List<ScheduleDto>> GetList(int pageIndex, int pageSize)
        {
            try
            {
                var list = await Current?.GetAsync<List<ScheduleDto>>("Schedule/GetList");
                return list.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ObservableCollection<ScheduleDto>> GetList()
        {
            try
            {
                _listItem = await Current?.GetAsync<ObservableCollection<ScheduleDto>>("Schedule/GetList");
                return ListItem;

            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<ObservableCollection<ScheduleDto>> GetListByUser()
        {
            try
            {
                var user = new UserDto().LoadAsync();
                _listItem = await Current?.GetAsync<ObservableCollection<ScheduleDto>>($"Schedule/GetListByUser/{user.Id}");
                return ListItem;

            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<ScheduleDto> GetListById(ScheduleDto scheduleDto)
        {
            try
            {                
                return await Current?.GetAsync<ScheduleDto>($"Schedule/GetById/{scheduleDto.ScheduleId}");                

            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ScheduleDto> Create(ScheduleDto scheduleDto)
        {
            try
            {                
                return await Current?.PostAsync<ScheduleDto>("schedule/save", scheduleDto);
            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<ScheduleDto> Edit(ScheduleDto scheduleDto)
        {
            try
            {
                return await Current?.PostAsync<ScheduleDto>("schedule/update", scheduleDto);
            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> DeleteAsync(ScheduleDto scheduleDto)
        {
            try
            {
                return await Current?.DeleteAsync($"schedule/delete/{scheduleDto.ScheduleId}");
            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
