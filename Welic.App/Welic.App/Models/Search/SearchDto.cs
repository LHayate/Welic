using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Welic.App.Models.Course;
using Welic.App.Models.Ebook;
using Welic.App.Models.Live;
using static Welic.App.Services.API.WebApi;

namespace Welic.App.Models.Search
{
    public class SearchDto
    {
        public string Image { get; set; }
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
                var resultLive = await Current.GetAsync<ObservableCollection<LiveDto>>($"live/GetSearchListLive/{text}");                
                

                ObservableCollection<SearchDto> search = new ObservableCollection<SearchDto>();
                foreach (LiveDto item in resultLive)
                {
                    search.Add(new SearchDto { Image = item.Print, Name = item.Title, Description = item.Description, Location = item.Themes });
                }

                var resultEbook = await Current.GetAsync<ObservableCollection<EbookDto>>($"ebook/getsearchlist/{text}");
                foreach (EbookDto item in resultEbook)
                {
                    search.Add(new SearchDto { Image = item.Print, Name = item.Title, Description = item.Description, Location = item.Themes });
                }

                return search;
            }
            catch (AppCenterException e)
            {
                Console.WriteLine(e);
                return null;
            }            
        }

        public async Task<ObservableCollection<SearchDto>> SearchCursos(string text)
        {
            try
            {
                var resultLive = await Current.GetAsync<ObservableCollection<CourseDto>>($"curso/GetSearchListCurso/{text}");

                ObservableCollection<SearchDto> search = new ObservableCollection<SearchDto>();
                foreach (CourseDto item in resultLive)
                {
                    search.Add(new SearchDto { Image = item.Print, Name = item.Title, Description = item.Description, Location = item.Themes });
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
