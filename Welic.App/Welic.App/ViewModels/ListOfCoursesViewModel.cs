using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Welic.App.Models.Course;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

namespace Welic.App.ViewModels
{
    public class ListOfCoursesViewModel : BaseViewModel
    {        
        public Command AddNewCommand => new Command(AddNew);
        
        private ObservableCollection<CourseDto> _listStart;

        public ObservableCollection<CourseDto> ListStart
        {
            get => _listStart;
            set => SetProperty(ref _listStart, value);
        }


        public ListOfCoursesViewModel()
        {
            Atualizando = true;

            SetListCourses();

            Atualizando = false;           
        }

        public async Task SetListCourses()
        {
            ListStart = await new CourseDto().GetList();
        }
        
        private void AddNew()
        {
            NavigationService.NavigateModalToAsync<CreateCoursesViewModel>();
        }

        public void OpenCourse(CourseDto courseDto)
        {
            object[] obj = new[] { courseDto };

            NavigationService.NavigateModalToAsync<CourseDetailViewModel>(obj);
        }


        private bool _atualizando = false;
        public bool Atualizando
        {
            get { return _atualizando; }
            set
            {
                SetProperty(ref _atualizando, value);
            }
        }
        public ICommand AtualizarCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Atualizando = true;

                    await SetListCourses();

                    Atualizando = false;
                });
            }
        }
    }
}
