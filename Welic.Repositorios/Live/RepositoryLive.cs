﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Infra.Context;
using Welic.Dominio.Models.Lives.Maps;
using Welic.Dominio.Models.Lives.Repositoryes;

namespace Repositorios.Live
{
    public class RepositoryLive: IRepositoryLive
    {
        private AuthContext _context;

        public RepositoryLive(AuthContext context)
        {
            _context = context;
        }
        public void Save(LiveMap liveMap)
        {
            var live = GetById(liveMap.Id);
            
            if (live != null)
            {
                //liveMap.Author = _context.User.FirstOrDefault(x => x.Id == live.Author.Id);
                _context.Entry(liveMap).State = EntityState.Modified;
            }
            else
            {
                //liveMap.Author = _context.User.FirstOrDefault(x => x.Id == liveMap.Author.Id);               
                _context.Live.Add(liveMap);                                 
            }
                

            _context.SaveChanges();
        }

        public void Delet(int id)
        {
            var live = GetById(id);
            if(live != null)
                _context.Live.Remove(live);
        }

        public LiveMap GetById(int id)
        {
            return SelectLive().FirstOrDefault(x => x.Id == id);
        }

        public List<LiveMap> GetListLive()
        {
            return SelectLive()
                .OrderBy(x => x.Id)
                .ToList();
        }

        public List<LiveMap> GetListByCourse(int id)
        {
            return SelectLive()
                .Where(map => map.CourseId == id)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public IQueryable<LiveMap> SelectLive()
        {
            return _context.Live;
        }

        public List<LiveMap> GetSearchListLive(string text)
        {
            return SelectLive()
                .Where(map => map.Title.Contains(text))
                .OrderBy(x => x.Title)
                .ToList();
        }
    }
}
