using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace UseFul.Uteis
{
    public static class CryptographyUtil
    {
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

        public static string EncryptString(string text)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(text));
        }

        public static string DecryptString(string text)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(text));
        }

        private const string Salt = "58D19E9F-8F0A-46FE-A6F5-3E6D6CC69BCD";

        public static string DecryptSecureString(string encryptedData)
        {
            byte[] toEncryptArray = Convert.FromBase64String(encryptedData);

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            byte[] keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(Salt));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return Encoding.UTF8.GetString(resultArray);
        }
    }
}