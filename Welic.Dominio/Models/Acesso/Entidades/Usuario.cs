using System;
using Welic.Dominio.Models.Acesso.Escopos;
using Welic.Dominio.Utilitarios.Entidades;

namespace Welic.Dominio.Models.Acesso.Entidade
{
    public class Usuario
    {
        protected Usuario()
        {
        }

        public Usuario(string nomeUsuario, string senha)
        {
            NomeUsuario = nomeUsuario;
            Senha = Criptografia.EncriptarMd5(senha);            
        }

        public string NomeUsuario { get; set; }
        public string Senha { get; private set; }
        public string Situacao { get; private set; }
        public DateTime? UltimoAcesso { get; private set; }
        public int Id { get; private set; }
        public int IdDepartamento { get; private set; }        

        public bool ValidarNomeUsuarioESenha(string nomeUsuario, string senha)
        {
            return this.ValidarEscopoNomeUsuarioESenha(nomeUsuario, Criptografia.Encriptar(senha));
        }
    }
}