using EKS.BackEnd.Models;
using EKS.FullClient.Framework.Navigation;
using EKS.FullClient.Framework.TempData;
using EKS.FullClient.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EKS.FullClient.Test.ViewModelsTest
{
    [TestClass]
    public class NewCarTest
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
            NewCarVM viewModel = new NewCarVM(navigationService, tempDataService);
            PrivateObject privateViewModel = new PrivateObject(viewModel);

            //Assert
            Assert.AreSame(navigationService, privateViewModel.GetField("_navigationService"));
            Assert.AreSame(tempDataService, privateViewModel.GetField("_tempDataService"));
            Assert.AreEqual("...", privateViewModel.GetField("_carName"));
            Assert.AreEqual("...", privateViewModel.GetField("_carPlate"));
        }
        
        [TestMethod]
        public void NewCarCommandTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.MainCarControl));
            
            var mockTempDataService = new Mock<ITempDataService>();
            Car newCar = new Car("...", "...");
            mockTempDataService.Setup(tds => tds.SaveCar(newCar));

            NewCarVM viewModel = new NewCarVM(mockNavigationService.Object, 
                mockTempDataService.Object);

            //Act
            viewModel.NewCarCommand.Execute(null);

            //Assert
            mockNavigationService.Verify(ns => ns.NavigateToControl(
                ControlsRegister.MainCarControl), Times.Once);

            mockTempDataService.Verify(tds => tds.SaveCar(newCar), Times.Once);
        }

        [TestMethod]
        public void CancelCommandTest() 
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.HomeControl));

            var mockTempDataService = new Mock<ITempDataService>();

            NewCarVM viewModel = new NewCarVM(mockNavigationService.Object,
                mockTempDataService.Object);

            //Act
            viewModel.CancelCommand.Execute(null);

            //Assert
            mockNavigationService.Verify(ns => ns.NavigateToControl(
                ControlsRegister.HomeControl), Times.Once);
        }

        [TestMethod]
        public void CanCreateNewCarTestReturnsFalse()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            var mockTempDataService = new Mock<ITempDataService>();

            NewCarVM viewModel = new NewCarVM(mockNavigationService.Object,
                mockTempDataService.Object);

            //Act
            PrivateObject privateViewModel = new PrivateObject(viewModel);
            bool actual = (bool)privateViewModel.Invoke("CanCreateNewCar");

            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CanCreateNewCarTestReturnsTrue()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            var mockTempDataService = new Mock<ITempDataService>();

            NewCarVM viewModel = new NewCarVM(mockNavigationService.Object,
                mockTempDataService.Object);

            //Act
            viewModel.CarName = "Not empty";
            viewModel.CarPlate = "Not empty";
            PrivateObject privateViewModel = new PrivateObject(viewModel);
            bool actual = (bool)privateViewModel.Invoke("CanCreateNewCar");

            //Assert
            Assert.IsTrue(actual);
        }
    }
}
