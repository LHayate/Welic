using System.Text.RegularExpressions;
using Welic.Dominio.Utilitarios.Entidades;

namespace Welic.Dominio.TiposDados
{
    public class Cpf : CpfCnpj
    {
        //public string Valor { get; private set; }
        public override string ValorFormatado => Formatar();

        public Cpf(string valor)
        {
            Valor = valor;
        }

        public override bool Validar()
        {
            return ValidarDocumentos.ValidarCpf(Valor);
        }

        private static string FormatarRegex(string valor)
        {
            return Regex.Replace(valor, @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");
        }

        public static string Formatar(string cpf)
        {
            return FormatarRegex(cpf);
        }

        private string Formatar()
        {
            return FormatarRegex(Valor);
        }
    }
}