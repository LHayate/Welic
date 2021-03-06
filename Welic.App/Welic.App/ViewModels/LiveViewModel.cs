﻿using System;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Welic.App.Helpers.Resources;
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

        public LiveDto LiveDto { get; set; }

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
            LiveDto = (LiveDto)obj[0];

            var user = new UserDto().LoadAsync();

            if (LiveDto.TeacherId.Equals(user.Id))
                BoolModificar = true;



            ValidaEditor();
            

            UrlDestino = SourceVideo();
            Title = LiveDto.Title;
            Description = LiveDto.Description;
        }

        private void ValidaEditor()
        {
            var user = new UserDto().LoadAsync();

            if (LiveDto.TeacherId == user.Id)
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
            return VideoSource.FromUri(LiveDto.UrlDestino);
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
                object[] obj = new object[] {null, LiveDto, _BoolModificar };

                await NavigationService.NavigateModalToAsync<CreateLiveViewModel>(obj);
            }
            catch (System.Exception e)
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
                var result = await MessageService.ShowOkAsync(AppResources.Confirm, $"{AppResources.Confirm_Delete} {AppResources.Video}",
                    AppResources.Yes, AppResources.No);                

                if (result)
                    if (await new LiveDto().DeleteAsync(LiveDto))
                        await NavigationService.ReturnModalToAsync(true);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                await MessageService.ShowOkAsync(AppResources.Error_Deleting);
            }
        }
    }
}
