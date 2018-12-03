using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Welic.App.Models.Course;
using Welic.App.Models.Live;
using Welic.App.Models.Usuario;
using Welic.App.Services;
using Welic.App.Services.API;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class CreateLiveViewModel : BaseViewModel
    {

        public Command CreatCommand => new Command(CreateNew);
        public Command PickFileCommand => new Command(async () => await PickFile());
        

        private MediaFile _mediaFile;
        private string _path;

        public string TextButton { get; set; }
        public string TitleNavigation { get; set; }
        public string Icon { get; set; }

        private string _title;
        public new string Title
        {
            get => _title;
            set => SetProperty(ref _title , value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description , value);
        }

        private decimal _price;
        public decimal Price
        {
            get => _price;
            set => SetProperty(ref _price , value);
        }

        private string _themes;
        public string Themes
        {
            get => _themes;
            set => SetProperty(ref _themes , value);
        }

        private bool _chat;
        public bool Chat
        {
            get => _chat;
            set => SetProperty(ref _chat , value);
        }

        private string _pathFiles;
        public string PathFiles
        {
            get => _pathFiles;
            set => SetProperty(ref _pathFiles , value);
        }
        private bool _MenuVisivel;

        public bool MenuVisivel
        {
            get => _MenuVisivel;
            set => SetProperty(ref _MenuVisivel , value);
        }


        public CourseDto Dto { get; set; }

        public CreateLiveViewModel()
        {
            TitleNavigation = "Creat New Live";
            Icon = Util.ImagePorSistema("LogoWelic72x72.png");
            TextButton = "Criar";
            Chat = true;
            MenuVisivel = false;
        }
        public CreateLiveViewModel(params object[] obj)
        {
            TitleNavigation = "Creat New Live";
            Icon = Util.ImagePorSistema("LogoWelic72x72.png");
            TextButton = "Criar";
            Chat = true;
            Dto = (CourseDto) obj[0];
            MenuVisivel = true;
        }

        private async void CreateNew()
        {
            try
            {
                if (IsBusy)
                    return;

                var user = new UserDto().LoadAsync();
                IsBusy = true;

                using (var content = new MultipartFormDataContent())
                {
                    using (var stream = new StreamContent(_mediaFile.GetStream()))
                    {

                        _path =
                            $"Video-{user.LastName}_{user.Id}_{Util.RemoveCaracter(DateTime.Now.ToString())}.{_mediaFile.Path.Split('.').LastOrDefault()}";
                        var _pathImage =
                            $"{user.LastName}_{user.Id}_{Util.RemoveCaracter(DateTime.Now.ToString())}.jpg";

                        content.Add(stream, "file", _path);

                        await WebApi.Current.UploadAsync(content);

                        var live = new LiveDto
                        {
                            Title = _title,
                            Description = _description,
                            Price = _price,
                            Themes = _themes,
                            Chat = _chat,
                            UrlDestino = $"https://www.welic.app/Arquivos/Uploads/{_path}",
                            CourseId = Dto.IdCurso,
                            TeacherId = user.Id,
                            Print = $"https://www.welic.app/Arquivos/Uploads/{_pathImage}",
                            DateRegister = DateTime.Now
                        };

                        var ret = await (new LiveDto()).Save(live);

                        if (ret != null)
                            //await NavigationService.NavigateModalToAsync<LiveViewModel>();
                            await NavigationService.ReturnModalToAsync(true);


                        //content.Dispose();                        
                    }
                }
            }
            catch (System.Exception e)
            {
                IsBusy = false;
                Console.WriteLine(e);
                await MessageService.ShowOkAsync("Erro", "Erro ao Criar", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task PickFile()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickVideoSupported)
            {
                await MessageService.ShowOkAsync("No PickVideo", ":( No Pick Available.", "OK");
            }

            _mediaFile = await CrossMedia.Current.PickVideoAsync();

            if (_mediaFile == null)
                return;

            _pathFiles = $"{_mediaFile.Path.Split('/').LastOrDefault()}";
            //_pathFiles += _mediaFile.Path.LastOrDefault();
        }

        public Command ReturnCommand => new Command(Return);

        private async void Return()
        {
            await NavigationService.ReturnModalToAsync(true);
        }
    }
}
