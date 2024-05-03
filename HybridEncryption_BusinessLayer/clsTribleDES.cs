using System.Security.Cryptography;
using System.Text;

namespace HybridEncryption_BusinessLayer
{
    public class clsTribleDES
    {
        public static string Encrypt(string plain, string ky)
        {
            using (TripleDES dt = TripleDES.Create())
            {
                dt.Key = Encoding.UTF8.GetBytes(ky);
                dt.Mode = CipherMode.ECB;
                byte[] bytes = Encoding.UTF8.GetBytes(plain);

                ICryptoTransform crt = dt.CreateEncryptor();
                byte[] eby = crt.TransformFinalBlock(bytes, 0, bytes.Length);

                return Convert.ToBase64String(eby);
            }
        }
        public static string Decrypt(string cipher, string ky)
        {
            using (TripleDES dt = TripleDES.Create())
            {
                dt.Key = Encoding.UTF8.GetBytes(ky);
                dt.Mode = CipherMode.ECB;
                byte[] bytes = Convert.FromBase64String(cipher);

                ICryptoTransform crt = dt.CreateDecryptor();
                byte[] eby = crt.TransformFinalBlock(bytes, 0, bytes.Length);

                return Encoding.UTF8.GetString(eby);
            }
        }
    }
}
