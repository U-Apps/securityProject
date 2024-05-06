using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HybridEncryption_BusinessLayer
{
    public class clsDES
    {
        // Constants for key size, block size, and salt size (you can adjust these values)
        private const int AesKeySize = 256;
        private const int AesBlockSize = 128;
        private const int SaltSize = 16;

        public static string Encrypt(string plainText, string key)
        {
            // Check for empty or null inputs
            if (string.IsNullOrEmpty(plainText) || string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("Plain text or key cannot be null or empty.");
            }

            // Derive a strong key from the user-provided key using PBKDF2
            using (var deriveBytes = new Rfc2898DeriveBytes(key, SaltSize))
            {
                byte[] symmetricKey = deriveBytes.GetBytes(AesKeySize / 8);
                byte[] iv = deriveBytes.GetBytes(AesBlockSize / 8);

                // Create a RijndaelManaged object for AES encryption
                using (var aes = new RijndaelManaged())
                {
                    aes.BlockSize = AesBlockSize;
                    aes.KeySize = AesKeySize;
                    aes.Padding = PaddingMode.PKCS7; // Directly set PaddingMode for .NET 6
                    aes.Mode = CipherMode.CBC;

                    // Use streams for encryption
                    using (var encryptor = aes.CreateEncryptor(symmetricKey, iv))
                    using (var memoryStream = new MemoryStream())
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] plaintextBytes = Encoding.UTF8.GetBytes(plainText);
                        cryptoStream.Write(plaintextBytes, 0, plaintextBytes.Length);
                        cryptoStream.FlushFinalBlock();

                        // Convert the encrypted data to Base64 string for easier storage/transmission
                        byte[] cipherTextBytes = memoryStream.ToArray();
                        return Convert.ToBase64String(cipherTextBytes);
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string key)
        {
            // Check for empty or null inputs
            if (string.IsNullOrEmpty(cipherText) || string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("Cipher text or key cannot be null or empty.");
            }

            // Derive the same key and initialization vector (IV) used during encryption
            using (var deriveBytes = new Rfc2898DeriveBytes(key, SaltSize))
            {
                byte[] symmetricKey = deriveBytes.GetBytes(AesKeySize / 8);
                byte[] iv = deriveBytes.GetBytes(AesBlockSize / 8);

                // Create a RijndaelManaged object for AES decryption
                using (var aes = new RijndaelManaged())
                {
                    aes.BlockSize = AesBlockSize;
                    aes.KeySize = AesKeySize;
                    aes.Padding = PaddingMode.PKCS7; // Directly set PaddingMode for .NET 6
                    aes.Mode = CipherMode.CBC;

                    // Use streams for decryption
                    using (var decryptor = aes.CreateDecryptor(symmetricKey, iv))
                    using (var memoryStream = new MemoryStream(Convert.FromBase64String(cipherText)))
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        byte[] cipherTextBytes = new byte[memoryStream.Length];
                        try
                        {

                        int decryptedByteCount = cryptoStream.Read(cipherTextBytes, 0, cipherTextBytes.Length);
                        // Handle incomplete decryption (optional)
                        if (decryptedByteCount != memoryStream.Length)
                        {
                            throw new CryptographicException("Decryption failed: Invalid ciphertext or corrupt data.");
                        return Encoding.UTF8.GetString(cipherTextBytes, 0, decryptedByteCount);
                        }
                        }
                        catch (Exception)
                        {

                            
                        }

                        return "";
                    }
                }
            }
        }
    }


}