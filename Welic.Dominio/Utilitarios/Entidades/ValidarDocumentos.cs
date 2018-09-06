using System;
using System.Text.RegularExpressions;

namespace Welic.Dominio.Utilitarios.Entidades
{
    public static class ValidarDocumentos
    {
        public static bool ValidarCpf(string cpf)
        {
            string valor = cpf.Replace(".", "");
            valor = valor.Replace("-", "");
            if (valor.Length != 11)
            {
                return false;
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

        public static bool ValidarCnpj(string cnpj)
        {
            string stringCnpj = cnpj.Replace(".", "");
            stringCnpj = stringCnpj.Replace("/", "");
            stringCnpj = stringCnpj.Replace("-", "");
            if (stringCnpj == "00000000000000")
            {
                return false;
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
                        stringCnpj.Substring(nrDig, 1));
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

        public static bool ValidarCep(string cep)
        {
            if (cep.Length == 8)
            {
                cep = cep.Substring(0, 5) + "-" + cep.Substring(5, 3);
            }
            return Regex.IsMatch(cep, "[0-9]{5}-[0-9]{3}");
        }

        public static bool ValidarEmail(string email)
        {

            if(string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            string regexEmail = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            return Regex.IsMatch(email, regexEmail);
        }

        public static int ObterModulo11(string chave)
        {
            int soma = 0;
            int digitoVerificador;
            int peso = 2;
            for (int i = chave.Length - 1; i != -1; i--)
            {
                int ch = Convert.ToInt32(chave[i].ToString());
                soma += ch * peso;
                if (peso < 9)
                {
                    peso += 1;
                }
                else
                {
                    peso = 2;
                }
            }
            int modulo = soma % 11;
            if (modulo == 0 || modulo == 1)
            {
                digitoVerificador = 0;
            }
            else
            {
                digitoVerificador = 11 - modulo;
            }

            return digitoVerificador;
        }
    }
}