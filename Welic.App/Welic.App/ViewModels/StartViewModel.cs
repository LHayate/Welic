using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Welic.App.Models.Live;
using Welic.App.ViewModels.Base;

namespace Welic.App.ViewModels
{
    public class StartViewModel: BaseViewModel
    {        
        public ObservableCollection<LiveDto> ListStart { get; private set; }
    

        public StartViewModel()
        {            
            ListStart = new ObservableCollection<LiveDto>();
            GetDados();
        }

        public async Task GetDados()
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
