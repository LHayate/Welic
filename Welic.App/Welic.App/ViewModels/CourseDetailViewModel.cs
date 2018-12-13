using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.AppCenter;
using Welic.App.Helpers.Resources;
using Welic.App.Models.Course;
using Welic.App.Models.Live;
using Welic.App.Services;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

namespace Welic.App.ViewModels
{
    public class CourseDetailViewModel: BaseViewModel
    {

        #region Fields e Property


        private string _AppTitle;

        public string AppTitle
        {
            get => _AppTitle;
            set => SetProperty(ref _AppTitle , value);
        }

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
        

        private int _id;

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public CourseDto Dto { get; set; }

        private const int PageSize = 1;
        private ObservableCollection<LiveDto> _listStart;

        public ObservableCollection<LiveDto> ListStart
        {
            get => _listStart;
            set => SetProperty(ref _listStart, value);
        }

        private bool _BoolModificar;

        public bool BoolModificar
        {
            get => _BoolModificar;
            set => SetProperty(ref _BoolModificar, value);
        }

        #endregion

        
        #region Constructor
        
        public CourseDetailViewModel(params object[] obj)
        {
            try
            {
                PreencheTela((CourseDto)obj[0]);

                if (obj.Length > 1)
                {
                    BoolModificar = (bool)obj[1];
                }
                else
                {
                    BoolModificar = true;
                }
            }
            catch (System.Exception e)
            {
                AppCenterLog.Error("Erro in Course",$"{e.Message}-{e.InnerException}");
                Console.WriteLine(e);                
            }            
        }
#endregion


        private void PreencheTela(CourseDto courseDto)
        {
            Dto = courseDto;

            _AppTitle = AppResources.Detail_course;            
            Title = courseDto.Title;
            Description = courseDto.Description;
            Price = courseDto.Price;
            Themes = courseDto.Themes;            
            Id = courseDto.IdCurso;
                   
        }

        public async void LoadTela()
        {
            this.PreencheTela(await new CourseDto().GetById(Dto.IdCurso));
        }

        public async Task GetListLives()
        {
            ListStart = await new LiveDto().GetListByCourse(Dto);
            IsBusy = ListStart.Count <= 0;
        }
        private bool _atualizando = false;
        public bool Atualizando
        {
            get { return _atualizando; }
            set
            {
                SetProperty(ref _atualizando, value);
            }
        }
        public ICommand AtualizarCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Atualizando = true;

                    await GetListLives();

                    Atualizando = false;
                });
            }
        }

        public Command AddVideoCommand => new Command(AddVideo);
        private void AddVideo()
        {
            object[] obj = new[] { Dto, null };
            NavigationService.NavigateModalToAsync<CreateLiveViewModel>(obj);
        }

        public Command ReturnCommand => new Command(ReturnDetail);       
        private async void ReturnDetail()
        {
            await NavigationService.ReturnModalToAsync(true);
        }

        public Command AddEBookCommand => new Command(AddEbook);
        private void AddEbook()
        {
            object[] obj = { Dto };
            NavigationService.NavigateModalToAsync<CreateEbookViewModel>(obj);
        }
        public Command EditCommand => new Command(Edit);

        private async void Edit()
        {
            object[] obj = new[] { Dto };

            await NavigationService.NavigateModalToAsync<CreateCoursesViewModel>(obj);
        }

        public Command ExcluirCommand => new Command(delete);

        private async void delete()
        {
            try
            {
                var result = await MessageService.ShowOkAsync(AppResources.Delete, AppResources.Confirm_Delete + AppResources.Schedule,
                    AppResources.Yes, AppResources.No);

                var live =await new LiveDto().GetListByCourse(Dto);

                if (live.Count > 0)
                {
                    await MessageService.ShowOkAsync(
                        AppResources.Not_Delete_Courses);                    
                    return;
                }
                          
                if (result)
                    if (await new CourseDto().DeleteAsync(Dto))
                        await NavigationService.ReturnModalToAsync(true);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                await MessageService.ShowOkAsync(AppResources.Error_Deleting);
            }
        }

        public void OpenLive(LiveDto liveDto)
        {
            object[] obj = { liveDto };

            NavigationService.NavigateModalToAsync<LiveViewModel>(obj);
        }
    }
}
