using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Welic.Dominio.Utilitarios.Entidades
{
    public static class FormatacaoString
    {
        public static string RemoveAcentoCedilha(string expressao)
        {
            string normalized = expressao.Normalize(NormalizationForm.FormD);
            StringBuilder builder = new StringBuilder();

            foreach (char ch in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                {
                    builder.Append(ch);
                }
            }

            return builder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string RemoveExcessoEspaco(string expressao)
        {
            return Regex.Replace(expressao, @"\s+", " ");
        }

        public static string ParaMaiusculo(string expressao)
        {
            return expressao.ToUpper();
        }

        public static string Padronizar(string expressao)
        {
            if (!string.IsNullOrEmpty(expressao))
            {
                return RemoveAcentoCedilha(RemoveExcessoEspaco(ParaMaiusculo(expressao.Trim())));
            }
            return null;
        }

        public static float ConverteParaAscii(string expressao)
        {
            if (string.IsNullOrEmpty(expressao))
            {
                return 0;
            }

            string ascii = "";

            foreach (char item in expressao.Replace(".", ""))
            {
                ascii += ((float) item).ToString();
            }

            return float.Parse(ascii);
        }

        public static string Reverse(string expressao)
        {
            string inversa = "";

            for (int i = expressao.Length - 1; i >= 0; i--)
            {
                inversa += expressao[i];
            }

            return inversa;
        }

        public static string LimparSinaisPontosNumerico(string conteudo)
        {
            return conteudo.Trim().Replace(".", "").Replace("-", "").Replace("+", "");
        }
    }
}