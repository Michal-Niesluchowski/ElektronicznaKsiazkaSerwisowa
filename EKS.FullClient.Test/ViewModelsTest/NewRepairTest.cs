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
    public class NewRepairTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            INavigationService navigationService = mockNavigationService.Object;

            var mockTempDataService = new Mock<ITempDataService>();
            ITempDataService tempDataService = mockTempDataService.Object;

            //Act
            NewRepairVM viewModel = new NewRepairVM(navigationService, tempDataService);
            PrivateObject privateViewModel = new PrivateObject(viewModel);

            //Assert
            Assert.AreEqual(DateTime.Today, privateViewModel.GetField("_repairDate"));
            Assert.AreEqual("...", privateViewModel.GetField("_repairDescription"));
            Assert.AreEqual(0m, privateViewModel.GetField("_repairCost"));
            Assert.AreEqual("...", privateViewModel.GetField("_repairWorkshopName"));
            Assert.AreSame(navigationService, privateViewModel.GetField("_navigationService"));
            Assert.AreSame(tempDataService, privateViewModel.GetField("_tempDataService"));
        }

        [TestMethod]
        public void CancelCommandTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.MainCarControl));

            var mockTempDataService = new Mock<ITempDataService>();

            //Act
            NewRepairVM viewModel = new NewRepairVM(mockNavigationService.Object, mockTempDataService.Object);
            viewModel.CancelCommand.Execute(null);

            //Assert
            mockNavigationService.Verify(ns => ns.NavigateToControl(ControlsRegister.MainCarControl), 
                Times.Once);
        }

        [TestMethod]
        public void AddRepairCommandTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.MainCarControl));

            var mockTempDataService = new Mock<ITempDataService>();
            mockTempDataService.Setup(tds => tds.LoadCar());

            NewRepairVM viewModel = new NewRepairVM(mockNavigationService.Object, mockTempDataService.Object);

            //Act
            viewModel.AddRepairCommand.Execute(null);

            //Assert
            mockTempDataService.Verify(tds => tds.LoadCar(), Times.Once);
            mockNavigationService.Verify(ns => ns.NavigateToControl(ControlsRegister.MainCarControl),
                Times.Once);
        }

        [TestMethod]
        public void AddRepairCommandTest2()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();

            ITempDataService tempDataService = new TempDataService();
            Car testCar = new Car("name", "plate");
            tempDataService.SaveCar(testCar);

            Car expectedCar = new Car("name", "plate");
            expectedCar.AddRepair(new Repair(DateTime.Today, "description", 100m, "workshop"));

            NewRepairVM viewModel = new NewRepairVM(mockNavigationService.Object, tempDataService);
            viewModel.RepairCost = 100m;
            viewModel.RepairDate = DateTime.Today;
            viewModel.RepairDescription = "description";
            viewModel.RepairWorkshopName = "workshop";

            //Act
            viewModel.AddRepairCommand.Execute(null);

            //Assert
            Assert.AreEqual(expectedCar, tempDataService.LoadCar());
            CollectionAssert.AreEqual(expectedCar.Repairs, tempDataService.LoadCar().Repairs);
        }

        [TestMethod]
        public void CanAddCarReturnsFalseTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            var mockTempDataService = new Mock<ITempDataService>();
            NewRepairVM viewModel = new NewRepairVM(mockNavigationService.Object, mockTempDataService.Object);

            //Act
            PrivateObject privateViewModel = new PrivateObject(viewModel);
            bool actual = (bool)privateViewModel.Invoke("CanAddCar");

            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CanAddCarReturnsTrueTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            var mockTempDataService = new Mock<ITempDataService>();

            NewRepairVM viewModel = new NewRepairVM(mockNavigationService.Object, mockTempDataService.Object);
            viewModel.RepairCost = 100m;
            viewModel.RepairDate = DateTime.Today;
            viewModel.RepairDescription = "description";
            viewModel.RepairWorkshopName = "workshop";

            //Act
            PrivateObject privateViewModel = new PrivateObject(viewModel);
            bool actual = (bool)privateViewModel.Invoke("CanAddCar");

            //Assert
            Assert.IsTrue(actual);
        }
    }
}
