using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Welic.App.Models.Live;
using Welic.App.Models.News;
using Welic.App.Services;
using Welic.App.ViewModels.Base;
using Xamarin.Forms.Extended;

namespace Welic.App.ViewModels
{
    public class ListNewsViewModel :BaseViewModel
    {
        private const int PageSize = 2;
        public InfiniteScrollCollection<NewsDto> ListNews { get; private set; }

        public string News { get; }

        public ListNewsViewModel()
        {
            News = Util.ImagePorSistema("iNew");
            ListNews = new InfiniteScrollCollection<NewsDto>();
            GetData();
            Download();
        }        
       
        private async Task GetData()
        {
            try
            {
                ListNews = new InfiniteScrollCollection<NewsDto>
                {
                    OnLoadMore = async () =>
                    {
                        IsBusy = true;

                        // Ler a proxima pagina
                        var page = ListNews.Count / PageSize;

                        //Busca os itens
                        var items = await (new NewsDto().GetList(page, PageSize));

                        IsBusy = false;

                        // Itens que serão adicionados
                        return items;
                    }
                };

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return;
            }

        }
        private async Task Download()
        {
            var items = await (new NewsDto().GetList(pageIndex: 0, pageSize: PageSize));

            ListNews.AddRange(items);
        }

        public void OpenLive(NewsDto newsDto)
        {
            object[] obj = new[] { newsDto };

            NavigationService.NavigateModalToAsync<NewsViewModel>(obj);
        }
    }
}
