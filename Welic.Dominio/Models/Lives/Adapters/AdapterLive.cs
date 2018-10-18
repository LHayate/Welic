using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Lives.Dtos;
using Welic.Dominio.Models.Lives.Entitys;
using Welic.Dominio.Models.Lives.Maps;
using Welic.Dominio.Models.Users.Adapters;

namespace Welic.Dominio.Models.Lives.Adapters
{
    public class AdapterLive
    {
        public static LiveDto ConverterMapParaDto(LiveMap map)
        {

            if (map == null)
            {
                return null;
            }

            LiveDto dto = new LiveDto
            {
                Id = map.Id,
                Title = map.Title,
                Chat = map.Chat,
                Description = map.Description,
                Prince = map.Prince,
                Print = map.Print,
                Themes = map.Themes,
                UrlDestino = map.UrlDestino,
                Author = AdapterUser.ConverterMapParaDto(map.Author)
                
            };

            return dto;
        }

        public static Live ConverterDtoParEntidade(LiveDto dto)
        {

            if (dto == null)
            {
                return null;
            }

            Live entity = new Live
            {
                Id = dto.Id,
                Title = dto.Title,
                Themes = dto.Themes,
                Print =  dto.Print,
                UrlDestino =  dto.UrlDestino,
                Prince =  dto.Prince,
                Description = dto.Description,
                Chat = dto.Chat,
                Author = AdapterUser.ConverterDtoParEntidade(dto.Author)
                
            };

            return entity;
        }

        public static ObservableCollection<LiveDto> ConverterMapParaDto(List<LiveMap> listaMap)
        {
            if (listaMap == null)
            {
                return null;
            }

            ObservableCollection<LiveDto> listaDto = new ObservableCollection<LiveDto>();

            foreach (LiveMap map in listaMap)
            {
                listaDto.Add(ConverterMapParaDto(map));
            }
            return listaDto;
        }
    }
}
