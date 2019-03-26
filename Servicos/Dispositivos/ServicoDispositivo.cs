using System;
using Welic.Dominio;
using Welic.Dominio.Models.Acesso.Adaptador;
using Welic.Dominio.Models.Acesso.Dtos;
using Welic.Dominio.Models.Acesso.Mapeamentos;
using Welic.Dominio.Models.Acesso.Repositorios;
using Welic.Dominio.Models.Acesso.Servicos;
using Welic.Dominio.Patterns.Repository.Pattern.Infrastructure;

namespace Services.Dispositivos
{
    public class ServicoDispositivo : Servico, IServicoDispositivo
    {
        private readonly IRepositorioDispositivos _dispositivos;
        private readonly IUnidadeTrabalho _unidadeTrabalho;
        public ServicoDispositivo(IRepositorioDispositivos dispositivos, IUnidadeTrabalho unidadeTrabalho) : base(unidadeTrabalho)
        {
            _dispositivos = dispositivos;
            _unidadeTrabalho = unidadeTrabalho;

        }

        public DispositivoDto ConsultarPorId(string id)
        {
            return AdapterDispositivos.ConverterMapParaDto(_dispositivos.BuscarPorId(id));
        }

        public DispositivoDto Salvar(DispositivoDto dispositivoDto)
        {

            if (dispositivoDto == null)
                return null;
            var dtoEncontrado = _dispositivos.BuscarPorId(dispositivoDto.Id);

            if (dtoEncontrado != null)
            {
                dtoEncontrado.Id = dispositivoDto.Id;
                dtoEncontrado.NameUser = dispositivoDto.NameUser;
                dtoEncontrado.Version = dispositivoDto.Version;
                dtoEncontrado.DateLastSynced = DateTime.Now;
                dtoEncontrado.Status = dispositivoDto.Status;
                dtoEncontrado.EmailUsuario = dispositivoDto.EmailUsuario;
                dtoEncontrado.DateSynced = DateTime.Now;
                dtoEncontrado.DeviceName = dispositivoDto.DeviceName;
                dtoEncontrado.Sharedkey = dispositivoDto.Sharedkey;
                dtoEncontrado.Plataforma = dispositivoDto.Plataforma;
                dtoEncontrado.ObjectState = ObjectState.Modified;


                _dispositivos.Alterar(dtoEncontrado);
            }
            else
            {
                dtoEncontrado = new DispositivosMap
                {
                    Id = dispositivoDto.Id,
                    NameUser = dispositivoDto.NameUser,
                    Version = dispositivoDto.Version,
                    DateLastSynced = DateTime.Now,
                    Status = dispositivoDto.Status,
                    EmailUsuario = dispositivoDto.EmailUsuario,
                    DateSynced = DateTime.Now,
                    DeviceName = dispositivoDto.DeviceName,
                    Sharedkey = dispositivoDto.Sharedkey,
                    Plataforma = dispositivoDto.Plataforma,
                    ObjectState = ObjectState.Added,
                };

                _dispositivos.Gravar(dtoEncontrado);
            }                       

            if (!Commit())
            {
                return null;
            }

            return ConsultarPorId(dtoEncontrado.Id);
        }

        public DispositivoDto Alterar(DispositivoDto dispositivoDto)
        {
            if (dispositivoDto == null)
                return null;

            var dtoEncontrado = _dispositivos.BuscarPorId(dispositivoDto.Id);

            if(dtoEncontrado != null)
            {                
                dtoEncontrado.Id = dispositivoDto.Id;
                dtoEncontrado.NameUser = dispositivoDto.NameUser;
                dtoEncontrado.Version = dispositivoDto.Version;
                dtoEncontrado.DateLastSynced = DateTime.Now;
                dtoEncontrado.Status = dispositivoDto.Status;
                dtoEncontrado.EmailUsuario = dispositivoDto.EmailUsuario;
                dtoEncontrado.DateSynced = DateTime.Now;
                dtoEncontrado.DeviceName = dispositivoDto.DeviceName;
                dtoEncontrado.Sharedkey = dispositivoDto.Sharedkey;
                dtoEncontrado.Plataforma = dispositivoDto.Plataforma;


                _dispositivos.Alterar(dtoEncontrado);
            }
            else
            {
                dtoEncontrado = new DispositivosMap
                {
                    Id = dispositivoDto.Id,
                    NameUser = dispositivoDto.NameUser,
                    Version = dispositivoDto.Version,
                    DateLastSynced = DateTime.Now,
                    Status = dispositivoDto.Status,
                    EmailUsuario = dispositivoDto.EmailUsuario,
                    DateSynced = DateTime.Now,
                    DeviceName = dispositivoDto.DeviceName,
                    Sharedkey = dispositivoDto.Sharedkey,
                    Plataforma = dispositivoDto.Plataforma
                };

                _dispositivos.Gravar(dtoEncontrado);
            }
            
            if (!Commit())
            {
                return null;
            }

            return ConsultarPorId(dtoEncontrado.Id);
        }
    }
}
