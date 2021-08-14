using EKS.BackEnd.Models;
using EKS.FullClient.Framework.Navigation;
using EKS.FullClient.Framework.TempData;
using EKS.FullClient.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EKS.FullClient.Test.ViewModelsTest
{
    [TestClass]
    public class EditCarTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            INavigationService navigationService = mockNavigationService.Object;

            ITempDataService tempDataService = new TempDataService();
            tempDataService.SaveCar(new Car("name", "plate"));

            //Act
            EditCarVM viewModel = new EditCarVM(navigationService, tempDataService);
            PrivateObject privateViewModel = new PrivateObject(viewModel);

            //Assert
            Assert.AreSame(navigationService, privateViewModel.GetField("_navigationService"));
            Assert.AreSame(tempDataService, privateViewModel.GetField("_tempDataService"));
            Assert.AreEqual("name", privateViewModel.GetField("_carName"));
            Assert.AreEqual("plate", privateViewModel.GetField("_carPlate"));
        }

        [TestMethod]
        public void SaveCarCommandTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.MainCarControl));

            ITempDataService tempDataService = new TempDataService();
            tempDataService.SaveCar(new Car("name", "plate"));

            Car expected = new Car("new name", "new plate");

            EditCarVM viewModel = new EditCarVM(mockNavigationService.Object,
                tempDataService);

            //Act
            viewModel.CarName = "new name";
            viewModel.CarPlate = "new plate";
            viewModel.SaveCarCommand.Execute(null);

            //Assert
            Assert.AreEqual(tempDataService.LoadCar(), expected);
            mockNavigationService.Verify(ns => ns.NavigateToControl(
                ControlsRegister.MainCarControl), Times.Once);
        }

        [TestMethod]
        public void CancelCommandTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.MainCarControl));

            var mockTempDataService = new Mock<ITempDataService>();
            mockTempDataService.Setup(tds => tds.LoadCar()).Returns(new Car("test", "test"));

            EditCarVM viewModel = new EditCarVM(mockNavigationService.Object,
                mockTempDataService.Object);

            //Act
            viewModel.CancelCommand.Execute(null);

            //Assert
            mockNavigationService.Verify(ns => ns.NavigateToControl(
                ControlsRegister.MainCarControl), Times.Once);
        }

        [TestMethod]
        public void CanSaveCarReturnsTrueTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();

            ITempDataService tempDataService = new TempDataService();
            tempDataService.SaveCar(new Car("name", "plate"));

            EditCarVM viewModel = new EditCarVM(mockNavigationService.Object, tempDataService);

            //Act
            PrivateObject privateViewModel = new PrivateObject(viewModel);
            bool actual = (bool)privateViewModel.Invoke("CanSaveCar");

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CanSaveCarReturnsFalseTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();

            ITempDataService tempDataService = new TempDataService();
            tempDataService.SaveCar(new Car("name", "plate"));

            EditCarVM viewModel = new EditCarVM(mockNavigationService.Object, tempDataService);

            //Act
            viewModel.CarName = "";
            viewModel.CarPlate = "";
            PrivateObject privateViewModel = new PrivateObject(viewModel);
            bool actual = (bool)privateViewModel.Invoke("CanSaveCar");

            //Assert
            Assert.IsFalse(actual);
        }
    }
}

