using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio;
using Welic.Dominio.Models.Acesso.Comandos;
using Welic.Dominio.Models.Acesso.Comandos.ComandoUsuario;
using Welic.Dominio.Models.Acesso.Entidade;
using Welic.Dominio.Models.Acesso.Repositorios;
using Welic.Dominio.Models.Acesso.Servicos;
using Welic.Dominio.Models.Users.Dtos;

namespace Servicos.Acesso
{
    public class ServicoUsuario : Servico, IServicoUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;        

        public ServicoUsuario(IRepositorioUsuario repositorioUsuario, IUnidadeTrabalho unidadeTrabalho)
            : base(unidadeTrabalho)
        {
            _repositorioUsuario = repositorioUsuario;            
        }

        public Usuario Autenticar(ComandoCriaUsuario comando)
        {
            Usuario usuario = _repositorioUsuario.ObterPorNomeUsuario(comando.NomeUsuario);
            return usuario.ValidarNomeUsuarioESenha(comando.NomeUsuario, comando.Senha) ? usuario : null;
        }

        public ComandoConsultaUsuario ObterPorId(int id)
        {
            Usuario usuario = _repositorioUsuario.ObterPorid(id);
            if (usuario != null)
            {
                return new ComandoConsultaUsuario
                {
                    Usuario = usuario.NomeUsuario,
                    Situacao = usuario.Situacao,
                    UltimoAcesso = usuario.UltimoAcesso
                };
            }

            return null;
        }

        public void RegistrarAtividadeUsuario(ComandoRegistroAtividadeUsuario comando)
        {
            _repositorioUsuario.RegistrarAtividadeUsuario(comando);
        }

        public Usuario Criar(ComandoCriaUsuario comando)
        {
            Usuario usuario = new Usuario(comando.NomeUsuario, comando.Senha);

            _repositorioUsuario.Criar(usuario);

            return Commit() ? usuario : null;
        }
    }
}
