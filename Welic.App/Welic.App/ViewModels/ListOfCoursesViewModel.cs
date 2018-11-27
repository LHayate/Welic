using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Models.Course;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

namespace Welic.App.ViewModels
{
    public class ListOfCoursesViewModel : BaseViewModel
    {
        private const int PageSize = 12;        
        public Command AddNewCommand => new Command(AddNew);

        public InfiniteScrollCollection<CourseDto> ListStart { get; private set; }

        public ListOfCoursesViewModel()
        {
            ListStart = new InfiniteScrollCollection<CourseDto>();
            GetDados();
            Download();
        }

        private async Task GetDados()
        {
            try
            {
                ListStart = new InfiniteScrollCollection<CourseDto>
                {
                    OnLoadMore = async () =>
                    {
                        IsBusy = true;

                        // Ler a proxima pagina
                        var page = ListStart.Count / PageSize;

                        //Busca os itens
                        var items = await (new CourseDto().GetList(page, PageSize));

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
            var items = await (new CourseDto().GetList(pageIndex: 0, pageSize: PageSize));

            ListStart.AddRange(items);
        }
        private void AddNew()
        {
            NavigationService.NavigateModalToAsync<CreateCoursesViewModel>();
        }

        public void OpenCourse(CourseDto courseDto)
        {
            object[] obj = new[] { courseDto };

            NavigationService.NavigateModalToAsync<CourseDetailViewModel>(obj);
        }



    }
}
