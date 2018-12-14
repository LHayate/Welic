using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Welic.App.Helpers.Resources;
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
        
        public Command CreateCommand { get; set; }
        
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

            if (obj.Length <= 0)
            {
                CreateCommand = new Command(CreateCourses);
            }
            else
            {
                _CourseDto = (CourseDto)obj[0];
                CreateCommand = new Command(Edit);
                _themes = _CourseDto.Themes;
                _title = _CourseDto.Title;
                _description = _CourseDto.Description;
                _price = _CourseDto.Price;
            }
                        
        }

        public Command ReturnCommand => new Command(async () => await ReturnToMenu());
        private async Task ReturnToMenu()
        {
            await NavigationService.ReturnModalToAsync(true);
        }
        private async void CreateCourses()
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
                await MessageService.ShowOkAsync(AppResources.Create, $"{AppResources.Course} {AppResources.Success_Create}", "OK");

                await NavigationService.ReturnModalToAsync(true);

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                await MessageService.ShowOkAsync($"{AppResources.Error_Create} {AppResources.Course}");
            }            
        }

        private async void Edit()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                
                _CourseDto.Description = _description;
                _CourseDto.Price = _price;
                _CourseDto.Themes = _themes;
                _CourseDto.Title = _title;                

                var ret = await new CourseDto().Edit(_CourseDto);


                if (ret != null)
                {
                    await MessageService.ShowOkAsync(AppResources.Edit, $"{AppResources.Course} {AppResources.Success_Change}", "OK");
                    await NavigationService.ReturnModalToAsync(true);
                }
                else
                {
                    throw new System.Exception($"{AppResources.Error_Change} {AppResources.Course}");
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                await MessageService.ShowOkAsync($"{AppResources.Error_Change} {AppResources.Course}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
