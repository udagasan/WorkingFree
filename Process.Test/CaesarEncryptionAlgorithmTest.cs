using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Process.Test
{
    [TestClass]
    public class CaesarEncryptionAlgorithmTest
    {


        [TestMethod]
        public void Encryption()
        {
            //Case
            var source = "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG";

            //When
            var encryptedText = CaesarEncryptionAlgorithm.GenerateEncryptoKey(source, -3);

            //Then
            Assert.AreEqual("QEB NRFZH YOLTK CLU GRJMP LSBO QEB IXWV ALD", encryptedText);

        }

        [TestMethod]
        public void Decryption()
        {
            //Case
            var source = "QEB NRFZH YOLTK CLU GRJMP LSBO QEB IXWV ALD";

            //When
            var decryptedText = CaesarEncryptionAlgorithm.GenerateDecryptoKey(source, -3);

            //Then
            Assert.AreEqual("THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG", decryptedText);
        }

    }
}
