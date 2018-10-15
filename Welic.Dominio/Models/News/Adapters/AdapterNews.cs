using System.Collections.Generic;

using Welic.Dominio.Models.News.Dtos;
using Welic.Dominio.Models.News.Maps;

namespace Welic.Dominio.Models.News.Adapters
{
    public class AdapterNews
    {
        public static NewsDto ConverterMapParaDto(NewsMap map)
        {

            if (map == null)
            {
                return null;
            }

            var dto = new NewsDto
            {
                Id = map.Id,
                Title = map.Title,
                Description = map.Description,      
                Date = map.Date,
                Url = map.Url,
            };           



            return dto;
        }

        public static Entityes.News ConverterDtoParEntidade(NewsDto dto)
        {

            if (dto == null)
            {
                return null;
            }

            Entityes.News entity = new Entityes.News
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Date = dto.Date,
                Url = dto.Url,
                

            };
           

            return entity;
        }

        public static List<NewsDto> ConverterMapParaDto(List<NewsMap> listaMap)
        {
            if (listaMap == null)
            {
                return null;
            }

            List<NewsDto> listaDto = new List<NewsDto>();

            foreach (var map in listaMap)
            {
                listaDto.Add(ConverterMapParaDto(map));
            }
            return listaDto;
        }
        public static List<Entityes.News> ConverterDtoParEntidade(List<NewsDto> listaDto)
        {
            if (listaDto == null)
            {
                return null;
            }

            List<Entityes.News> listaEntity = new List<Entityes.News>();

            foreach (var dto in listaDto)
            {
                listaEntity.Add(ConverterDtoParEntidade(dto));
            }
            return listaEntity;
        }
    }
}
