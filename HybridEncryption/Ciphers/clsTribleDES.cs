using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;

namespace HybridEncryption_BusinessLayer
{
    public class clsTribleDES
    {
        public static string genrateKey()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] key = new byte[18];
                rng.GetBytes(key);
                return Convert.ToBase64String(key);
            }
        }
        public static string EncryptText(string plainText, string key)
        {


            using (TripleDESCryptoServiceProvider Provider = new TripleDESCryptoServiceProvider())
            {
                Provider.Mode = CipherMode.ECB;
                Provider.Key = Encoding.UTF8.GetBytes(key);


                using (MemoryStream memoryStream = new MemoryStream())
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, Provider.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                    cryptoStream.FlushFinalBlock();

                    byte[] encryptedBytes = memoryStream.ToArray();
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
        }

        public static string DecryptText(string encryptedText, string key)
        {

            using (TripleDESCryptoServiceProvider Provider = new TripleDESCryptoServiceProvider())
            {
                Provider.Mode = CipherMode.ECB;
                Provider.Key = Encoding.UTF8.GetBytes(key);
                ICryptoTransform crt = Provider.CreateDecryptor();
                byte[] bytes = Convert.FromBase64String(encryptedText);
                byte[] eby = crt.TransformFinalBlock(bytes, 0, bytes.Length);

                return Encoding.UTF8.GetString(eby);


            }
        }



        public static void EncryptFile(string inputFile, string outputFile, string key)
        {
            using (TripleDESCryptoServiceProvider Provider = new TripleDESCryptoServiceProvider())
            {
                Provider.Key = UTF8Encoding.UTF8.GetBytes(key);
                Provider.Mode = CipherMode.ECB;
                Provider.Padding = PaddingMode.PKCS7;
                byte[] Bytes = File.ReadAllBytes(inputFile);

                byte[] eBytes = Provider.CreateEncryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
                File.WriteAllBytes(outputFile, eBytes);


            }
        }


        public static void DecryptFile(string inputFile, string outputFile, string key)
        {
            using (TripleDESCryptoServiceProvider Provider = new TripleDESCryptoServiceProvider())
            {
                Provider.Key = Encoding.UTF8.GetBytes(key);
                Provider.Key = UTF8Encoding.UTF8.GetBytes(key);
                Provider.Mode = CipherMode.ECB;
                Provider.Padding = PaddingMode.PKCS7;
                byte[] Bytes = File.ReadAllBytes(inputFile);

                byte[] dBytes = Provider.CreateDecryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
                File.WriteAllBytes(outputFile, dBytes);

            }
        }
    }

}
