using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AppCenter;
using Plugin.Connectivity;
using Welic.App.Models.Dispositivos.Dto;
using Welic.App.Services.Timing;
using Welic.App.ViewModels.Base;
using Device = Xamarin.Forms.Device;

namespace Welic.App.ViewModels
{
    public class MainViewModel :BaseViewModel
    {
        private readonly ITiming _timing;
        public MainViewModel(ITiming timing)
        {
            _timing = timing;

            // Atualiza informações a cada 24 horas
            Device.StartTimer(TimeSpan.FromMinutes(5),
                Callback);                       
        }

        private bool Callback()
        {
            try
            {
                if (_timing.ConsultDataNoTiming())
                {
                    _timing.SincDatas();
                }
            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                MessageService.ShowOkAsync("Dados Não Sincronizados!");
            }

            return true;
        }


    }
}
