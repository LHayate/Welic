using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Connectivity;
using Welic.App.Helpers.Resources;
using Welic.App.Models.Course;
using Welic.App.Models.Live;
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
            if (CrossConnectivity.Current.IsConnected)
            {
                ListStart = await new CourseDto().GetListByUser();
                IsBusy = ListStart.Count <= 0;
                return;
            }

            await MessageService.ShowOkAsync(AppResources.Not_Connected);
        }
        
        private void AddNew()
        {
            NavigationService.NavigateModalToAsync<CreateCoursesViewModel>();
        }

        public void OpenCourse(CourseDto courseDto)
        {
            if (courseDto == null)
            {
                MessageService.ShowOkAsync(AppResources.Not_course);
                return;
            }

            object[] obj = new[] { courseDto };

            if (obj.Length <= 0)
            {
                MessageService.ShowOkAsync(AppResources.Not_course);
                return;
            }

            NavigationService.NavigateModalToAsync<CourseDetailViewModel>(obj);
        }

        public async void DeleteLive(LiveDto liveDto)
        {
            await new LiveDto().DeleteAsync(liveDto);
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
