using DesktopApplication.DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EKS.DAL.Test
{
    [TestClass]
    public class RepositoryXMLTest
    {
        [TestMethod]
        public void CreateNewCarTest()
        {
            RepositoryXML repository = new RepositoryXML();
            bool result;

            result = repository.CreateNewCar("testPlate", "testName", "testDescription", @"C:\Users\mnies\Documents\EKS");

            Assert.IsTrue(result);
        }
    }
}
