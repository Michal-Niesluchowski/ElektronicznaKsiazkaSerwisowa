using EKS.BackEnd.DAL.Repositories;
using EKS.BackEnd.Models;
using EKS.FullClient.Framework.Navigation;
using EKS.FullClient.Framework.TempData;
using EKS.FullClient.Framework.UserDialog;
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

            var mockUserDialogService = new Mock<IUserDialogService>();
            IUserDialogService userDialogService = mockUserDialogService.Object;
            
            var mockXmlRepository = new Mock<IXmlRepository>();
            IXmlRepository xmlRepository = mockXmlRepository.Object;

            //Act
            MainCarVM viewModel = new MainCarVM(navigationService, tempDataService, 
                userDialogService, xmlRepository);
            PrivateObject privateViewModel = new PrivateObject(viewModel);

            //Assert
            Assert.AreSame(navigationService, privateViewModel.GetField("_navigationService"));
            Assert.AreSame(tempDataService, privateViewModel.GetField("_tempDataService"));
            Assert.AreSame(userDialogService, privateViewModel.GetField("_userDialogService"));
            Assert.AreSame(xmlRepository, privateViewModel.GetField("_xmlRepository"));
            Assert.AreSame(newCar, viewModel.CurrentCar);
        }

        [TestMethod]
        public void BackToMenuCommandTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.HomeControl));

            var mockTempDataService = new Mock<ITempDataService>();
            mockTempDataService.Setup(tds => tds.ClearCar());

            var mockUserDialogService = new Mock<IUserDialogService>();
            mockUserDialogService.Setup(uds => uds.AskForConfirmation(
                "Czy na pewno chcesz przejść do menu? Niezapisane zmiany zostaną utracone.")).Returns(true);

            MainCarVM viewModel = new MainCarVM(mockNavigationService.Object,
                mockTempDataService.Object, mockUserDialogService.Object, null);

            //Act
            viewModel.BackToMenuCommand.Execute(null);

            //Assert
            mockNavigationService.Verify(ns => ns.NavigateToControl(
                ControlsRegister.HomeControl), Times.Once);
            mockTempDataService.Verify(tds => tds.ClearCar(), Times.Once);
            mockUserDialogService.Verify(uds => uds.AskForConfirmation(
                "Czy na pewno chcesz przejść do menu? Niezapisane zmiany zostaną utracone."), Times.Once);
        }

        [TestMethod]
        public void AddNewRepairCommandTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.NewRepairControl));

            var mockTempDataService = new Mock<ITempDataService>();

            MainCarVM viewModel = new MainCarVM(mockNavigationService.Object,
                mockTempDataService.Object, null, null);

            //Act
            viewModel.AddNewRepairCommand.Execute(null);

            //Assert
            mockNavigationService.Verify(ns => ns.NavigateToControl(
                ControlsRegister.NewRepairControl), Times.Once);
        }

        [TestMethod]
        public void EditCarCommandTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.EditCarControl));

            var mockTempDataService = new Mock<ITempDataService>();

            MainCarVM viewModel = new MainCarVM(mockNavigationService.Object,
                mockTempDataService.Object, null, null);

            //Act
            viewModel.EditCarCommand.Execute(null);

            //Assert
            mockNavigationService.Verify(ns => ns.NavigateToControl(
                ControlsRegister.EditCarControl), Times.Once);
        }
        
        [TestMethod]
        public void SaveCarToDriveCommandTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();

            var mockTempDataService = new Mock<ITempDataService>();
            Car testCar = new Car("testname", "testplate");
            mockTempDataService.Setup(tds => tds.LoadCar()).Returns(testCar);

            var mockUserDialogService = new Mock<IUserDialogService>();
            mockUserDialogService.Setup(uds => uds.SaveFile("testname")).Returns("test file path");
            mockUserDialogService.Setup(uds => uds.InformUser("Plik został zapisany."));

            var mockXmlRepository = new Mock<IXmlRepository>();
            mockXmlRepository.Setup(xr => xr.SaveCar(testCar.ToEntity(), "test file path")).Returns(true);

            MainCarVM viewModel = new MainCarVM(mockNavigationService.Object, mockTempDataService.Object,
                mockUserDialogService.Object, mockXmlRepository.Object);

            //Act
            viewModel.SaveCarToDriveCommand.Execute(null);

            //Assert
            mockUserDialogService.Verify(uds => uds.InformUser("Plik został zapisany."), Times.Once);
        }

        [TestMethod]
        public void EditRepairCommandTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.EditRepairControl));

            ITempDataService tempDataService = new TempDataService();

            var mockUserDialogService = new Mock<IUserDialogService>();

            var mockXmlRepository = new Mock<IXmlRepository>();

            MainCarVM viewModel = new MainCarVM(mockNavigationService.Object, tempDataService,
                mockUserDialogService.Object, mockXmlRepository.Object);

            Repair repair = new Repair(DateTime.Today, "desc", 10m, "warsztat");

            //Act
            viewModel.EditRepairCommand.Execute(repair);

            //Assert
            Assert.AreEqual(repair, tempDataService.LoadRepair());
            mockNavigationService.Verify(ns => ns.NavigateToControl(ControlsRegister.EditRepairControl), Times.Once);

        }

        [TestMethod]
        public void DeleteRepairCommandTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();

            ITempDataService tempDataService = new TempDataService();
            Car car = new Car("testname", "testplate");
            Repair repair1 = new Repair(new DateTime(2021, 1, 1), "desc1", 111m, "warsztat1");
            Repair repair2 = new Repair(new DateTime(2021, 2, 2), "desc2", 222m, "warsztat2");
            car.AddRepair(repair1);
            car.AddRepair(repair2);
            tempDataService.SaveCar(car);

            var mockUserDialogService = new Mock<IUserDialogService>();
            mockUserDialogService.Setup(uds => uds.AskForConfirmation("Czy chcesz usunąć naprawę?")).Returns(true);

            var mockXmlRepository = new Mock<IXmlRepository>();

            MainCarVM viewModel = new MainCarVM(mockNavigationService.Object, tempDataService,
                mockUserDialogService.Object, mockXmlRepository.Object);

            //Act
            viewModel.DeleteRepairCommand.Execute(repair1);

            //Assert
            Assert.AreEqual(1, tempDataService.LoadCar().Repairs.Count);
            Assert.AreEqual(repair2, tempDataService.LoadCar().Repairs[0]);
        }
    }
}
