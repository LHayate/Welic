using Welic.Dominio.Validacao;

namespace Welic.Dominio.Models.Users.Scope
{
    public static class UserScope
    {
        public static bool ValidarEscopoNomeUsuarioESenha(this Entidades.User user, string nomeUsuario, string senha)
        {
            return Validador.SeSatisfazPor(
                Validador.AssegurarQueIgual(user.Email.ToUpper(), nomeUsuario.ToUpper(),
                    "Usuário ou Senha inválidos."),
                Validador.AssegurarQueIgual(user.Password, senha, "Usuário ou Senha inválidos."));
        }
    }
}
