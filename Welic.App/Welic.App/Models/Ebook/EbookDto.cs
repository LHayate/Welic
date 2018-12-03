using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Welic.App.Services.API.WebApi;

namespace Welic.App.Models.Ebook
{
    public class EbookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Themes { get; set; }
        public string Print { get; set; }
        public string UrlDestino { get; set; }
        public DateTime DateRegister { get; set; }
        public int CourseId { get; set; }        
        public string TeacherId { get; set; }

        public EbookDto()
        {
            
        }


        public async Task<EbookDto> Save(EbookDto liveDto)
        {
            try
            {
                liveDto.DateRegister = DateTime.Now;
                return liveDto != null ? await Current?.PostAsync("ebook/Save", liveDto) : null;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


    }
}
