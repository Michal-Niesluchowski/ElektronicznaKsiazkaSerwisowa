using EKS.FullClient.Services.EventAggregatorService;
using EKS.FullClient.ViewModels;
using EKS.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Events;
using System;

namespace EKS.Test
{
    [TestClass]
    public class NewCarViewModelTest
    {
        [TestMethod]
        public void CanCreateNewCarTest()
        {
            //Arrange
            var mock = new Mock<IEventAggregator>();
            
            NewCarViewModel viewModel = new NewCarViewModel(mock.Object);
            viewModel.CarPlate = "TestPlate";
            viewModel.CarName = "TestCar";
            viewModel.CarDescription = "TestDescription";

            //Act
            PrivateObject priv = new PrivateObject(viewModel);
            bool actual = (bool)priv.Invoke("CanCreateNewCar", null);

            //Assert
            Assert.IsTrue(actual);
        }
    }
}
