using System.Security.Cryptography;
using System.Text;

namespace Taksimetrik.Service.Helpers
{
    public static class PasswordHelper
    {
        public static string Hash(this string text)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(text));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sBuilder.Append(hash[i].ToString("X2"));
            }

            return sBuilder.ToString();
        }
    }
}