using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace HybridEncryption_BusinessLayer
{
    public static class clsEncoding
    {
        public static string encoding(string text)
        {
            string encodedText="";
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            foreach (byte b in bytes)
            {
                string binary = Convert.ToString(b, 2).PadLeft(8, '0');
                encodedText += binary;
            }
            return encodedText;
        }

        public static string decoding(string text)
        {
            int numOfBytes = text.Length / 8;
            byte[] bytes = new byte[numOfBytes];
            for (int i = 0; i < numOfBytes; ++i)
            {
                bytes[i] = Convert.ToByte(text.Substring(8 * i, 8), 2);
            }
             return Encoding.UTF8.GetString(bytes);
         

        }
    }
}
