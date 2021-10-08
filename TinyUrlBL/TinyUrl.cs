using System;
using System.Security.Cryptography;
using System.Text;

namespace TinyUrlBL
{
    public class TinyUrl : ITinyUrl
    {
        public TinyUrl()
        {
        }

        public string GenerateTinyUrl(string text)
        {
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);

            char[] hash2 = new char[6];

            for (int i = 0; i < hash2.Length; i++)
            {
                hash2[i] = chars[hash[i] % chars.Length];
            }

            return string.Format("{0}/{1}", "localhost:44377/api/TinyUrl/RedirectUrl", new string(hash2));
        }
    }
}
