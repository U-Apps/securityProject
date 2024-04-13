using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buissnessLayer
{
    public static class clsCaeser
    {
        public static string encrypt(string text , int shift)
        {
            string ciphertext = "";

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char encryptedChar = (char)(((c - 'A') + shift) % 26 + 'A');
                    ciphertext += encryptedChar;
                }
                else
                {
                    ciphertext += c;
                }
            }

            return ciphertext;

        }

        public static string decrypt(string text, int shift)
        {
            string decryptedText = "";

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char decryptedChar = (char)(((c - 'A') - shift + 26) % 26 + 'A');
                    decryptedText += decryptedChar;
                }
                else
                {
                    decryptedText += c;
                }
            }

            return decryptedText;

        }
    }
}
