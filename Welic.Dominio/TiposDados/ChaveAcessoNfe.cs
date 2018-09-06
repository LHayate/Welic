using System;
using System.Text.RegularExpressions;
using Welic.Dominio.Utilitarios.Entidades;

namespace Welic.Dominio.TiposDados
{
    public class ChaveAcessoNfe
    {
        public string Chave { get; protected set; }

        public string ChaveFormatada => Formatar();
        public string ChaveSemFormatacao => LimparFormatacao();

        public ChaveAcessoNfe(string chave)
        {
            Chave = chave;
        }

        public bool Validar()
        {
            try
            {
                string chaveValidar = ChaveSemFormatacao;

                if (chaveValidar.Length != 44)
                {
                    return false;
                }

                int chaveChecar = Convert.ToInt32(chaveValidar[chaveValidar.Length - 1].ToString());

                int moduloObtido = ValidarDocumentos.ObterModulo11(chaveValidar.Substring(0, chaveValidar.Length - 1));

                return chaveChecar == moduloObtido;
            }
            catch
            {
                return false;
            }
        }

        private string Formatar()
        {
            return FormatarRegex(Chave);
        }

        private static string FormatarRegex(string valor)
        {
            return valor != null
                ? Regex.Replace(valor,
                    @"(\d{4})(\d{4})(\d{4})(\d{4})(\d{4})(\d{4})(\d{4})(\d{4})(\d{4})(\d{4})(\d{4})",
                    "$1 $2 $3 $4 $5 $6 $7 $8 $9 $10 $11")
                : null;
        }

        public string LimparFormatacao()
        {
            return Chave.Replace(" ", string.Empty);
        }
    }
}