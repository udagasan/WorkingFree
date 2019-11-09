using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Process.Test
{
    /// <summary>
    /// FileEncryptionAndDecyption
    /// </summary>
    [TestClass]
    public class FileEncryptionAndDecyption
    {

        public string CurrentCreatedFilePath { get; set; }


        [TestInitialize]
        public void Createfile()
        {
            CurrentCreatedFilePath = FileOperations.CreateRandomTextFile();
        }


        [TestMethod]
        public void EncrptFile()
        {
            FileOperations.EncryptedFile(CurrentCreatedFilePath);
        }

        [TestMethod]
        public void When_Give_An_EncryptedFile_It_Should_Decrypt_LikeOriginal_File()
        {
            //Given
            var oldencrypedFile = FileOperations.GetRandomOldCreatedencryptedFile();
            //When
            FileOperations.DecryptedFile(oldencrypedFile);


        }
    }
}
