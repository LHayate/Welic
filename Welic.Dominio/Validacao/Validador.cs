using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Welic.Dominio.Eventos;

namespace Welic.Dominio.Validacao
{
    public static class Validador
    {
        public static bool SeSatisfazPor(params NotificacaoDominio[] validacoes)
        {
            IEnumerable<NotificacaoDominio> notificacoes = validacoes.Where(x => x != null);
            IEnumerable<NotificacaoDominio> notificacaoDominios = notificacoes as NotificacaoDominio[] ??
                                                                  notificacoes.ToArray();
            NotificarTodos(notificacaoDominios);

            return notificacaoDominios.Count().Equals(0);
        }

        private static void NotificarTodos(IEnumerable<NotificacaoDominio> notificacoes)
        {
            notificacoes.ToList().ForEach(EventoDominio.Disparar);
        }

        public static NotificacaoDominio AssegurarTamanho(string stringValue, int minimum, int maximum, string message)
        {
            int length = stringValue?.Trim().Length ?? 0;

            return length < minimum || length > maximum
                ? new NotificacaoDominio("AssertArgumentLength", message)
                : null;
        }

        public static NotificacaoDominio AssertMatches(string pattern, string stringValue, string message)
        {
            Regex regex = new Regex(pattern);

            return !regex.IsMatch(stringValue)
                ? new NotificacaoDominio("AssertArgumentLength", message)
                : null;
        }

        public static NotificacaoDominio AssegurarNaoVazio(string stringValue, string message)
        {
            return string.IsNullOrEmpty(stringValue)
                ? new NotificacaoDominio("AssertArgumentNotEmpty", message)
                : null;
        }

        public static NotificacaoDominio AssegurarNaoNulo(object object1, string message)
        {
            return object1 == null
                ? new NotificacaoDominio("AssertArgumentNotNull", message)
                : null;
        }

        public static NotificacaoDominio AssegurarNulo(object object1, string message)
        {
            return object1 != null
                ? new NotificacaoDominio("AssertArgumentNotNull", message)
                : null;
        }

        public static NotificacaoDominio AssegurarQueVerdade(bool boolValue, string message)
        {
            return !boolValue
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssegurarQueFalso(bool boolValue, string message)
        {
            return boolValue
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssegurarQueIgual(string value, string match, string message)
        {
            return value != match
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssegurarQueIgual(int value, int match, string message)
        {
            return value != match
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssegurarQueIgual(decimal value, decimal match, string message)
        {
            return value != match
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssegurarMaiorQue(int value1, int value2, string message)
        {
            return !(value1 > value2)
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssegurarMaiorQue(decimal value1, decimal value2, string message)
        {
            return !(value1 > value2)
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssegurarMaiorQue(DateTime value1, DateTime value2, string message)
        {
            return !(value1 > value2)
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssegurarMaiorOuIgualQue(int value1, int value2, string message)
        {
            return !(value1 >= value2)
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssegurarMaiorOuIgualQue(decimal value1, decimal value2, string message)
        {
            return !(value1 >= value2)
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssegurarMaiorOuIgualQue(DateTime value1, DateTime value2, string message)
        {
            return !(value1 >= value2)
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssegurarMenorQue(int value1, int value2, string message)
        {
            return !(value1 < value2)
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssegurarMenorQue(decimal value1, decimal value2, string message)
        {
            return !(value1 < value2)
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssegurarMenorQue(DateTime value1, DateTime value2, string message)
        {
            return !(value1 < value2)
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssegurarMenorOuIgualQue(int value1, int value2, string message)
        {
            return !(value1 <= value2)
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssegurarMenorOuIgualQue(decimal value1, decimal value2, string message)
        {
            return !(value1 <= value2)
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssegurarMenorOuIgualQue(DateTime value1, DateTime value2, string message)
        {
            return !(value1 <= value2)
                ? new NotificacaoDominio("AssertArgumentTrue", message)
                : null;
        }

        public static NotificacaoDominio AssegurarEstruturaGrau(string grau, string grauPai)
        {
            if (string.IsNullOrEmpty(grau))
            {
                return new NotificacaoDominio("AssertGrau", "O grau deve conter conter pelo menos um número");
            }

            // Validar se possui somente números e ponto
            if (grau.Any(d => !Regex.Match(d.ToString(), @"[0-9]+$").Success && d != '.'))
            {
                return new NotificacaoDominio("AssertGrau",
                    "O grau deve conter apenas números (0-9) e ponto final (.)");
            }

            // Validar se o código começa com ponto (.1)
            if (grau.Substring(0, 1).Contains("."))
            {
                return new NotificacaoDominio("AssertGrau", "O grau deve iniciar com números (0-9)");
            }

            // Validar se o código termina com ponto (1.)
            if (grau.Substring(grau.Length - 1, 1).Contains("."))
            {
                return new NotificacaoDominio("AssertGrau", "O grau deve terminar com números (0-9)");
            }

            // Validar se os pontos do código estão circundados por números (1.1)
            if (grau.Contains("."))
            {
                string ant = grau[0].ToString();
                for (int i = 1; i < grau.Length; i++)
                {
                    string digito = grau[i].ToString();
                    string proximo = i < grau.Length - 1 ? grau[i + 1].ToString() : "";

                    if (digito == ".")
                    {
                        if (!Regex.Match(ant, @"[0-9]+$").Success ||
                            !string.IsNullOrEmpty(proximo) && !Regex.Match(proximo, @"[0-9]+$").Success)
                        {
                            return new NotificacaoDominio("AssertGrau",
                                "Cada ponto do grau deve estar circundado com números");
                        }
                    }
                    ant = digito;
                }
            }

            // Validar o código da conta com o código da grau pai
            if (!string.IsNullOrEmpty(grauPai))
            {
                // Verificar se o código da grau possui o código do grau pai (1.1.1 -> 1.1)
                if (!grau.Substring(0, grauPai.Length).Contains(grauPai))
                {
                    return new NotificacaoDominio("AssertGrau",
                        "O grau deve pertencer à estrutura do grau pai");
                }

                // Verificar se pulou um nível na estrutura (1.1.1.1 -> 1.1)
                int qtdPts = grau.Length - grau.Replace(".", "").Length;
                int qtdPtsPai = grauPai.Length - grauPai.Replace(".", "").Length;

                if (qtdPts - qtdPtsPai != 1)
                {
                    return new NotificacaoDominio("AssertGrau",
                        "O grau deve estar um nível abaixo do grau pai");
                }
            }

            return null;
        }

        public static NotificacaoDominio AssegurarQueSomenteNumeros(string value, string message)
        {
            foreach (char t in value)
            {
                if (!int.TryParse(t.ToString(), out int inteiroChecado))
                {
                    return new NotificacaoDominio("AsserInteiro", message);
                }
            }
            return null;
        }
    }
}