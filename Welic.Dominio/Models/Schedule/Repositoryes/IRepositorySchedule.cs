using System;
using System.Collections.Generic;
using Welic.Dominio.Models.Schedule.Maps;

namespace Welic.Dominio.Models.Schedule.Repositoryes
{
    public interface IRepositorySchedule
    {
        void Save(ScheduleMap scheduleMap);
        void Delete(int id);
        ScheduleMap GetById(int id, bool ativo);
        ScheduleMap GetByDate(DateTime date);
        ScheduleMap SearchEvent(string text);
        List<ScheduleMap> listSchedule();
        void InabilitySchedule(int id);

    }
}
