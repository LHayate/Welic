using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Welic.App.Models.Usuario;
using Welic.App.Services.API;
using Welic.App.ViewModels;
using static Welic.App.Services.API.WebApi;

namespace Welic.App.Models.Course
{
    public class CourseDto
    {
        public int IdCurso { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Themes { get; set; }
        public string Print { get; set; }
        public string AuthorId { get; set; }
        public UserDto Author { get; set; }


        public CourseDto()
        {
            
        }
        private ObservableCollection<CourseDto> _listItem;

        private ObservableCollection<CourseDto> ListItem
        {
            get => _listItem;
            set => _listItem = value;
        }

        public async Task<ObservableCollection<CourseDto>> GetList()
        {
            try
            {
                _listItem = await Current?.GetAsync<ObservableCollection<CourseDto>>("curso/getall");
                return ListItem;

            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public async Task<ObservableCollection<CourseDto>> GetListByUser()
        {
            try
            {
                var user = new UserDto().LoadAsync();
                _listItem = await Current?.GetAsync<ObservableCollection<CourseDto>>($"curso/GetByUser/{user.Id}");
                return ListItem;

            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public async Task<CourseDto> GetById(int id)
        {
            try
            {                
                return await Current?.GetAsync<CourseDto>($"curso/GetById/{id}");                
            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        //public async Task<List<CourseDto>> GetList(int pageIndex, int pageSize)
        //{
        //    try
        //    {
        //        _listItem = await Current?.GetAsync<List<CourseDto>>("curso/getall");
        //        return ListItem.ToList();

        //    }
        //    catch (AppCenterException e)
        //    {
        //        Console.WriteLine(e);
        //        return null;
        //    }
        //}

        public async Task<CourseDto> CreateCourses(CourseDto courseDto)
        {
            
            try
            {                
                //
                var course = await WebApi.Current.PostAsync<CourseDto>("curso/save", courseDto);
      
                return course;
            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                throw new AppCenterException("Error: In Synced this User");
            }
        }

        public async Task<CourseDto> Edit(CourseDto courseDto)
        {
            try
            {
                return await Current?.PostAsync<CourseDto>("curso/update", courseDto);
            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> DeleteAsync(CourseDto courseDto)
        {
            try
            {
                return await Current?.DeleteAsync($"curso/delete/{courseDto.IdCurso}");
            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }

}
