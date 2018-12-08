using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Welic.App.Models.Course;
using Welic.App.Models.Usuario;
using static Welic.App.Services.API.WebApi;

namespace Welic.App.Models.Live
{
    public class LiveDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Themes { get; set; }
        public bool Chat { get; set; }
        public string Print { get; set; }
        public string UrlDestino { get; set; }
        public DateTime DateRegister { get; set; }

        public int? CourseId { get; set; }       

        public string TeacherId { get; set; }

        public LiveDto()
        {
            
        }

        private List<LiveDto> _listItem;

        private List<LiveDto> ListItem
        {
            get => _listItem;
            set => _listItem = value;
        }       

        public async Task<List<LiveDto>> GetList(int pageIndex, int pageSize)
        {
            try
            {
                _listItem = await Current?.GetAsync<List<LiveDto>>("live/GetListLive");
                return ListItem.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public async Task<ObservableCollection<LiveDto>> GetList()
        {
            try
            {
                var list = await Current?.GetAsync<ObservableCollection<LiveDto>>("live/GetListLive");
                return list;

            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public async Task<ObservableCollection<LiveDto>> GetListRecente()
        {
            try
            {
                var list = await Current?.GetAsync<ObservableCollection<LiveDto>>("live/GetListRecentes");
                return list;

            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public async Task<ObservableCollection<LiveDto>> GetListFavoritos()
        {
            try
            {
                var list = await Current?.GetAsync<ObservableCollection<LiveDto>>("live/GetLisFavoritos");
                return list;

            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public async Task<ObservableCollection<LiveDto>> GetListByUser()
        {
            try
            {
                var user = new UserDto().LoadAsync();
                var list = await Current?.GetAsync<ObservableCollection<LiveDto>>($"live/GetListTeacher/{user.Id}");
                return list;

            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public async Task<List<LiveDto>> GetListByCourse(CourseDto courseDto, int pageIndex, int pageSize)
        {
            try
            {
                var list = await Current?.GetAsync<List<LiveDto>>($"live/GetListbyCourse/{courseDto.IdCurso}");
                return list.Skip(pageIndex * pageSize).Take(pageSize).ToList();
                                

            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


        public async Task<LiveDto> Save(LiveDto liveDto)
        {
            try
            {                
                liveDto.DateRegister = DateTime.Now;
                return await Current?.PostAsync<LiveDto>("live/Save", liveDto) ;
            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> DeleteAsync(LiveDto liveDto)
        {
           return await Current?.DeleteAsync($"live/delete/{liveDto.Id}");
        }
    }
}
