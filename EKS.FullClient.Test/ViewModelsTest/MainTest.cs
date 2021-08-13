using EKS.FullClient.Framework.Navigation;
using EKS.FullClient.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Windows.Controls;

namespace EKS.FullClient.Test.ViewModelsTest
{
    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.HomeControl));

            //Act
            MainVM viewModel = new MainVM(mockNavigationService.Object);
            
            //Assert
            mockNavigationService.Verify(ns => ns.NavigateToControl(ControlsRegister.HomeControl), Times.Once);
            mockNavigationService.VerifyAdd(ns => ns.ControlChange += It.IsAny<EventHandler<UserControl>>(), Times.Once);
        }

        [TestMethod]
        public void UpdateCurrentControlTest()
        {
            //Arrange
            var expected = new Mock<UserControl>().Object;
            var mockNavigationServie = new Mock<INavigationService>().Object;
            
            MainVM viewModel = new MainVM(mockNavigationServie);

            //Act
            PrivateObject privateViewModel = new PrivateObject(viewModel);
            privateViewModel.Invoke("UpdateCurrentControl", null, expected);

            //Assert
            Assert.AreEqual(expected, viewModel.CurrentControl);
        }
    }
}