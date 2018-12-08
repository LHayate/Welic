using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Welic.App.Models.Live;
using Welic.App.Services.API;

namespace Welic.App.Models.Search
{
    public class SearchDto
    {
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public SearchDto()
        {            
        }       

        public async Task<ObservableCollection<SearchDto>> SearchClient(string text)
        {
            try
            {
                var result = await WebApi.Current.GetAsync<ObservableCollection<LiveDto>>($"live/GetSearchListLive/{text}");

                ObservableCollection<SearchDto> search = new ObservableCollection<SearchDto>();
                foreach (LiveDto item in result)
                {
                    search.Add(new SearchDto { Image = File.ReadAllBytes(item.Print), Name = item.Title, Description = item.Description, Location = item.Themes });
                }

                return search;
            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                return null;
            }            
        }
    }
}
