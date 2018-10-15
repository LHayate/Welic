using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Welic.App.Models.Live;
using Welic.App.Services;
using Welic.App.ViewModels.Base;

namespace Welic.App.ViewModels
{
    public class StartViewModel: BaseViewModel
    {        
        public ObservableCollection<LiveDto> ListStart { get; private set; }
        
        public string Home{get ;}

        public StartViewModel()
        {
            Home = Util.ImagePorSistema("iHome");
            ListStart = new ObservableCollection<LiveDto>();
            GetDados();
        }

        private async Task GetDados()
        {
            try
            {
                var list = await (new LiveDto().GetListLive());
                foreach (LiveDto result in list)
                {
                    ListStart.Add(result);
                }
                
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return;
            }
            
        }
    }
}
