using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Welic.App.Models.News;
using Welic.App.Services;
using Welic.App.ViewModels.Base;

namespace Welic.App.ViewModels
{
    public class NewsViewModel :BaseViewModel
    {
        public ObservableCollection<NewsDto> ListNews { get; private set; }

        public string News { get; }

        public NewsViewModel()
        {
            News = Util.ImagePorSistema("iNew");
            ListNews = new ObservableCollection<NewsDto>();
            GetDados();
        }        

        private async Task GetDados()
        {
            try
            {
                var list = await (new NewsDto().GetListLive());
                foreach (var result in list)
                {
                    ListNews.Add(result);
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
