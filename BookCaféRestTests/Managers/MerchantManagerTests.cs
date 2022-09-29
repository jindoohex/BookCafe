using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookCaféRest.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCaféModelLib.model;

namespace BookCaféRest.Managers.Tests
{
    [TestClass()]
    public class MerchantManagerTests
    {
        
        // Initialise this to avoid DRY
        private IMerchantManager mgr;

        [TestInitialize]
        public void BeforeEachTest()
        {
            mgr = new MerchantManager();
        }


        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow("Alex")]
        [DataRow("Jeppe")]
        [DataRow("Peppe")]
        [DataRow("Meppe")]
        public void ReadName1(string? name)
        {
            // Arrange
            int expectedValue = 1;

            // Act
            List<Merchant> result = mgr.Read(name);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedValue, result.Count);
        }


        [TestMethod()]
        [DataRow("Peter")]
        public void ReadName2(string? name)
        {
            // Arrange
            int expectedValue = 0;

            // Act
            List<Merchant> result = mgr.Read(name);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedValue, result.Count);
        }


        [TestMethod()]
        [DataRow("Peppe")]
        public void ReadName3(string? name)
        {
            // Arrange
            int expectedValue = 1;

            // Act
            List<Merchant> result = mgr.Read(name);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedValue, result.Count);
        }


        [TestMethod()]
        [DataRow("Meppe")]
        public void ReadName4(string? name)
        {
            // Arrange
            int expectedValue = 1;

            // Act
            List<Merchant> result = mgr.Read(name);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedValue, result.Count);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }
    }
}