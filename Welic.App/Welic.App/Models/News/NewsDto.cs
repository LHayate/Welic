using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Services.API;

namespace Welic.App.Models.News
{
    public class NewsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }

        public async Task<ObservableCollection<NewsDto>> GetListLive()
        {
            try
            {
                var list = await WebApi.Current.GetListAsync<NewsDto>("News/GetList");
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
