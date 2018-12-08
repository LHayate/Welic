using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Models.Ebook;
using Welic.App.Models.Live;
using Welic.App.Services;
using Welic.App.ViewModels.Base;
using Xamarin.Forms.Extended;

namespace Welic.App.ViewModels
{
    public class ListEBookViewModel: BaseViewModel
    {
        private bool _NotFound;

        public bool NotFound
        {
            get => _NotFound;
            set => SetProperty(ref _NotFound, value);
        }

        private const int PageSize = 4;
        public InfiniteScrollCollection<EbookDto> ListStart { get; private set; }

        public string IconPdf { get; }

        public ListEBookViewModel()
        {
            IconPdf = Util.ImagePorSistema("iPdf");
            ListStart = new InfiniteScrollCollection<EbookDto>();
            GetDados();
            Download();

        }

        private async Task GetDados()
        {
            try
            {
                ListStart = new InfiniteScrollCollection<EbookDto>
                {
                    OnLoadMore = async () =>
                    {
                        IsBusy = true;

                        // Ler a proxima pagina
                        var page = ListStart.Count / PageSize;

                        //Busca os itens
                        var items = await (new EbookDto().GetList(page, PageSize));

                        IsBusy = false;

                        // Itens que serão adicionados
                        return items;
                    }
                };

            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                return;
            }

        }

        private async Task Download()
        {
            var items = await (new EbookDto().GetList(pageIndex: 0, pageSize: PageSize));

            ListStart.AddRange(items);
            NotFound = ListStart.Count <= 0;
        }

        public void OpenLive(EbookDto ebook)
        {
            object[] obj = new[] { ebook };

            NavigationService.NavigateModalToAsync<EbookViewModel>(obj);
        }
    }
}
