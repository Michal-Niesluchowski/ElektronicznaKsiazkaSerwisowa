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
    public class EditRepairTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            INavigationService navigationService = mockNavigationService.Object;

            var mockTempDataService = new Mock<ITempDataService>();
            mockTempDataService.Setup(tds => tds.LoadRepair()).Returns(
                new Repair(DateTime.Today, "desc", 10m, "workshop"));
            ITempDataService tempDataService = mockTempDataService.Object;

            //Act
            EditRepairVM viewModel = new EditRepairVM(navigationService, tempDataService);
            PrivateObject privateViewModel = new PrivateObject(viewModel);

            //Assert
            Assert.AreEqual(DateTime.Today, privateViewModel.GetField("_repairDate"));
            Assert.AreEqual("desc", privateViewModel.GetField("_repairDescription"));
            Assert.AreEqual(10m, privateViewModel.GetField("_repairCost"));
            Assert.AreEqual("workshop", privateViewModel.GetField("_repairWorkshopName"));
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
            mockTempDataService.Setup(tds => tds.ClearRepair());
            mockTempDataService.Setup(tds => tds.LoadRepair()).Returns(
                new Repair(DateTime.Today, "desc", 10m, "workshop"));

            //Act
            EditRepairVM viewModel = new EditRepairVM(mockNavigationService.Object, mockTempDataService.Object);
            viewModel.CancelCommand.Execute(null);

            //Assert
            mockNavigationService.Verify(ns => ns.NavigateToControl(ControlsRegister.MainCarControl),
                Times.Once);
            mockTempDataService.Verify(tds => tds.ClearRepair(), Times.Once);
        }

        [TestMethod]
        public void EditRepairCommandTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.MainCarControl));

            ITempDataService tempDataService = new TempDataService();
            Car testCar = new Car("testname", "testplate");
            Repair testRepair1 = new Repair(DateTime.Today, "testdescription1", 111m, "testworkshop2");
            Repair testRepair2 = new Repair(DateTime.Today, "testdescription2", 222m, "testworkshop2");
            testCar.AddRepair(testRepair1);
            testCar.AddRepair(testRepair2);
            tempDataService.SaveCar(testCar);
            tempDataService.SaveRepair(testRepair2);

            EditRepairVM viewModel = new EditRepairVM(mockNavigationService.Object, tempDataService);
            viewModel.RepairDate = new DateTime(2021,8,14);
            viewModel.RepairDescription = "testdescription3";
            viewModel.RepairCost = 333m;
            viewModel.RepairWorkshopName = "testworkshop3";

            //Act
            viewModel.EditRepairCommand.Execute(null);
            Car actual = tempDataService.LoadCar();

            //Assert
            Assert.AreEqual(new DateTime(2021, 8, 14), testRepair2.Date);
            Assert.AreEqual("testdescription3", testRepair2.Description);
            Assert.AreEqual(333m, testRepair2.Cost);
            Assert.AreEqual("testworkshop3", testRepair2.WorkshopName);
            Assert.AreEqual(testRepair1, testCar.Repairs[0]);
            Assert.IsNull(tempDataService.LoadRepair());
            mockNavigationService.Verify(ns => ns.NavigateToControl(ControlsRegister.MainCarControl), Times.Once);
        }

        [TestMethod]
        public void CanEditRepairReturnsTrueTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();

            var mockTempDataService = new Mock<ITempDataService>();
            mockTempDataService.Setup(tds => tds.LoadRepair()).Returns(
                new Repair(DateTime.Today, "desc", 10m, "workshop"));

            EditRepairVM viewModel = new EditRepairVM(mockNavigationService.Object, mockTempDataService.Object);

            //Act
            PrivateObject privateViewModel = new PrivateObject(viewModel);
            bool actual = (bool)privateViewModel.Invoke("CanEditRepair");

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CanEditRepairReturnsFalseTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();

            var mockTempDataService = new Mock<ITempDataService>();
            mockTempDataService.Setup(tds => tds.LoadRepair()).Returns(
                new Repair(DateTime.Today, "desc", 10m, "workshop"));

            EditRepairVM viewModel = new EditRepairVM(mockNavigationService.Object, mockTempDataService.Object);
            viewModel.RepairDate = default;
            viewModel.RepairDescription = "...";
            viewModel.RepairCost = default;
            viewModel.RepairWorkshopName = "";

            //Act
            PrivateObject privateViewModel = new PrivateObject(viewModel);
            bool actual = (bool)privateViewModel.Invoke("CanEditRepair");

            //Assert
            Assert.IsFalse(actual);
        }
    }
}
