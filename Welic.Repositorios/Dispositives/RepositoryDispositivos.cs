using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Acesso.Mapeamentos;
using Welic.Dominio.Models.Acesso.Repositorios;
using Welic.Infra.Context;

namespace Welic.Repositorios.Dispositives
{
    public class RepositoryDispositivos: IRepositorioDispositivos
    {
        private readonly AuthContext _contexto;
        public RepositoryDispositivos(AuthContext context)
        {
            _contexto = context;
        }
        public void Gravar(DispositivosMap dispositivoMap)
        {            
            _contexto.Dispositivo.Add(dispositivoMap);
            _contexto.SaveChanges();
        }

        public void Alterar(DispositivosMap dispositivoMap)
        {            
            _contexto.Entry(dispositivoMap).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public DispositivosMap BuscarPorId(string Id)
        {
            return _contexto.Dispositivo.FirstOrDefault(map => map.Id == Id);
        }
    }
}
