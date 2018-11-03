using System;
using System.Collections.Generic;
using Welic.Dominio;
using Welic.Dominio.Models.Lives.Repositoryes;
using Welic.Dominio.Models.Schedule.Adapters;
using Welic.Dominio.Models.Schedule.Dtos;
using Welic.Dominio.Models.Schedule.Maps;
using Welic.Dominio.Models.Schedule.Repositoryes;
using Welic.Dominio.Models.Schedule.Services;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Models.Users.Repositorios;

namespace Servicos.Schedule
{
    public class ServiceSchedule : Servico, IServiceSchedule
    {
        private readonly IRepositorySchedule _repositorySchedule;
        private readonly IRepositoryLive _repositoryLive;
        private readonly IRepositorioUser _repositoryUser;        


        public ServiceSchedule(IRepositorySchedule repositorySchedule, 
            IUnidadeTrabalho unidadeTrabalho, 
            IRepositoryLive repositoryLive,
            IRepositorioUser repositoryUser) : base(unidadeTrabalho)
        {
            _repositorySchedule = repositorySchedule;
            _repositoryLive = repositoryLive;            
            _repositoryUser = repositoryUser;
        }


        public bool Delete(int id)
        {
            _repositorySchedule.Delete(id);

            return GetById(id, true) == null;
        }

        public ScheduleDto GetByDate(DateTime date)
        {
            return AdapterSchedule.ConverterMapParaDto(_repositorySchedule.GetByDate(date));
        }

        public ScheduleDto GetById(int id, bool ativo = true)
        {
            return AdapterSchedule.ConverterMapParaDto(_repositorySchedule.GetById(id, ativo));
        }

        public ScheduleDto Save(ScheduleDto scheduleDto)
        {
            var scheduleFinding =  _repositorySchedule.GetById(scheduleDto.ScheduleId, true);
            if (scheduleFinding != null)
            {                
                scheduleFinding.ScheduleId = scheduleDto.ScheduleId;
                scheduleFinding.DateEvent = scheduleDto.DateEvent;
                scheduleFinding.Description = scheduleDto.Description;
                scheduleFinding.Live = _repositoryLive.GetById(scheduleDto.Live.Id);
                scheduleFinding.Prince = scheduleDto.Prince;
                scheduleFinding.Private = scheduleDto.Private;
                scheduleFinding.Title = scheduleDto.Title;
                scheduleFinding.UserTeacher = _repositoryUser.GetById(scheduleDto.UserTeacher.UserId);
                scheduleFinding.Ativo = true;

                foreach (var userDto in scheduleDto.UserClass)
                {
                    var userMap = new AspNetUser
                    {
                        Id = userDto.UserId,
                        Email = userDto.Email,
                        Guid = userDto.Guid,                        
                        PhoneNumber = userDto.PhoneNumber,
                        NickName = userDto.NickName
                        
                    };

                    scheduleFinding.UserClass.Add(userMap);
                }
            }
            else
            {
                scheduleFinding = new ScheduleMap
                {
                    ScheduleId = scheduleDto.ScheduleId,
                    DateEvent = scheduleDto.DateEvent,
                    Description = scheduleDto.Description,
                    Live = _repositoryLive.GetById(scheduleDto.Live.Id),
                    Prince = scheduleDto.Prince,
                    Private = scheduleDto.Private,
                    Title = scheduleDto.Title,
                    UserTeacher = _repositoryUser.GetById(scheduleDto.UserTeacher.UserId),
                    Ativo = true

                };

                if(scheduleDto.UserClass != null)
                    foreach (var userDto in scheduleDto.UserClass)
                    {
                        var userMap = new AspNetUser
                        {
                            Id = userDto.UserId,
                            Email = userDto.Email,
                            Guid = userDto.Guid,                            
                            PhoneNumber = userDto.PhoneNumber,
                            NickName = userDto.NickName
                        };

                        scheduleFinding.UserClass.Add(userMap);                    
                    }
            }

            _repositorySchedule.Save(scheduleFinding);
            return GetById(scheduleFinding.ScheduleId, true);
        }

        public ScheduleDto SearchEvent(string text)
        {
            throw new NotImplementedException();
        }

        public List<ScheduleDto> listSchedule()
        {
            return AdapterSchedule.ConverterMapParaDto(_repositorySchedule.listSchedule());
        }

        public bool InabilitySchedule(int id)
        {

            _repositorySchedule.InabilitySchedule(id);
            return GetById(id, false) != null;
        }
    }
}
