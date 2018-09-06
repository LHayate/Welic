using System.Text.RegularExpressions;
using Welic.Dominio.Utilitarios.Entidades;

namespace Welic.Dominio.TiposDados
{
    public class Cnpj : CpfCnpj
    {
        public override string ValorFormatado => Formatar();

        public Cnpj(string cnpj)
        {
            Valor = cnpj;
        }

        public override bool Validar()
        {
            return ValidarDocumentos.ValidarCnpj(Valor);
        }

        protected Cnpj()
        {
        }

        private string Formatar()
        {
            return FormatarRegex(Valor);
        }

        private static string FormatarRegex(string valor)
        {
            return Regex.Replace(valor, @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})", "$1.$2.$3/$4-$5");
        }

        public static string Formatar(string cnpf)
        {
            return FormatarRegex(cnpf);
        }
    }
}