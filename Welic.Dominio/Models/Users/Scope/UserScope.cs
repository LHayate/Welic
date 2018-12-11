using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Utilitarios.Entidades;
using Welic.Dominio.Validacao;

namespace Welic.Dominio.Models.Users.Scope
{
    public static class UserScope
    {
        public static bool ValidarEscopoNomeUsuarioESenha(this AspNetUser user, string nomeUsuario, string senha)
        {
            return Validador.SeSatisfazPor(
                Validador.AssegurarQueIgual(user.Email.ToUpper(), nomeUsuario.ToUpper(),
                    "Usuário inválido."),
                Validador.AssegurarQueVerdade(Criptografia.VerifyHashedPassword(user.Password,senha), "Senha inválida."));
        }
    }
}
