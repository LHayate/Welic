using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UseFul.Uteis
{
    public static class Validacao
    {
        public static bool ValidaCpf(string vrCpf)
        {
            string valor = vrCpf.Replace(".", "");
            valor = valor.Replace("-", "");
            if (valor.Length != 11)
            {
                return false;
            }
            if (vrCpf == "11111111111")
            {
                return true;
            }
            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
            {
                if (valor[i] != valor[0])
                {
                    igual = false;
                }
            }
            if (igual || valor == "12345678909")
            {
                return false;
            }
            int[] numeros = new int[11];
            for (int i = 0; i < 11; i++)
            {
                numeros[i] = int.Parse(
                    valor[i].ToString());
            }
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += (10 - i) * numeros[i];
            }
            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                {
                    return false;
                }
            }
            else if (numeros[9] != 11 - resultado)
            {
                return false;
            }
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += (11 - i) * numeros[i];
            }
            resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                {
                    return false;
                }
            }
            else if (numeros[10] != 11 - resultado)
            {
                return false;
            }
            return true;
        }

        public static bool ValidaCnpj(string vrCnpj)
        {
            string cnpj = vrCnpj.Replace(".", "");
            cnpj = cnpj.Replace("/", "");
            cnpj = cnpj.Replace("-", "");
            if (cnpj == "00000000000000")
            {
                return false;
            }
            if (cnpj == "11111111111111")
            {
                return true;
            }
            const string ftmt = "6543298765432";
            int[] digitos = new int[14];
            int[] soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            int[] resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            bool[] cnpjOk = new bool[2];
            cnpjOk[0] = false;
            cnpjOk[1] = false;
            try
            {
                int nrDig;
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(
                        cnpj.Substring(nrDig, 1));
                    if (nrDig <= 11)
                    {
                        soma[0] += digitos[nrDig] *
                                   int.Parse(ftmt.Substring(
                                       nrDig + 1, 1));
                    }
                    if (nrDig <= 12)
                    {
                        soma[1] += digitos[nrDig] *
                                   int.Parse(ftmt.Substring(
                                       nrDig, 1));
                    }
                }
                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = soma[nrDig] % 11;
                    if (resultado[nrDig] == 0 || resultado[nrDig] == 1)
                    {
                        cnpjOk[nrDig] = digitos[12 + nrDig] == 0;
                    }
                    else
                    {
                        cnpjOk[nrDig] = digitos[12 + nrDig] == 11 - resultado[nrDig];
                    }
                }
                return cnpjOk[0] && cnpjOk[1];
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidaCaracterEspecial(string texto)
        {
            const string aux = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return texto.All(i => aux.Contains(i));
        }

        public static bool ValidaEmail(string email)
        {
            const string emailRegex = @"^(([^<>()[\]\\.,;áàãâäéèêëíìîïóòõôöúùûüç:\s@\""]+"
                                      + @"(\.[^<>()[\]\\.,;áàãâäéèêëíìîïóòõôöúùûüç:\s@\""]+)*)|(\"".+\""))@"
                                      + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|"
                                      + @"(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";
            Regex rx = new Regex(emailRegex);
            return rx.IsMatch(email);
        }

        public static string verificaCelular(string comp)
        {
            string txt = "(99) 9999-9999";
            List<int> ddds = new List<int>() { 11, 12, 13, 14, 15, 16, 17, 18, 19, 21, 22, 24, 27, 28, 61, 62, 63, 64, 65, 66, 67, 68, 69, 91, 92, 93, 94, 95, 96, 97, 98, 99, 31, 32, 34, 35, 37, 38, 71, 73, 74, 75, 77, 79 };
            if (comp.Trim().Length > 2)
            {
                if (ddds.Contains(int.Parse(comp.Substring(0, 2))))
                {
                    txt = "(99) 99999-9999";
                    return txt;
                }
                else
                {
                    txt = "(99) 9999-9999";
                    return txt;
                }
            }
            return txt;
        }

        public static string FormatCnpj(string cnpj)
        {
            if (!string.IsNullOrWhiteSpace(cnpj))
            {
                return Convert.ToDouble(cnpj).ToString(@"00\.000\.000\/0000\-00");
            }
            return string.Empty;
        }

        public static string FormatCpf(string cpf)
        {
            if (!string.IsNullOrWhiteSpace(cpf))
            {
                return Regex.Replace(cpf, @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");
            }
            return string.Empty;
        }

        public static string FormatFone(string foneContato)
        {
            if (!string.IsNullOrWhiteSpace(foneContato))
            {
                if (foneContato.Length == 8)
                {
                    return Regex.Replace(foneContato, @"(\d{4})(\d{4})", "$1-$2");
                }
                if (foneContato.Length == 9)
                {
                    return Regex.Replace(foneContato, @"(\d{5})(\d{4})", "$1-$2");
                }
                if (foneContato.Length == 10)
                {
                    return Regex.Replace(foneContato, @"(\d{2})(\d{4})(\d{4})", "($1) $2-$3");
                }
                if (foneContato.Length == 11)
                {
                    return Regex.Replace(foneContato, @"(\d{2})(\d{5})(\d{4})", "($1) $2-$3");
                }
                if (foneContato.Length == 12)
                {
                    return Regex.Replace(foneContato, @"(\d{3})(\d{5})(\d{4})", "($1) $2-$3");
                }
                return Regex.Replace(foneContato, @"(\d{4})(\d{4})", "$2-$3");
            }
            return string.Empty;
        }
    }
}