using System;
using Welic.App.Models.Course;
using Welic.App.ViewModels.Base;

namespace Welic.App.ViewModels
{
    public class CourseDetailViewModel: BaseViewModel
    {
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

        public CourseDetailViewModel(params object[] obj)
        {
            try
            {
                var course = (CourseDto)obj[0];
                _title = course.Title;
                _description = course.Description;
                _price = course.Price;
                _themes = course.Themes;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);                
            }
            

        }

        public CourseDetailViewModel()
        {
            
        }
    }
}
