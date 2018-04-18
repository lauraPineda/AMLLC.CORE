using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AMLLC.CORE.SHARED;

namespace AMLLC.CORE.TEST
{
    [TestClass]
    public class HashTest
    {
        [TestMethod]
        public void TestMethod1()
        {

            string Pass=HashEncryption.Hash("TextPassword");

            bool ValidatePass= HashEncryption.VerifyHashPassword(Pass, "TextPassword");

            Assert.IsTrue(ValidatePass);
        }
    }
}
