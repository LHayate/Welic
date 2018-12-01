using System.Collections.Generic;
using System.Collections.ObjectModel;
using Welic.Dominio.Models.Lives.Adapters;
using Welic.Dominio.Models.Schedule.Dtos;
using Welic.Dominio.Models.Schedule.Maps;
using Welic.Dominio.Models.Schedule.Entity;
using Welic.Dominio.Models.Users.Adapters;
using Welic.Dominio.Models.Users.Dtos;

namespace Welic.Dominio.Models.Schedule.Adapters
{
    public class AdapterSchedule
    {
        public static ScheduleDto ConverterMapParaDto(ScheduleMap map)
        {

            if (map == null)
            {
                return null;
            }

            var dto = new ScheduleDto
            {
                ScheduleId = map.ScheduleId,
                Title = map.Title,
                Description = map.Description,
                Prince = map.Prince,
                DateEvent = map.DateEvent,
                Private = map.Private,
                UserTeacher = AdapterUser.ConverterMapParaDto(map.UserTeacher),
                //Live = AdapterLive.ConverterMapParaDto(map.Live)
            };
            
            //Todo:Schedule corrigir 
            //if(map.UserClass != null)
            //foreach (var userClass in map.UserClass)
            //{
            //    dto.UserClass.Add(AdapterUser.ConverterMapParaDto(userClass));
                
            //}

            

            return dto;
        }

        public static Entity.Schedule ConverterDtoParEntidade(ScheduleDto dto)
        {

            if (dto == null)
            {
                return null;
            }

            Entity.Schedule entity = new Entity.Schedule
            {
                ScheduleId = dto.ScheduleId,
                Title = dto.Title,
                Description = dto.Description,
                Prince = dto.Prince,
                DateEvent = dto.DateEvent,
                Private = dto.Private,
                Live = AdapterLive.ConverterDtoParEntidade(dto.Live),
                UserTeacher = (AdapterUser.ConverterDtoParEntidade(dto.UserTeacher))

            };            

            foreach (var userClass in dto.UserClass)
            {
                entity.UserClass.Add(AdapterUser.ConverterDtoParEntidade(userClass));

            }          

            return entity;
        }

        public static List<ScheduleDto> ConverterMapParaDto(List<ScheduleMap> listaMap)
        {
            if (listaMap == null)
            {
                return null;
            }

            List<ScheduleDto> listaDto = new List<ScheduleDto>();

            foreach (ScheduleMap map in listaMap)
            {
                listaDto.Add(ConverterMapParaDto(map));
            }
            return listaDto;
        }
        public static List<Entity.Schedule> ConverterDtoParEntidade(List<ScheduleDto> listaDto)
        {
            if (listaDto == null)
            {
                return null;
            }

            List<Entity.Schedule> listaEntity = new List<Entity.Schedule>();

            foreach (var dto in listaDto)
            {
                listaEntity.Add(ConverterDtoParEntidade(dto));
            }
            return listaEntity;
        }
    }
}
