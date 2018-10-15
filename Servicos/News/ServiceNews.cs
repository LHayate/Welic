using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio;
using Welic.Dominio.Models.News.Adapters;
using Welic.Dominio.Models.News.Dtos;
using Welic.Dominio.Models.News.Maps;
using Welic.Dominio.Models.News.Repositoryes;
using Welic.Dominio.Models.News.Services;

namespace Servicos.News
{
    public class ServiceNews : Servico, IServiceNews
    {
        private readonly IRepositoryNews _repositoryNews;
        public  ServiceNews(IUnidadeTrabalho unidadeTrabalho, IRepositoryNews repositoryNews) : base(unidadeTrabalho)
        {
            _repositoryNews = repositoryNews;
        }

        public NewsDto Save(NewsDto newsDto)
        {
            var newsEncontrado = _repositoryNews.GetById(newsDto.Id);
            if (newsEncontrado != null)
            {                                
                newsEncontrado.Date = newsDto.Date;
                newsEncontrado.Url = newsDto.Url;
                newsEncontrado.Description = newsDto.Description;
                newsEncontrado.Title = newsDto.Title;
            }
            else
            {
                newsEncontrado = new NewsMap
                {
                    Id = newsDto.Id,
                    Date = newsDto.Date,
                    Url = newsDto.Url,
                    Description = newsDto.Description,
                    Title = newsDto.Title
                };
            }

            _repositoryNews.Save(newsEncontrado);

            return GetById(newsEncontrado.Id);
        }

        public NewsDto GetById(int id)
        {
            return AdapterNews.ConverterMapParaDto(_repositoryNews.GetById(id));
        }

        public List<NewsDto> GetList()
        {
            return AdapterNews.ConverterMapParaDto(_repositoryNews.GetList());
        }

        public bool Delete(int id)
        {
            _repositoryNews.Delete(id);
            return GetById(id) != null;
        }
    }
}
