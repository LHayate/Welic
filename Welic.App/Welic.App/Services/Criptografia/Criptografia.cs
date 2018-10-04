using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Welic.App.Services.Criptografia
{
    public static class Criptografia
    {
        public static string Encriptar(string text)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(text));
        }

        public static string HashArquivo(string filename)
        {
            using (MD5 md5 = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    return Encoding.Default.GetString(md5.ComputeHash(stream));
                }
            }
        }

        public static string EncriptarMd5(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }

            value += "|1234-123-123-123-123123123";
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(value));
            StringBuilder sbString = new StringBuilder();
            foreach (byte b in data)
            {
                sbString.Append(b.ToString("x2"));
            }
            return sbString.ToString();
        }

        public static string Decriptar(string text)
        {            
            return Encoding.ASCII.GetString(Convert.FromBase64String(text));
        }

        private const string PrefixoSha1 = "sha1=";
        public static bool ConteudoAssinaturaValida(string conteudo, string assinatura, string chaveSecreta)
        {
            if (string.IsNullOrWhiteSpace(conteudo))
            {
                throw new ArgumentNullException(nameof(conteudo));
            }

            if (string.IsNullOrWhiteSpace(assinatura))
            {
                throw new ArgumentNullException(nameof(assinatura));
            }

            if (assinatura.StartsWith(PrefixoSha1, StringComparison.OrdinalIgnoreCase))
            {
                string signatureSemPrefixo = assinatura.Substring(PrefixoSha1.Length);

                byte[] chaveSecretaBytes = Encoding.UTF8.GetBytes(chaveSecreta);
                byte[] conteudoBytes = Encoding.UTF8.GetBytes(conteudo);

                using (HMACSHA1 hmSha1 = new HMACSHA1(chaveSecretaBytes))
                {
                    byte[] hash = hmSha1.ComputeHash(conteudoBytes);

                    string hashString = ToHexString(hash);

                    if (hashString.Equals(signatureSemPrefixo))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static string ToHexString(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder(bytes.Length * 2);
            foreach (byte byteValue in bytes)
            {
                builder.AppendFormat("{0:x2}", byteValue);
            }

            return builder.ToString();
        }
    }
}
