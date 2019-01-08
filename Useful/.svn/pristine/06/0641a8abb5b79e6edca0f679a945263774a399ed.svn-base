using System.Windows.Forms;
using System;

namespace Classes.Uteis
{
    public static class ConvertString
    {
        /// <summary> 
        /// Converte uma string para o formato bytes ANSI 
        /// </summary> 
        /// <param name="text">string a ser convertida</param> 
        /// <param name="codepage">página de código a ser utilizada, 1252 para o português</param> 
        /// <returns></returns> 
        public static byte[] ConverteStringBlob(string text, int codepage)
        {
            System.Text.Encoding codificador = System.Text.Encoding.GetEncoding(codepage);
            Byte[] ansi = codificador.GetBytes(text);
            return ansi;
        }

    }
}
