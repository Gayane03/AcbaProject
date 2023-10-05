using System.Security.Cryptography;
using System.Text;

namespace AcbaProject.Services.HelperServices
{
    public static class SecurityService
    {
        public static string CalculateSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2")); // "x2" means two hexadecimal digits per byte
                }
                return builder.ToString();
            }
        }

    }
}
