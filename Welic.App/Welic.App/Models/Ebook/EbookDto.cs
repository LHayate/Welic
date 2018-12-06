using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Models.Course;
using Welic.App.Models.Usuario;
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
        public int? CourseId { get; set; } 
        public string TeacherId { get; set; }

        public EbookDto()
        {
            
        }

        public async Task<EbookDto> Save(EbookDto ebookDto)
        {
            try
            {
                ebookDto.DateRegister = DateTime.Now;
                return await Current?.PostAsync<EbookDto>("ebook/Save", ebookDto);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private List<EbookDto> _listItem;

        private List<EbookDto> ListItem
        {
            get => _listItem;
            set => _listItem = value;
        }

        public async Task<List<EbookDto>> GetList(int pageIndex, int pageSize)
        {
            try
            {
                _listItem = await Current?.GetAsync<List<EbookDto>>("ebook/GetList");
                return ListItem.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public async Task<ObservableCollection<EbookDto>> GetList()
        {
            try
            {
                var list = await Current?.GetAsync<ObservableCollection<EbookDto>>("ebook/GetList");
                return list;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public async Task<ObservableCollection<EbookDto>> GetListRecente()
        {
            try
            {
                var list = await Current?.GetAsync<ObservableCollection<EbookDto>>("ebook/GetListRecentes");
                return list;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public async Task<ObservableCollection<EbookDto>> GetListFavoritos()
        {
            try
            {
                var list = await Current?.GetAsync<ObservableCollection<EbookDto>>("ebook/GetLisFavoritos");
                return list;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public async Task<ObservableCollection<EbookDto>> GetListByUser()
        {
            try
            {
                var user = new UserDto().LoadAsync();
                var list = await Current?.GetAsync<ObservableCollection<EbookDto>>($"ebook/GetListTeacher/{user.Id}");
                return list;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public async Task<List<EbookDto>> GetListByCourse(CourseDto courseDto, int pageIndex, int pageSize)
        {
            try
            {
                var list = await Current?.GetAsync<List<EbookDto>>($"ebook/GetListbyCourse/{courseDto.IdCurso}");
                return list.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
