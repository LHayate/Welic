using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.News.Dtos;

namespace Welic.Dominio.Models.News.Services
{
    public interface IServiceNews
    {
        NewsDto Save(NewsDto newsDto);
        NewsDto GetById(int id);
        List<NewsDto> GetList();
        bool Delete(int id);
    }
}
