using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Process
{
    /// <summary>
    /// FileOperations
    /// </summary>
    public class FileOperations
    {
        /// <summary>
        /// Creates the random text file.
        /// </summary>
        /// <returns></returns>
        internal static string CreateRandomTextFile()
        {

            var fileName = string.Format("{0}.txt", DateTime.Now.ToString("yyyyMMdd_HHss"));

            var fs = File.Create(fileName);
            fs.Close();
            var fullPath = Path.GetFullPath(fileName);
            File.AppendAllText(fullPath, "TestData");
            return fullPath;
        }
        /// <summary>
        /// Gets the random old createdencrypted file.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        internal static string GetRandomOldCreatedencryptedFile()
        {
            var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt")?.ToList();
            var encryptedFile = files?.Where(x => Path.GetFileName(x).StartsWith("E"))?.FirstOrDefault();
            if (string.IsNullOrWhiteSpace(encryptedFile))
            {
                throw new FileNotFoundException();
            }
            return encryptedFile;
        }
        /// <summary>
        /// Encrypteds the file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static void EncryptedFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }
            var fileName = Path.GetFileName(filePath);

            var cryptoKey = CaesarEncryptionAlgorithm.GenerateEncryptoKey(fileName, -3);

            var outputFileName = string.Concat("E", fileName);
            EncryptFile(filePath, outputFileName, cryptoKey);
        }
        /// <summary>
        /// Decrypteds the file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <exception cref="FileNotFoundException">filePath
        /// or
        /// EncryptedFileNotFound</exception>
        public static void DecryptedFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(nameof(filePath));
            }
            var fileName = Path.GetFileName(filePath);
            if (!fileName.StartsWith("E"))
            {
                throw new FileNotFoundException("EncryptedFileNotFound");
            }
            var originalFileName = fileName.Substring(1, fileName.Length - 1);
            var chryptoKey = CaesarEncryptionAlgorithm.GenerateEncryptoKey(originalFileName, -3);


            var outputFileName = string.Concat("D", originalFileName);
            DecryptFile(filePath, outputFileName, chryptoKey);
        }

        /// <summary>
        /// Encrypts the file.
        /// </summary>
        /// <param name="inputFile">The input file.</param>
        /// <param name="outputFile">The output file.</param>
        /// <param name="skey">The skey.</param>
        static void EncryptFile(string inputFile, string outputFile, string skey)
        {
            try
            {
                using (var aes = new RijndaelManaged { BlockSize = 256 })
                {
                    byte[] key = Encoding.UTF8.GetBytes(skey);

                    var IV = new byte[256 / 8];

                    using (FileStream fsCrypt = new FileStream(outputFile, FileMode.CreateNew))
                    {
                        using (ICryptoTransform encryptor = aes.CreateEncryptor(key, IV))
                        {
                            using (CryptoStream cs = new CryptoStream(fsCrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                                {
                                    int data;
                                    while ((data = fsIn.ReadByte()) != -1)
                                    {
                                        cs.WriteByte((byte)data);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Decrypts the file.
        /// </summary>
        /// <param name="inputFile">The input file.</param>
        /// <param name="outputFile">The output file.</param>
        /// <param name="skey">The skey.</param>
        /// <returns></returns>
        static bool DecryptFile(string inputFile, string outputFile, string skey)
        {
            try
            {
                using (var aes = new RijndaelManaged { BlockSize = 256 })
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);

                    var IV = new byte[256 / 8];

                    using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open))
                    {
                        using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                        {
                            using (ICryptoTransform decryptor = aes.CreateDecryptor(key, IV))
                            {
                                using (CryptoStream cs = new CryptoStream(fsCrypt, decryptor, CryptoStreamMode.Read))
                                {
                                    int data;
                                    while ((data = cs.ReadByte()) != -1)
                                    {
                                        fsOut.WriteByte((byte)data);
                                    }
                                }
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
