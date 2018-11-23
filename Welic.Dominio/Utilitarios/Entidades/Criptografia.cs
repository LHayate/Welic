using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Welic.Dominio.Utilitarios.Entidades
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
        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return Equality(buffer3, buffer4);
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        public static  bool Equality(byte[] a1, byte[] b1)
        {
            int i;
            if (a1.Length == b1.Length)
            {
                i = 0;
                while (i < a1.Length && (a1[i] == b1[i])) //Earlier it was a1[i]!=b1[i]
                {
                    i++;
                }
                if (i == a1.Length)
                {
                    return true;
                }
            }

            return false;
        }
    }
}