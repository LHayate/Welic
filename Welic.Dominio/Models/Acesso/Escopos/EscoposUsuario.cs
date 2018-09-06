using Welic.Dominio.Models.Acesso.Entidade;
using Welic.Dominio.Validacao;

namespace Welic.Dominio.Models.Acesso.Escopos
{
    public static class EscoposUsuario
    {
        public static bool ValidarNovoUsuario(this Usuario usuario)
        {
            return Validador.SeSatisfazPor(
                Validador.AssegurarNaoNulo(usuario, "Informar o usuário"),
                Validador.AssegurarTamanho(usuario.NomeUsuario, 3, 50, "O nome deve conter entre 3 e 10 caracteres"),
                Validador.AssegurarTamanho(usuario.Senha, 32, 32, "Senha inválida.")
            );
        }

        public static bool ValidarEscopoNomeUsuarioESenha(this Usuario usuario, string nomeUsuario, string senha)
        {
            return Validador.SeSatisfazPor(
                Validador.AssegurarQueIgual(usuario.NomeUsuario.ToUpper(), nomeUsuario.ToUpper(),
                    "Usuário ou Senha inválidos."),
                Validador.AssegurarQueIgual(usuario.Senha, senha, "Usuário ou Senha inválidos."));
        }
    }
}