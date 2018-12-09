using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.AppCenter;
using Welic.App.Models.Live;
using Welic.App.Services;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

namespace Welic.App.ViewModels
{
    public class ListLiveViewModel: BaseViewModel
    {
        private bool _NotFound;

        public bool NotFound
        {
            get => _NotFound;
            set => SetProperty(ref _NotFound, value);
        }


        private const int PageSize = 6;
        public InfiniteScrollCollection<LiveDto> ListStart { get; private set; }        

        public string Home{get ;}

        public ListLiveViewModel()
        {                        
            Home = Util.ImagePorSistema("iHome");
            
            GetListLives();
        }

        private async Task GetDados()
        {
            try
            {
                ListStart = new InfiniteScrollCollection<LiveDto>
                {
                    OnLoadMore = async () =>
                    {
                        IsBusy = true;

                        // Ler a proxima pagina
                        var page = ListStart.Count / PageSize;

                        //Busca os itens
                        var items = await (new LiveDto().GetList(page, PageSize)); 

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
            var items = await (new LiveDto().GetList(pageIndex: 0, pageSize: PageSize));

            ListStart.AddRange(items);
            NotFound = ListStart.Count <= 0;
        }

        public void OpenLive(LiveDto liveDto)
        {
            object[] obj = new[] {liveDto};

            NavigationService.NavigateModalToAsync<LiveViewModel>(obj);
        }

        //private bool _atualizando = false;
        //public bool Atualizando
        //{
        //    get => _atualizando;
        //    set => SetProperty(ref _atualizando, value);
        //}
        //public ICommand AtualizarCommand
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //            Atualizando = true;

        //            await GetListLives();

        //            Atualizando = false;
        //        });
        //    }
        //}

        public async Task GetListLives()
        {
            ListStart = new InfiniteScrollCollection<LiveDto>();
            GetDados();
            Download();
            NotFound = ListStart.Count <= 0;
        }
    }
}
