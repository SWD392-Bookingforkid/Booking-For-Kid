using System.Security.Cryptography;
using System.Text;

namespace Application.Utils
{
    public static class StringUtils
    {
        // password hash with sha-256
        public static string Hash(this string input)
        {
            using SHA256 sha256Hash = SHA256.Create();

            var inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] bytes = sha256Hash.ComputeHash(inputBytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
