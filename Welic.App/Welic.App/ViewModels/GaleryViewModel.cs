using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Welic.App.Models.Course;
using Welic.App.Models.Live;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class GaleryViewModel : BaseViewModel
    {        
       
        public GaleryViewModel()
        {
          
            SetListCourses();
          
        }

        private ObservableCollection<LiveDto> _listSource;

        public ObservableCollection<LiveDto> ListSource
        {
            get => _listSource;
            set => SetProperty(ref _listSource, value);
        }

        public async Task SetListCourses()
        {
            _listSource = await new LiveDto().GetList();
        }
             
        public void OpenLive(LiveDto live)
        {
            object[] obj = new[] { live };

            NavigationService.NavigateModalToAsync<LiveViewModel>(obj);
        }
    }
}
