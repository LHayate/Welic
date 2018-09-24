using Welic.App.Services;
using Welic.App.ViewModels.Base;

namespace Welic.App.ViewModels
{
    public class HomeViewModel:BaseViewModel
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
            set => SetProperty(ref _search , value);
        }

        private string _home;

        public string Home
        {
            get => _home;
            set => _home = value;
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
            set => SetProperty(ref _news , value);
        }


        #endregion

        #endregion



        public HomeViewModel()
        {
            _star = Util.ImagePorSistema("star_icon");
            _search = Util.ImagePorSistema("iEncontrar32");
            _home = Util.ImagePorSistema("ihouse");
            _schedule = Util.ImagePorSistema("Schedule_icon");
            _news = Util.ImagePorSistema("News_Icon");


        }

    }
}
