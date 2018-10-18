using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Java.Util;
using Welic.App.Models.Live;
using Welic.App.Services.VideoPlayer;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class LiveViewModel : BaseViewModel
    {
        public Command PlayCommand => new Command(async () => await PlayVideo());

        public string Title { get; set; }
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


        public LiveViewModel()
        {
            
        }
        public LiveViewModel(params object[] obj)
        {
            _liveDto = (LiveDto)obj[0];

            UrlDestino = SourceVideo();
            Title = _liveDto.Title;
            Description = _liveDto.Description;
        }
        public async Task PlayVideo()
        {
            UrlDestino = SourceVideo(); 

        }

        public VideoSource SourceVideo()
        {
            return VideoSource.FromUri(_liveDto.UrlDestino);
        }
    }
}
