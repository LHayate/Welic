using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Lives.Maps;
using Welic.Dominio.Models.Schedule.Maps;
using Welic.Dominio.Models.Schedule.Repositoryes;
using Welic.Infra.Context;

namespace Welic.Repositorios.Schedule
{
    public class RepositorySchedule : IRepositorySchedule
    {
        private AuthContext _context;

        public RepositorySchedule(AuthContext context)
        {
            _context = context;
        }

        private  IQueryable<ScheduleMap> Query()
        {
            return _context.Schedule;
        }

        public void Save(ScheduleMap scheduleMap)
        {
            var schedule = GetById(scheduleMap.ScheduleId);
            if (schedule != null)
                _context.Entry(schedule).State = EntityState.Modified;
            else
                _context.Schedule.Add(scheduleMap);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var schedule = GetById(id);
            if (schedule != null)
            {
                _context.Schedule.Remove(schedule);
                _context.SaveChanges();
            }
        }

        public ScheduleMap GetById(int id, bool ativo = true)
        {
            if (ativo)
                return _context.Schedule.FirstOrDefault(map => map.ScheduleId == id && map.Ativo);
            else
                return _context.Schedule.FirstOrDefault(map => map.ScheduleId == id && map.Ativo == false);
        }

        public ScheduleMap GetByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public ScheduleMap SearchEvent(string text)
        {
            throw new NotImplementedException();
        }

        public List<ScheduleMap> listSchedule()
        {
            return Query()
                .Where(map => map.Ativo)
                .OrderBy(map => map.DateEvent)
                .ToList();
        }

        public void InabilitySchedule(int id)
        {
            var schedule = GetById(id);
            schedule.Ativo = false;
            if (schedule != null)
            {
                _context.Entry(schedule).State = EntityState.Modified;
            }
        }
    }
}
