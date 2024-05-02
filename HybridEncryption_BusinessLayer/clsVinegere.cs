using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buissnessLayer
{
    public static class clsVinegere
    {
        

      

        public static string Encrypt(string plaintext , string keyword)
        {
            StringBuilder ciphertext = new StringBuilder();
            string adjustedPlaintext = AdjustPlaintext(plaintext);
           
            for (int i = 0; i < adjustedPlaintext.Length; i++)
            {
                char plainChar = adjustedPlaintext[i];
                char keyChar = keyword[i % keyword.Length];
                char encryptedChar = EncryptChar(plainChar, keyChar);
                ciphertext.Append(encryptedChar);
            }

            return ciphertext.ToString();
        }

        public static string Decrypt(string ciphertext, string keyword)
        {
            StringBuilder plaintext = new StringBuilder();
            for (int i = 0; i < ciphertext.Length; i++)
            {
                char cipherChar = ciphertext[i];
                char keyChar = keyword[i % keyword.Length];
                char decryptedChar = DecryptChar(cipherChar, keyChar);
                plaintext.Append(decryptedChar);
            }

            return plaintext.ToString();
        }

        private static char EncryptChar(char plainChar, char keyChar)
        {
            int baseIndex = GetBaseIndex(plainChar);
            int plainIndex = GetCharIndex(plainChar, baseIndex);
            int keyIndex = GetCharIndex(keyChar, baseIndex);
            int encryptedIndex = (plainIndex + keyIndex) % GetCharacterSetLength(baseIndex);
            return GetCharFromIndex(baseIndex, encryptedIndex);
        }

        private static char DecryptChar(char cipherChar, char keyChar)
        {
            int baseIndex = GetBaseIndex(cipherChar);
            int cipherIndex = GetCharIndex(cipherChar, baseIndex);
            int keyIndex = GetCharIndex(keyChar, baseIndex);
            int decryptedIndex = (cipherIndex - keyIndex + GetCharacterSetLength(baseIndex)) % GetCharacterSetLength(baseIndex);
            return GetCharFromIndex(baseIndex, decryptedIndex);
        }

        private static int GetBaseIndex(char c)
        {
            if (char.IsUpper(c))
                return 'A';
            else if (char.IsLower(c))
                return 'a';
            else
                return 0; 
        }

        private static int GetCharIndex(char c, int baseIndex)
        {
            return c - baseIndex;
        }

        private static int GetCharacterSetLength(int baseIndex)
        {
            return 26;
        }

        private static char GetCharFromIndex(int baseIndex, int index)
        {
            return (char)(baseIndex + index);
        }

        private static string AdjustPlaintext(string plaintext)
        {
            StringBuilder adjustedText = new StringBuilder();

            foreach (char c in plaintext)
            {
                if (char.IsLetterOrDigit(c))
                    adjustedText.Append(c);
            }

            return adjustedText.ToString();
        }
    }
}

