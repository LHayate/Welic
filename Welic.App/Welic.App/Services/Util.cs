using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Plugin.Media;
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
                    return $"{nmImage}.png";
                case Device.Android:
                    return $"{nmImage}.png";
                case Device.UWP:
                    return "Image/" + nmImage + ".png";
                default:
                    return null;
            }
        }
        //public static string ImagePorSistema(string nmImage)
        //{
        //    switch (Device.RuntimePlatform)
        //    {
        //        case Device.iOS:
        //            return $"{nmImage}.png";
        //        case Device.Android:
        //            return $"{nmImage}.png";
        //        case Device.UWP:
        //            return "Image/" + nmImage + ".png";
        //        default:
        //            return null;
        //    }
        //}
        public static string BuscaPrimeiroNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return null;

            string[] Nm = nome.Split(' ');
            return Nm[0];

        }
        public static string ReturnLastName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            string[] Nm = name.Split(' ');
            return Nm.Last();

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

        public static byte[] GetImageStreamAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static async Task<byte[]> ImageToByteArray(Image imgSource)
        {     
            Stream imageStream = null;
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    { Name = "pic.jpg" });
                if (file == null)
                    return null;

            
                 
            imageStream = file.GetStream();
            BinaryReader br = new BinaryReader(imageStream);
            return br.ReadBytes((int) imageStream.Length);
        }

        public static byte[] SetImageDefault()
        {
            var img = new Image();

            img.Source = ImagePorSistema("perfil_Padrao");

            return ImageToByteArray(img).Result;
        }


        /// <summary>
        /// Função que verifica se a string informada “Tes123@#$” will be accepted.
        /// UMA LETRA MINUSCULA
        /// UMA LETRA MAIUSCULA
        /// UM NUMERO
        /// UM ESPECIAL
        /// NO MINIMO 8 CARACTERES
        /// </summary>
        /// <param name=”password”></param>
        /// <returns></returns>
        public static bool IsPasswordStrong(string password)
        {
            int tamanhoMinimo = 8;
            int tamanhoMinusculo = 1;
            int tamanhoMaiusculo = 1;
            int tamanhoNumeros = 1;
            int tamanhoCaracteresEspeciais = 1;

            // Definição de letras minusculas
            Regex regTamanhoMinusculo = new Regex("[a-z]");

            // Definição de letras minusculas
            Regex regTamanhoMaiusculo = new Regex("[A-Z]");

            // Definição de letras minusculas
            Regex regTamanhoNumeros = new Regex("[0-9]");

            // Definição de letras minusculas
            Regex regCaracteresEspeciais = new Regex("[^a-zA-Z0-9]");

            // Verificando tamanho minimo
            if (password.Length < tamanhoMinimo) return false;

            // Verificando caracteres minusculos
            if (regTamanhoMinusculo.Matches(password).Count < tamanhoMinusculo) return false;

            // Verificando caracteres maiusculos
            if (regTamanhoMaiusculo.Matches(password).Count < tamanhoMaiusculo) return false;

            // Verificando numeros
            if (regTamanhoNumeros.Matches(password).Count < tamanhoNumeros) return false;

            // Verificando os diferentes
            if (regCaracteresEspeciais.Matches(password).Count < tamanhoCaracteresEspeciais) return false;

            return true;
        }

    }
}
