using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes.Uteis
{
    public static class FormataString
    {
        public static string FormataCep(string cep)
        {
            return String.Format("{0:00000-000}", int.Parse(Somente_Numeros(cep)));
        }

        public static string Somente_Numeros(string Texto)
        {
            List<char> numeros = new List<char>("0123456789");
            StringBuilder stringReturn = new StringBuilder(Texto.Length);
            CharEnumerator enumerator = Texto.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (numeros.Contains(enumerator.Current))
                    stringReturn.Append(enumerator.Current);
            }

            return stringReturn.ToString();
        }

        /// <summary>
        /// Retorna a String com as primeiras letras maiusculas
        /// </summary>
        /// <param name="strText">Valor</param>
        public static string PropCase(String texto)
        {
            return new System.Globalization.CultureInfo("pt-BR").TextInfo.ToTitleCase(texto.ToLower()); 
        }

        public static string FormatarCpfCnpj(string cpfCnpj)
        {
            cpfCnpj = cpfCnpj.Replace(".","").Replace("-","").Replace("/","");

            if (cpfCnpj.Length <= 11)
            {
                cpfCnpj = cpfCnpj.PadLeft(11,'0');

                return cpfCnpj.Substring(0, 3) + "." + cpfCnpj.Substring(3, 3) + "." + cpfCnpj.Substring(6, 3) + "-" + cpfCnpj.Substring(9, 2);
            }
            
            if (cpfCnpj.Length < 14)
            {
                cpfCnpj = cpfCnpj.PadLeft(14, '0');
            }
            else
            {
                cpfCnpj = cpfCnpj.Substring(0, 14);
            }

            return cpfCnpj.Substring(0, 2) + "." + cpfCnpj.Substring(2, 3) + "." + cpfCnpj.Substring(5, 3) + "/" + cpfCnpj.Substring(8, 4) + "-" + cpfCnpj.Substring(12, 2);
        }
    
    }
}
