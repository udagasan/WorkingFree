using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Process.Test
{
    /// <summary>
    /// CaesarEncryptionAlgorithmTest
    /// </summary>
    [TestClass]
    public class CaesarEncryptionAlgorithmTest
    {


        [TestMethod]
        public void Encryption()
        {
            //Given
            var source = "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG";

            //When
            var encryptedText = CaesarEncryptionAlgorithm.GenerateEncryptoKey(source, -3);

            //Then
            Assert.AreEqual("QEB NRFZH YOLTK CLU GRJMP LSBO QEB IXWV ALD", encryptedText);

        }

        [TestMethod]
        public void Decryption()
        {
            //Given
            var source = "QEB NRFZH YOLTK CLU GRJMP LSBO QEB IXWV ALD";

            //When
            var decryptedText = CaesarEncryptionAlgorithm.GenerateDecryptoKey(source, -3);

            //Then
            Assert.AreEqual("THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG", decryptedText);
        }

    }
}
