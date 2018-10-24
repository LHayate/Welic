using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Acesso.Dtos;
using Welic.Dominio.Models.Acesso.Entidades;
using Welic.Dominio.Models.Acesso.Mapeamentos;

namespace Welic.Dominio.Models.Acesso.Adaptador
{
    public class AdapterDispositivos
    {
        public static DispositivoDto ConverterMapParaDto(DispositivosMap map)
        {

            if (map == null)
            {
                return null;
            }

            DispositivoDto dto = new DispositivoDto
            {
                Id = map.Id,
                DateLastSynced =  map.DateLastSynced,
                Version = map.Version,
                NameUser = map.NameUser,
                Status = map.Status,
                EmailUsuario = map.EmailUsuario,
                DateSynced = map.DateSynced,
                DeviceName = map.DeviceName,
                Plataforma = map.Plataforma,
                Sharedkey = map.Sharedkey
            };


            return dto;
        }

        public static Dispositivo ConverterDtoParEntidade(DispositivoDto map)
        {

            if (map == null)
            {
                return null;
            }

            Dispositivo user = new Dispositivo
            {
                Id = map.Id,
                DateLastSynced = map.DateLastSynced,
                Version = map.Version,
                NameUser = map.NameUser,
                Status = map.Status,
                EmailUsuario = map.EmailUsuario,
                DateSynced = map.DateSynced,
                DeviceName = map.DeviceName,
                Plataforma = map.Plataforma,
                Sharedkey = map.Sharedkey
            };


            return user;
        }

        public static List<DispositivoDto> ConverterMapParaDto(List<DispositivosMap> listaMap)
        {
            if (listaMap == null)
            {
                return null;
            }

            List<DispositivoDto> listaDto = new List<DispositivoDto>();

            foreach (DispositivosMap map in listaMap)
            {
                listaDto.Add(ConverterMapParaDto(map));
            }
            return listaDto;
        }
    }
}
