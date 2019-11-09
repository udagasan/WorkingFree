using System.Linq;

namespace Process
{
    /// <summary>
    /// CaesarEncryptionAlgorithm
    /// </summary>
    public class CaesarEncryptionAlgorithm
    {
        /// <summary>
        /// Generates the encrypto key.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static string GenerateEncryptoKey(string source, int key)
        {
            return string.Join("", source.Select(x => Encrypt(x, key)));
        }
        /// <summary>
        /// Generates the decrypto key.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static string GenerateDecryptoKey(string source, int key)
        {
            return string.Join("", source.Select(x => Decrypt(x, key)));
        }


        /// <summary>
        /// Encrypts the specified character.
        /// </summary>
        /// <param name="chr">The character.</param>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        static char Encrypt(char chr, int n)
        {
            if (chr == ' ')
            {
                return chr;
            }
            int x = chr - 65;

            return (char)((65) + ((x + n + 26) % 26));
        }

        /// <summary>
        /// Decrypts the specified character.
        /// </summary>
        /// <param name="chr">The character.</param>
        /// <param name="n">The n.</param>
        /// <returns></returns>
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
