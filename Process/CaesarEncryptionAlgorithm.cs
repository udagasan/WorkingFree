using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process
{
    public class CaesarEncryptionAlgorithm
    {
        public static string EncryptFile(string source, int key)
        {
            return string.Join("", source.Select(x => Encrypt(x, key)));
        }
        public static string DecrypedFile(string source, int key)
        {
            return string.Join("", source.Select(x => Decrypt(x, key)));
        }


        static char Encrypt(char chr, int n)
        {
            if (chr == ' ')
            {
                return chr;
            }
            int x = chr - 65;

            return (char)((65) + ((x + n + 26) % 26));
        }

        static char Decrypt(char chr, int n)
        {
            if (chr == ' ')
            {
                return chr;
            }
            int x = chr - 65;

            return (char)((65) + ((x - n) % 26));
        }
    }
}
