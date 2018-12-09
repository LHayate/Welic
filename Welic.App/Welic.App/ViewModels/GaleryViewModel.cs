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
          
        }      

        public async Task<ObservableCollection<LiveDto>> GetListRecente()
        {
           return await new LiveDto().GetListRecente();
        }

        public async Task<ObservableCollection<LiveDto>> GetListFavorite()
        {
            return await new LiveDto().GetListFavoritos();
        }        

    public async Task<ObservableCollection<LiveDto>> GetListTeacher()
        {
            return await new LiveDto().GetListByUser();
        }

        public void OpenLive(LiveDto live)
        {
            object[] obj = new[] { live };

            NavigationService.NavigateModalToAsync<LiveViewModel>(obj);
        }
    }
}
