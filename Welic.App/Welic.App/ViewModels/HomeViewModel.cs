using System;
using Welic.App.Services;
using Welic.App.Services.Timing;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region Propriedades
        #region Icons
        private string _star;

        public string Stars
        {
            get => _star;
            set => SetProperty(ref _star, value);
        }

        private string _search;

        public string Search
        {
            get => _search;
            set => SetProperty(ref _search, value);
        }

        private string _home;

        public string Home
        {
            get => _home;
            set => SetProperty(ref _home , value);
        }

        private string _schedule;

        public string Schedule
        {
            get => _schedule;
            set => SetProperty(ref _schedule, value);
        }

        private string _news;

        public string News
        {
            get => _news;
            set => SetProperty(ref _news, value);
        }


        #endregion

        #endregion

        
        public HomeViewModel()
        {
            try
            {               
                _star = Util.ImagePorSistema("iStar");
                _search = Util.ImagePorSistema("iFind");
                _home = Util.ImagePorSistema("iHome");
                _schedule = Util.ImagePorSistema("iSchedule");
                _news = Util.ImagePorSistema("iNew");              
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }        

        
    }
}
