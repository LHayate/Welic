using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Welic.App.Helpers.Resources;
using Welic.App.Implements.PDF;
using Welic.App.Implements.PDF.Interfaces;
using Welic.App.Models.Ebook;
using Welic.App.Models.Usuario;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Device = Xamarin.Forms.Device;

namespace Welic.App.ViewModels
{
    public class EbookViewModel: BaseViewModel
    {
        private string _urlPdf;

        public string UrlPdf
        {
            get => _urlPdf;
            set => SetProperty(ref _urlPdf, value);
        }

        public EbookDto EbookDto { get; set; }

        private bool _BoolModificar;

        public bool BoolModificar
        {
            get => _BoolModificar;
            set => SetProperty(ref _BoolModificar, value);
        }

        private async void SetEbook(EbookDto ebook)
        {
            IsBusy = true;

            if (await FileManager.ExistsAsync(ebook.Title) == false)
            {
                await FileManager.DownloadDocumentsAsync(ebook);
            }
            UrlPdf = FileManager.GetFilePathFromRoot(ebook.Title);

            IsBusy = false;
        }

        public EbookViewModel(params object[] obj)
        {

            EbookDto = (EbookDto)obj[0];
            var user = new UserDto().LoadAsync();

            if (EbookDto.TeacherId.Equals(user.Id))
                BoolModificar = true;
            else
                BoolModificar = false;


            SetEbook(EbookDto);
            
        }
        private static void ConvertToStream(string fileUrl, Stream stream)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fileUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            try
            {
                Stream response_stream = response.GetResponseStream();

                response_stream.CopyTo(stream, 4096);
            }
            finally
            {
                response.Close();
            }
        }

        public Command EditCommand => new Command(Edit);

        private async void Edit()
        {
            try
            {
                object[] obj = new object[] { EbookDto, _BoolModificar };

                await NavigationService.NavigateModalToAsync<CreateEbookViewModel>(obj);
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
                var result = await MessageService.ShowOkAsync(AppResources.Delete, $"{AppResources.Confirm_Delete} {AppResources.EBook}?",
                    AppResources.Yes, AppResources.No);

                if (result)
                    if (await new EbookDto().DeleteAsync(EbookDto))
                        await NavigationService.ReturnModalToAsync(true);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                await MessageService.ShowOkAsync(AppResources.Error_Deleting);
            }
        }
        public Command ReturnCommand => new Command(Return);

        private async void Return()
        {
            await NavigationService.ReturnModalToAsync(true);
        }
    }
}
