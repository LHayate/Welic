using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Welic.App.Helpers.Resources;
using Welic.App.Models.Course;
using Welic.App.Models.Ebook;
using Welic.App.Models.Live;
using Welic.App.Models.Usuario;
using Welic.App.Services;
using Welic.App.Services.API;
using Welic.App.ViewModels.Base;
using Welic.App.Views;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class CreateEbookViewModel : BaseViewModel
    {
        public string AddPdf { get; set; }
        public Command PickFileCommand => new Command(async () => await PickFile());
        public Command CreateCommand { get; set; }

        private byte[] _mediaFile;
        
        private string _pathName;

        public string PathName
        {
            get { return _pathName; }
            set { _pathName = value; }
        }

        private string _AppTitle;

        public string AppTitle
        {
            get => _AppTitle;
            set => SetProperty(ref _AppTitle, value);
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

        private bool _chat;
        public bool Chat
        {
            get => _chat;
            set => SetProperty(ref _chat, value);
        }

        private string _pathFiles;
        public string PathFiles
        {
            get => _pathFiles;
            set => SetProperty(ref _pathFiles, value);
        }

        public CourseDto courseDto { get; set; }
        public EbookDto EbookDto { get; set; }

        private bool _MenuVisivel;

        public bool MenuVisivel
        {
            get => _MenuVisivel;
            set => SetProperty(ref _MenuVisivel, value);
        }
        //public CreateEbookViewModel()
        //{
        //    MenuVisivel = false;
        //}

        public CreateEbookViewModel(params object[] obj)
        {                                    
            if (obj.Length <= 0)
            {
                _AppTitle = $"{AppResources.Create} {AppResources.EBook}";
                CreateCommand = new Command(CreateNew);
            }
            else
            {                
                courseDto = obj.Length > 0 ? (CourseDto)obj[0] : null;
                EbookDto = obj.Length > 0 ? (EbookDto)obj[1] : null;
                MenuVisivel = true;
                if (EbookDto == null && courseDto != null)
                {
                    _AppTitle = $"{AppResources.Create} {AppResources.EBook}";
                    CreateCommand = new Command(CreateNew);
                    return;
                }

                _AppTitle = $"{AppResources.Edit} {AppResources.EBook}";
                CreateCommand = new Command(Edit);
                _themes = EbookDto.Themes;
                _title = EbookDto.Title;
                _description = EbookDto.Description;
                _price = EbookDto.Price;
            }
        }

        private async Task PickFile()
        {
            try
            {
                FileData fileData = await CrossFilePicker.Current.PickFile();
                if (fileData == null)
                    return; // user canceled file picking

                _pathName = fileData.FileName;
                _mediaFile = fileData.DataArray;                            
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Exception choosing file: " + ex.ToString());
            }
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
                    var _Name =
                        $"Arquivo-{user.LastName}_{user.Id}_{Util.RemoveCaracter(DateTime.Now.ToString())}.{_pathName.Split('.').LastOrDefault()}".Replace(" ", string.Empty);

                    var stream = new StreamContent(new MemoryStream(_mediaFile));
                    content.Add(stream, "file", _Name);

                    await WebApi.Current.UploadAsync(content);

                    var book = new EbookDto
                    {
                        Title = _title,
                        Description = _description,
                        Price = _price,
                        Themes = _themes,
                        UrlDestino = $"https://welic.app/Arquivos/Uploads/{_Name}",
                        CourseId = courseDto != null ? courseDto.IdCurso : (int?)null ,
                        TeacherId = user.Id,
                        DateRegister = DateTime.Now
                    };


                    var ret = await (new EbookDto()).Save(book);
                    if (courseDto != null)
                    {
                        await MessageService.ShowOkAsync(AppResources.Success, $"{AppResources.EBook} {AppResources.Success_Create}", "OK");
                        if (ret != null)
                            await NavigationService.ReturnModalToAsync(true);
                    }
                    else
                    {
                        //object[] obj = new[] { ret };
                        //await NavigationService.NavigateModalToAsync<EbookViewModel>(obj);
                        await MessageService.ShowOkAsync(AppResources.Success, $"{AppResources.EBook} {AppResources.Success_Create}", "OK");
                        App.Current.MainPage = new MainPage();
                    }

                }
            }
            catch (System.Exception e)
            {
                IsBusy = false;
                Console.WriteLine(e);
                await MessageService.ShowOkAsync(AppResources.Error, $"{AppResources.Error_Create} {AppResources.EBook}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async void Edit()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                var user = new UserDto().LoadAsync();


                var _pathImage = string.Empty;
                if (_pathFiles != null)
                {
                    var content = new MultipartFormDataContent();                    

                    var _Name =
                        $"Arquivo-{user.LastName}_{user.Id}_{Util.RemoveCaracter(DateTime.Now.ToString())}.{_pathName.Split('.').LastOrDefault()}".Replace(" ", string.Empty);

                    var stream = new StreamContent(new MemoryStream(_mediaFile));
                    content.Add(stream, "file", _Name);

                    await WebApi.Current.UploadAsync(content);

                    EbookDto.UrlDestino = $"https://welic.app/Arquivos/Uploads/{_Name}";
                }

                EbookDto.Title = _title;
                EbookDto.Description = _description;
                EbookDto.Price = _price;
                EbookDto.Themes = _themes;

                EbookDto.DateRegister = DateTime.Now;


                var ret = await (new EbookDto()).Update(EbookDto);
                if (courseDto != null || EbookDto != null)
                {
                    await MessageService.ShowOkAsync(AppResources.Success, $"{AppResources.EBook} {AppResources.Success_Change}", "OK");
                    if (ret != null)
                        await NavigationService.ReturnModalToAsync(true);
                }
                else
                {
                    //object[] obj = new[] { ret };
                    //await NavigationService.NavigateModalToAsync<LiveViewModel>(obj);
                    await MessageService.ShowOkAsync(AppResources.Success, $"{AppResources.EBook} {AppResources.Success_Change}", "OK");
                }

                //content.Dispose();                                                                          
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                await MessageService.ShowOkAsync($"{AppResources.Error_Change} {AppResources.EBook}");
            }
            finally
            {
                IsBusy = false;
            }
        }
        public Command ReturnCommand => new Command(Return);

        private async void Return()
        {
            await NavigationService.ReturnModalToAsync(true);
        }
    }
}
