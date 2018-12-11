using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Welic.Dominio.Models.Menu.Dtos;
using Welic.Dominio.Models.Menu.Mapeamentos;


namespace Welic.Dominio.Models.Menu.Adapter
{
    public class AdapterMenu
    {
        public static MenuDto ConverterMapParaDto(MenuMap map)
        {

            if (map == null)
            {
                return null;
            }

            var dto = new MenuDto
            {
                Id = map.Id,
                Title = map.Title,
                Nivel = map.Nivel,
                IconMenu = map.IconMenu,
                MenuDadId = map.DadId,
                Controller = map.Controller,
                Action = map.Action,
                //GroupAcess = map.GroupAcess
            };            
            return dto;
        }

        public static Entidades.Menu ConverterDtoParEntidade(MenuDto dto)
        {

            if (dto == null)
            {
                return null;
            }

            Entidades.Menu entity = new Entidades.Menu
            {
                Id = dto.Id,
                Title = dto.Title,
                IconMenu = dto.IconMenu,
                Controller = dto.Controller,   
                                //GroupAcess = dto.GroupAcess
            };
            
            return entity;
        }

        public static List<MenuDto> ConverterMapParaDto(List<MenuMap> listaMap)
        {
            if (listaMap == null)
            {
                return null;
            }

            List<MenuDto> listaDto = new List<MenuDto>();

            foreach (MenuMap map in listaMap)
            {
                listaDto.Add(ConverterMapParaDto(map));
            }
            return listaDto;
        }
        public static List<Entidades.Menu> ConverterDtoParEntidade(List<MenuDto> listaDto)
        {
            if (listaDto == null)
            {
                return null;
            }

            List<Entidades.Menu> listaEntity = new List<Entidades.Menu>();

            foreach (var dto in listaDto)
            {
                listaEntity.Add(ConverterDtoParEntidade(dto));
            }
            return listaEntity;
        }
    }
}
