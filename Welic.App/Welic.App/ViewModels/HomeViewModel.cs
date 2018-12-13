using System;
using Microsoft.AppCenter;
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
                _news = Util.ImagePorSistema("iNew");              
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return;
            }
            
        }        

        
    }
}
