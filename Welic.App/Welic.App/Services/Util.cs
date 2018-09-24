﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Welic.App.Services
{
    public class Util
    {
        public static string ImagePorSistema(string nmImage)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    return nmImage + ".png";
                case Device.Android:
                    return nmImage;
                case Device.UWP:
                    return "Imagens/" + nmImage + ".png";
                default:
                    return null;
            }
        }
        public static string BuscaPrimeiroNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return null;

            string[] Nm = nome.Split(' ');
            return Nm[0];

        }

        public static string RemoveCaracter(string str)
        {

            /** Troca os caracteres acentuados por não acentuados **/
            string[] acentos = new string[] { "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û" };
            string[] semAcento = new string[] { "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };

            for (int i = 0; i < acentos.Length; i++)
            {
                str = str.Replace(acentos[i], semAcento[i]);
            }

            /** Troca os caracteres especiais da string por "" **/
            string[] caracteresEspeciais = { ".", ",", "-", ":", "(", ")", "ª", "|", "\\", "°", "<", ">", ";", "{", "}", "^", "~", "=", "/", "º", "?", "!", "+", "°", "%", "$", "'" };

            for (int i = 0; i < caracteresEspeciais.Length; i++)
            {
                str = str.Replace(caracteresEspeciais[i], "");
            }

            /** Troca os espaços no início por "" **/
            str = str.Replace("^\\s+", "");
            /** Troca os espaços no início por "" **/
            str = str.Replace("\\s+$", "");
            /** Troca os espaços duplicados, tabulações e etc por  " " **/
            str = str.Replace("\\s+", " ");

            return str;
        }
    }
}
