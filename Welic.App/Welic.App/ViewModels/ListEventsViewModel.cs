using System;
using System.Threading.Tasks;
using Welic.App.Models.Schedule;
using Welic.App.Services;
using Welic.App.ViewModels.Base;
using Xamarin.Forms.Extended;

namespace Welic.App.ViewModels
{
    public class ListEventsViewModel: BaseViewModel
    {
        private bool _NotFound;

        public bool NotFound
        {
            get => _NotFound;
            set => SetProperty(ref _NotFound, value);
        }

        private const int PageSize = 4;
        public string Schedule{ get; private set; }
        public string ImageUrl { get; private set; }
        public string Title { get; set; }

        public InfiniteScrollCollection<ScheduleDto> ListSchedule { get; private set; }


        public ListEventsViewModel()
        {
            Schedule = Util.ImagePorSistema("iSchedule");
            ImageUrl = Util.ImagePorSistema("iScheduleList");
            Title = "Schedule";
            ListSchedule = new InfiniteScrollCollection<ScheduleDto>();
            GetData();
            Download();
        }

        //public async Task GetData()
        //{
        //    try
        //    {
        //        var list = await (new ScheduleDto()).GetListLive();
        //        foreach (var scheduleDto in list)
        //        {
        //            ListSchedule.Add(scheduleDto);
        //        }
        //    }
        //    catch (System.Exception e)
        //    {
        //        Console.WriteLine(e);
        //        return;
        //    }
        //}
        private async Task GetData()
        {
            try
            {
                ListSchedule = new InfiniteScrollCollection<ScheduleDto>
                {
                    OnLoadMore = async () =>
                    {
                        IsBusy = true;

                        // Ler a proxima pagina
                        var page = ListSchedule.Count / PageSize;

                        //Busca os itens
                        var items = await (new ScheduleDto().GetList(page, PageSize));

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
            var items = await (new ScheduleDto().GetList(pageIndex: 0, pageSize: PageSize));

            ListSchedule.AddRange(items);
            NotFound = ListSchedule.Count <= 0;
        }
    }
}
