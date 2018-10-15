using System;
using System.Collections.Generic;
using Welic.Dominio.Models.Schedule.Dtos;

namespace Welic.Dominio.Models.Schedule.Services
{
    public interface IServiceSchedule
    {
        ScheduleDto Save(ScheduleDto scheduleDto);
        bool Delete(int id);
        ScheduleDto GetById(int id, bool ativo = true);
        ScheduleDto GetByDate(DateTime date);
        ScheduleDto SearchEvent(string text);
        List<ScheduleDto> listSchedule();
        bool InabilitySchedule(int id);
    }
}
