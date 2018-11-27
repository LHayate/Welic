using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public decimal Prince { get; set; }
        public string Themes { get; set; }
        public byte[] Print { get; set; }
        public UserDto Author { get; set; }

        public CourseDto()
        {
            
        }
        private List<CourseDto> _listItem;

        private List<CourseDto> ListItem
        {
            get => _listItem;
            set => _listItem = value;
        }

        public async Task<List<CourseDto>> GetList(int pageIndex, int pageSize)
        {
            try
            {
                _listItem = await Current?.GetAsync<List<CourseDto>>("curso/getall");
                return ListItem.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<CourseDto> CreateCourses(CourseDto courseDto)
        {
            
            try
            {                
                //
                var course = await WebApi.Current.PostAsync<CourseDto>("curso/save", courseDto);
      
                return course;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw new System.Exception("Error: In Synced this User");
            }
        }

        
    }

}
