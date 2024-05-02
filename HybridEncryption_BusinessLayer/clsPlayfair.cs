using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridEncryption_BusinessLayer
{
    public static class clsPlayfair
    {
        private const string Alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
      
        public static string Encrypt(string plaintext, string keyword)
        {
            string adjustedPlaintext = AdjustPlaintext(plaintext);
            char[,] playfairSquare = GeneratePlayfairSquare(keyword);
            StringBuilder ciphertext = new StringBuilder();

            for (int i = 0; i < adjustedPlaintext.Length; i += 2)
            {
                char char1 = adjustedPlaintext[i];
                char char2 = adjustedPlaintext[i + 1];

                int row1, col1, row2, col2;
                GetCharPosition(playfairSquare, char1, out row1, out col1);
                GetCharPosition(playfairSquare, char2, out row2, out col2);

                char encryptedChar1, encryptedChar2;
                if (row1 == row2)
                {
                    encryptedChar1 = playfairSquare[row1, (col1 + 1) % 5];
                    encryptedChar2 = playfairSquare[row2, (col2 + 1) % 5];
                }
                else if (col1 == col2)
                {
                    encryptedChar1 = playfairSquare[(row1 + 1) % 5, col1];
                    encryptedChar2 = playfairSquare[(row2 + 1) % 5, col2];
                }
                else
                {
                    encryptedChar1 = playfairSquare[row1, col2];
                    encryptedChar2 = playfairSquare[row2, col1];
                }

                ciphertext.Append(encryptedChar1);
                ciphertext.Append(encryptedChar2);
            }

            return ciphertext.ToString();
        }

        public static string Decrypt(string ciphertext, string keyword)
        {
            StringBuilder plaintext = new StringBuilder();
            char[,] playfairSquare = GeneratePlayfairSquare(keyword);
            for (int i = 0; i < ciphertext.Length; i += 2)
            {
                char char1 = ciphertext[i];
                char char2 = ciphertext[i + 1];

                int row1, col1, row2, col2;
                GetCharPosition(playfairSquare, char1, out row1, out col1);
                GetCharPosition(playfairSquare, char2, out row2, out col2);

                char decryptedChar1, decryptedChar2;
                if (row1 == row2)
                {
                    decryptedChar1 = playfairSquare[row1, (col1 + 4) % 5];
                    decryptedChar2 = playfairSquare[row2, (col2 + 4) % 5];
                }
                else if (col1 == col2)
                {
                    decryptedChar1 = playfairSquare[(row1 + 4) % 5, col1];
                    decryptedChar2 = playfairSquare[(row2 + 4) % 5, col2];
                }
                else
                {
                    decryptedChar1 = playfairSquare[row1, col2];
                    decryptedChar2 = playfairSquare[row2, col1];
                }

                plaintext.Append(decryptedChar1);
                plaintext.Append(decryptedChar2);
            }

            return plaintext.ToString();
        }
     

        static string AdjustPlaintext(string plaintext)
        {
            StringBuilder adjustedText = new StringBuilder();

            for (int i = 0; i < plaintext.Length; i += 2)
            {
                char char1 = plaintext[i];
                char char2 = (i + 1 < plaintext.Length) ? plaintext[i + 1] : 'X';

                if (char1 == char2)
                {
                    adjustedText.Append(char1);
                    adjustedText.Append('X');
                    adjustedText.Append(char2);
                }
                else
                {
                    adjustedText.Append(char1);
                    adjustedText.Append(char2);
                }
            }

            return adjustedText.ToString();
        }

      
             static char[,] GeneratePlayfairSquare(string keyword)
            {
                char[,] square = new char[5, 5];

               
                int keywordIndex = 0;
                foreach (char c in keyword.ToUpper())
                {
                    if (Alphabet.Contains(c) && !square.ToString().Contains(c))
                    {
                        
                        square[keywordIndex / 5, keywordIndex % 5] = c;
                        keywordIndex++;
                    }
                }
                int alphabetIndex = 0;
                for (int i = keywordIndex; i < 25; i++)
                {
                    char c = Alphabet[alphabetIndex];
                    if (!square.ToString().Contains(c))
                    {
                        square[i / 5, i % 5] = c;
                        alphabetIndex++;
                    }
                }

                return square;
            }

        private static void GetCharPosition(char[,] playfairSquare, char c, out int row, out int col)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (playfairSquare[i, j] == c)
                    {
                        row = i;
                        col = j;
                        return;
                    }
                }
            }

            throw new ArgumentException("Character not found in the playfair square.");
        }
    }
}

