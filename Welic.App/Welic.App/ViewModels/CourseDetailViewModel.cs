using System;
using System.Threading.Tasks;
using Welic.App.Models.Course;
using Welic.App.Models.Live;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

namespace Welic.App.ViewModels
{
    public class CourseDetailViewModel: BaseViewModel
    {

        public Command AddVideoCommand => new Command(AddVideo);

        

        private string _title;

        public new string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        private string _description;

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private decimal _price;

        public decimal Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        private string _themes;

        public string Themes
        {
            get => _themes;
            set => SetProperty(ref _themes, value);
        }

        private byte[] _image;

        public byte[] Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        private int _id;

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public CourseDto Dto { get; set; }

        private const int PageSize = 1;
        public InfiniteScrollCollection<LiveDto> ListStart { get; private set; }

        public CourseDetailViewModel(params object[] obj)
        {
            try
            {
                
                var course = Dto = (CourseDto)obj[0];
                _title = course.Title;
                _description = course.Description;
                _price = course.Price;
                _themes = course.Themes;
                _image = course.Print;
                _id = course.IdCurso;

                ListStart = new InfiniteScrollCollection<LiveDto>();
                GetDados();
                Download();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);                
            }
            

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
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return;
            }

        }
        private async Task Download()
        {
            var items = await (new LiveDto().GetList(pageIndex: 0, pageSize: PageSize));

            ListStart.AddRange(items);
        }

        private void AddVideo()
        {
            object[] obj = new[] { Dto };
            NavigationService.NavigateModalToAsync<CreateLiveViewModel>(obj);
        }

        public CourseDetailViewModel()
        {
            
        }
    }
}
