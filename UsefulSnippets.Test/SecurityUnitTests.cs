using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UsefulSnippets.Test
{
    [TestClass]
    public class SecurityUnitTests
    {
        [TestMethod]
        public void EncryptStringTestMethod()
        {
            string expectedData = "sMRmMCcS8gvWQzAfAQBCCg==";
            string actualData = Security.EncryptString("FRC_Scouting_V2");

            Assert.AreEqual(expectedData,actualData,"Encryption is not working correctly");
        }

        [TestMethod]
        public void DecryptStringTestMethod()
        {
            string expectedData = "FRC_Scouting_V2";
            string actualData = Security.DeCryptString("sMRmMCcS8gvWQzAfAQBCCg==");
            Assert.AreEqual(expectedData,actualData,"Decryption is not working correctly");
        }
    }
}
