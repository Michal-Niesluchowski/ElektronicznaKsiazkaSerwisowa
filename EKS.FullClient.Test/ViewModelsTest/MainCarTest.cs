using EKS.BackEnd.Models;
using EKS.FullClient.Framework.Navigation;
using EKS.FullClient.Framework.TempData;
using EKS.FullClient.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace EKS.FullClient.Test.ViewModelsTest
{
    [TestClass]
    public class MainCarTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            INavigationService navigationService = mockNavigationService.Object;

            Car newCar = new Car("name", "plate");
            var mockTempDataService = new Mock<ITempDataService>();
            mockTempDataService.Setup(tds => tds.LoadCar()).Returns(newCar);
            ITempDataService tempDataService = mockTempDataService.Object;

            //Act
            MainCarVM viewModel = new MainCarVM(navigationService, tempDataService);
            PrivateObject privateViewModel = new PrivateObject(viewModel);

            //Assert
            Assert.AreSame(navigationService, privateViewModel.GetField("_navigationService"));
            Assert.AreSame(tempDataService, privateViewModel.GetField("_tempDataService"));
            Assert.AreSame(newCar, viewModel.CurrentCar);
        }

        [TestMethod]
        public void BackToMenuCommandTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.HomeControl));

            var mockTempDataService = new Mock<ITempDataService>();

            MainCarVM viewModel = new MainCarVM(mockNavigationService.Object,
                mockTempDataService.Object);

            //Act
            viewModel.BackToMenuCommand.Execute(null);

            //Assert
            mockNavigationService.Verify(ns => ns.NavigateToControl(
                ControlsRegister.HomeControl), Times.Once);
        }

        [TestMethod]
        public void AddNewRepairCommandTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.NewRepairControl));

            var mockTempDataService = new Mock<ITempDataService>();

            MainCarVM viewModel = new MainCarVM(mockNavigationService.Object,
                mockTempDataService.Object);

            //Act
            viewModel.AddNewRepairCommand.Execute(null);

            //Assert
            mockNavigationService.Verify(ns => ns.NavigateToControl(
                ControlsRegister.NewRepairControl), Times.Once);
        }
    }
}
