using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Models.Usuario;
using static Welic.App.Services.API.WebApi;

namespace Welic.App.Models.Live
{
    public class LiveDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Themes { get; set; }
        public bool Chat { get; set; }
        public byte[] Print { get; set; }
        public string UrlDestino { get; set; }
        public UserDto Author { get; set; }

        public LiveDto()
        {
            
        }

        private List<LiveDto> _listItem;

        private List<LiveDto> ListItem
        {
            get => _listItem;
            set => _listItem = value;
        }

        public async Task<List<LiveDto>> GetList(int pageIndex, int pageSize)
        {
            try
            {
                _listItem = await Current?.GetAsync<List<LiveDto>>("live/GetListLive");
                return ListItem.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<LiveDto> Save(LiveDto liveDto)
        {
            try
            {
                liveDto.Author = (new UserDto()).LoadAsync();
                return liveDto != null ? await Current?.PostAsync("live/Save", liveDto) : null;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
