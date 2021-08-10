using EKS.FullClient.Framework.Navigation;
using EKS.FullClient.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Windows.Controls;

namespace EKS.FullClient.Test.ViewModelsTest
{
    [TestClass]
    public class MainWindowViewModelTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.HomeControl));

            //Act
            MainWindowViewModel viewModel = new MainWindowViewModel(mockNavigationService.Object);
            
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
            
            MainWindowViewModel viewModel = new MainWindowViewModel(mockNavigationServie);

            //Act
            PrivateObject privateViewModel = new PrivateObject(viewModel);
            privateViewModel.Invoke("UpdateCurrentControl", null, expected);

            //Assert
            Assert.AreEqual(expected, viewModel.CurrentControl);
        }
    }
}