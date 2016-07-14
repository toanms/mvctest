using System;
using System.Text;

namespace Ca.Skoolbo.Homesite.Helpers
{
    public static class EncryptHelper
    {
        public static string Md5(this string strToEncrypt)
        {
            var ue = new UTF8Encoding();
            byte[] bytes = ue.GetBytes(strToEncrypt);

            // encrypt bytes
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashBytes = md5.ComputeHash(bytes);

            // Convert the encrypted bytes back to a string (base 16)
            string hashString = string.Empty;

            for (int i = 0; i < hashBytes.Length; i++)
            {
                hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
            }

            return hashString.PadLeft(32, '0');

        }

        public static string GeneratePaymentKey(string text="")
        {
            var tick = DateTime.Now.Ticks;
            var ran = new Random();
            double num1 = ran.Next(1000, 2000);
            double num2 = ran.Next(2001, 3000);
            var keyText= $"{text}{tick}-{num1 % num2}";
            return keyText.Md5();
        }
    }
}
