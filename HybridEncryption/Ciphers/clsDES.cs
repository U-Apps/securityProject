using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HybridEncryption_PresentaionLayer;

public class clsDES
{
    //when i run my code to encypt file, it shows error says : 

    public static string genrateKey()
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] key = new byte[6];
            rng.GetBytes(key);
            return Convert.ToBase64String(key);
        }
    }
    public static void EncryptFile(string inputFile, string outPutPath, string key)
    {
        using (DESCryptoServiceProvider provider = new DESCryptoServiceProvider())
        {
            provider.Key = UTF8Encoding.UTF8.GetBytes(key);
            provider.Mode = CipherMode.ECB;
            provider.Padding = PaddingMode.PKCS7;
            byte[] Bytes = File.ReadAllBytes(inputFile);

            byte[] eBytes = provider.CreateEncryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
            File.WriteAllBytes(outPutPath, eBytes);


        }


    }



    public static void DecryptFile(string inputFile, string OutPutPath, string key)
    {
        using (DESCryptoServiceProvider provider = new DESCryptoServiceProvider())
        {
            provider.Key = UTF8Encoding.UTF8.GetBytes(key);
            provider.Mode = CipherMode.ECB;
            provider.Padding = PaddingMode.PKCS7;
            byte[] Bytes = File.ReadAllBytes(inputFile);

            byte[] dBytes = provider.CreateDecryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
            File.WriteAllBytes(OutPutPath, dBytes);


        }


    }

    public static string EncryptText(string plainText, string key)
    {
        using (DESCryptoServiceProvider provider = new DESCryptoServiceProvider())
        {
            provider.Key = Encoding.UTF8.GetBytes(key);
            provider.Mode = CipherMode.ECB;
            byte[] bytes = Encoding.UTF8.GetBytes(plainText);

            ICryptoTransform crt = provider.CreateEncryptor();
            byte[] eby = crt.TransformFinalBlock(bytes, 0, bytes.Length);

            return Convert.ToBase64String(eby);
        }
    }
    public static string DecryptText(string encryptedText, string key)
    {
        using (DESCryptoServiceProvider provider = new DESCryptoServiceProvider())
        {
            provider.Key = Encoding.UTF8.GetBytes(key);
            provider.Mode = CipherMode.ECB;
            byte[] bytes = Convert.FromBase64String(encryptedText);

            ICryptoTransform crt = provider.CreateDecryptor();
            byte[] eby = crt.TransformFinalBlock(bytes, 0, bytes.Length);

            return Encoding.UTF8.GetString(eby);
        }
    }
}