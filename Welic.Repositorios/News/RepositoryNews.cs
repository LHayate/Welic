using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.News.Maps;
using Welic.Infra.Context;

namespace Welic.Repositorios.News
{
    //public class RepositoryNews : IRepositoryNews
    //{
    //    private AuthContext _context;

    //    public RepositoryNews(AuthContext context)
    //    {
    //        _context = context;
    //    }

    //    private IQueryable<NewsMap> Query()
    //    {
    //        return _context.News;
    //    }

    //    public void Save(NewsMap newsMap)
    //    {
    //        var news = GetById(newsMap.Id);
    //        if (news != null)
    //            _context.Entry(news).State = EntityState.Modified;
    //        else
    //            _context.News.Add(newsMap);

    //        _context.SaveChanges();

    //    }

    //    public NewsMap GetById(int id)
    //    {
    //        return _context.News.FirstOrDefault(x=> x.Id == id);
    //    }

    //    public List<NewsMap> GetList()
    //    {
    //        return Query()
    //            .OrderBy(x => x.Date)
    //            .ToList();
    //    }

    //    //TODO: Tratar quando for null
    //    public void Delete(int id)
    //    {
    //        var news = GetById(id);
    //        if (news == null) return;
    //        _context.News.Remove(news);
    //        _context.SaveChanges();

    //    }


    //}
}
