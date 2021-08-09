using EKS.FullClient.Framework.Navigation;
using EKS.FullClient.Framework.Events;
using EKS.FullClient.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Events;
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
            var mockEventAggregator = new Mock<EventAggregator>();
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.HomeControl));

            //Act
            MainWindowViewModel viewModel = new MainWindowViewModel(
                mockEventAggregator.Object, mockNavigationService.Object);
            
            //Assert
            mockNavigationService.Verify(ns => ns.NavigateToControl(ControlsRegister.HomeControl), Times.Once);
        }

        [TestMethod]
        public void UpdateCurrentControlTest()
        {
            //Arrange
            var expected = new Mock<UserControl>().Object;
            var mockEventAggregator = new Mock<EventAggregator>().Object;
            var mockNavigationServie = new Mock<INavigationService>().Object;
            
            MainWindowViewModel viewModel = new MainWindowViewModel(mockEventAggregator, mockNavigationServie);

            //Act
            PrivateObject privateViewModel = new PrivateObject(viewModel);
            privateViewModel.Invoke("UpdateCurrentControl", expected);

            //Assert
            Assert.AreEqual(expected, viewModel.CurrentControl);
        }
    }
}