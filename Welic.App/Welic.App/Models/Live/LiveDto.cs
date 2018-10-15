using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Services.API;

namespace Welic.App.Models.Live
{
    public class LiveDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Prince { get; set; }
        public string Themes { get; set; }
        public bool Chat { get; set; }
        public byte[] Print { get; set; }
        public string UrlDestino { get; set; }

        public LiveDto()
        {
            
        }

        public async Task<ObservableCollection<LiveDto>> GetListLive()
        {
            try
            {
                var list = await WebApi.Current.GetListAsync<LiveDto>("live/GetListLive");
                return list;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
