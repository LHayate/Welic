using Welic.Dominio.Utilitarios.Entidades;

namespace Welic.Dominio.TiposDados
{
    public class Descricao
    {
        private string _valor;

        public string Valor
        {
            get => _valor;
            private set => _valor = FormatacaoString.Padronizar(value);
        }

        public string ValorResumido => ObterValorResumido(_valor);

        public string ObterValorResumido(string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                return valor.Length > 20 ? valor.Substring(0, 20) : valor;
            }

            return string.Empty;
        }

        protected Descricao()
        {
        }

        public Descricao(string valor)
        {
            Valor = valor;
        }

        public void LimparDescricao()
        {
            Valor = "";
        }

        public static implicit operator string(Descricao descricao)
        {
            return descricao.Valor;
        }

        public static implicit operator Descricao(string descricao)
        {
            return new Descricao(descricao);
        }
    }
}