using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Welic.App.Services.API;
using static Welic.App.Services.API.WebApi;

namespace Welic.App.Models.News
{
    public class NewsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }

       
        private List<NewsDto> _listItem;

        private List<NewsDto> ListItem
        {
            get => _listItem;
            set => _listItem = value;
        }

        public async Task<List<NewsDto>> GetList(int pageIndex, int pageSize)
        {
            try
            {
                _listItem = await Current?.GetAsync<List<NewsDto>>("live/GetListLive");
                return ListItem.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
