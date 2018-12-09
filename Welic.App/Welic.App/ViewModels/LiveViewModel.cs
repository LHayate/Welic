using System;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Welic.App.Models.Live;
using Welic.App.Models.Usuario;
using Welic.App.Services.VideoPlayer;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class LiveViewModel : BaseViewModel
    {
        public Command PlayCommand => new Command(async () => await PlayVideo());
        public Command AspectFillCommand => new Command(async () => await AspectFill());
       
        public new string Title { get; set; }
        public string Description { get; set; }

        private VideoSource _urlDestino;
        public VideoSource UrlDestino
        {
            get => _urlDestino;
            set => SetProperty(ref _urlDestino , value);
        }

        public LiveDto _liveDto { get; set; }

        private bool _btnPlay;
        public bool BtnPlay
        {
            get => _btnPlay;
            set => SetProperty(ref _btnPlay , value);
        }

        private bool _BoolModificar;

        public bool BoolModificar
        {
            get => _BoolModificar;
            set => SetProperty(ref _BoolModificar, value);
        }

        public LiveViewModel(params object[] obj)
        {
            _liveDto = (LiveDto)obj[0];
            
            ValidaEditor();
            

            UrlDestino = SourceVideo();
            Title = _liveDto.Title;
            Description = _liveDto.Description;
        }

        private void ValidaEditor()
        {
            var user = new UserDto().LoadAsync();

            if (_liveDto.TeacherId == user.Id)
            {
                _BoolModificar = true;
                return;
            }

            _BoolModificar = false;
        }

        public async Task PlayVideo()
        {
            UrlDestino = SourceVideo();
        }

        public VideoSource SourceVideo()
        {
            return VideoSource.FromUri(_liveDto.UrlDestino);
        }

        private async Task AspectFill()
        {
            object[] args = new[] {UrlDestino};
            await NavigationService.NavigateModalToAsync<AspectFillLiveViewModel>(args);
        }

        public Command ReturnCommand => new Command(Return);

        private async void Return()
        {
            await NavigationService.ReturnModalToAsync(true);
        }

        public Command EditCommand => new Command(Edit);

        private async void Edit()
        {
            try
            {
                object[] obj = new object[] { _liveDto, _BoolModificar };

                await NavigationService.NavigateModalToAsync<CreateLiveViewModel>(obj);
            }
            catch (AppCenterException e)
            {
                var msgerro = "Erro ao abrir para edição";
                AppCenterLog.Error("edit", msgerro);
                Console.WriteLine(e);
                await MessageService.ShowOkAsync(msgerro);
            }
            
        }

        public Command ExcluirCommand => new Command(delete);

        private async void delete()
        {
            try
            {
                var result = await MessageService.ShowOkAsync("Excluir", "Tem certeza que deseja excluir este video?",
                    "Sim", "Cancel");                

                if (result)
                    if (await new LiveDto().DeleteAsync(_liveDto))
                        await NavigationService.ReturnModalToAsync(true);
            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                await MessageService.ShowOkAsync("Erro ao Exclur Schedule");
            }
        }
    }
}
