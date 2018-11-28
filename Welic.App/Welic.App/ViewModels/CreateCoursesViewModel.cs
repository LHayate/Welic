using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Models.Course;
using Welic.App.Models.Live;
using Welic.App.Models.Usuario;
using Welic.App.Services;
using Welic.App.Services.API;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class CreateCoursesViewModel : BaseViewModel
    {
        public Command ReturnCommand => new Command(async () => await ReturnToMenu());
        public Command CreateCommand => new Command(async () => await CreateCourses());
        
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
        
        private CourseDto _CourseDto { get; set; }

        public CreateCoursesViewModel(params object[] obj)
        {
            _CourseDto = (CourseDto) obj[0];
            _themes = _CourseDto.Themes;
            _title = _CourseDto.Title;
            _description = _CourseDto.Description;
            _price = _CourseDto.Price;

        }

        public CreateCoursesViewModel()
        {
            
        }

        private async Task ReturnToMenu()
        {
            await NavigationService.ReturnModalToAsync(true);
        }
        private async Task CreateCourses()
        {
            try
            {
                var user = new UserDto().LoadAsync();

                var course = new CourseDto()
                {                    
                    Description = _description,
                    Price = _price,
                    Themes = _themes,
                    Title = _title,
                    AuthorId = user.Id,
                    Author = user,
                    
                };

                await new CourseDto().CreateCourses(course);
                await MessageService.ShowOkAsync("Create", "Curso Criado com Sucesso", "OK");

                await NavigationService.ReturnModalToAsync(true);

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                await MessageService.ShowOkAsync("Erro ao criar curso");
            }
            


        }
    }
}
