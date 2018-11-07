using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Plugin.FileUploader;
using Plugin.FileUploader.Abstractions;
using Plugin.Media;
using Plugin.Media.Abstractions;
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

        public Command CreatCommand => new Command(async () => CreateNew());
        public Command PickFileCommand => new Command(async () => await PickFile());
        

        private MediaFile _mediaFile;
        private string path;

        public string TextButton { get; set; }
        public string TitleNavigation { get; set; }
        public string Icon { get; set; }

        private string _title;

        public string Title
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

        private string _price;

        public string Price
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
            get { return _pathFiles; }
            set { SetProperty(ref _pathFiles , value); }
        }

        public CreateLiveViewModel()
        {
            TitleNavigation = "Creat New Live";
            Icon = Util.ImagePorSistema("LogoWelic72x72.png");
            TextButton = "Criar";
            Chat = true;
        }

        private async void CreateNew()
        {
            try
            {
                if (IsBusy)
                    return;

                var user = new UserDto().LoadAsync();
                using (var content = new MultipartFormDataContent())
                {
                    using (var stream = new StreamContent(_mediaFile.GetStream()))
                    {                        
                        path = $"\\{user.LastName}_{user.UserId}_{_mediaFile.Path.Split('/').LastOrDefault()}";
                        content.Add(stream, "file", path);

                        await WebApi.Current.UploadAsync("uploads/files", content);


                        //await WebApi.Current.UploadAsync("uploads/files", content);


                        
                        content.Dispose();                        
                    }                    
                }
                this.IsBusy = true;

                //var content = new MultipartFormDataContent();

                //content.Add(new StreamContent(_mediaFile.GetStream()),
                //    "\"file\"",
                //    $"\"{_mediaFile.Path}\"");
                                                          
                var live = new LiveDto
                {
                    Title = _title,
                    Description = _description,
                    Price = decimal.Parse(_price),
                    Themes = _themes,
                    Chat = _chat,
                    Author = user,
                    UrlDestino = $"https://www.welic.app/uploads/{PathFiles}",
                };

                var ret = await (new LiveDto()).Save(live);

                if (ret != null)
                    await NavigationService.NavigateModalToAsync<LiveViewModel>();
            }
            catch (System.Exception e)
            {
                IsBusy = false;
                Console.WriteLine(e);
                await MessageService.ShowOkAsync("Erro", "Erro ao Criar","OK");
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

            
            _pathFiles += _mediaFile.Path;
        }

    }
}
