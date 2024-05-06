using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;

namespace HybridEncryption_BusinessLayer
{
    public class clsTribleDES
    {
        public static string EncryptText(string plain, string ky)
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
        public static string DecryptText(string cipher, string ky)
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

  
        public static void EncryptFile(string filpath, string key)
        {
            TripleDESCryptoServiceProvider obj = new TripleDESCryptoServiceProvider();

            obj.Key = UTF8Encoding.UTF8.GetBytes(key);
            obj.Mode = CipherMode.ECB;
            obj.Padding = PaddingMode.PKCS7;


            byte[] Bytes = File.ReadAllBytes(filpath);
            byte[] eBytes = obj.CreateEncryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
            File.WriteAllBytes(filpath, eBytes);
        }

        public static void DecryptFile(string filpath, string key)
        {
            TripleDESCryptoServiceProvider obj = new TripleDESCryptoServiceProvider();

            obj.Key = UTF8Encoding.UTF8.GetBytes(key);
            obj.Mode = CipherMode.ECB;
            obj.Padding = PaddingMode.PKCS7;

            byte[] Bytes = File.ReadAllBytes(filpath);
            byte[] dBytes = obj.CreateDecryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
            File.WriteAllBytes(filpath, dBytes);
        }
    }

}
