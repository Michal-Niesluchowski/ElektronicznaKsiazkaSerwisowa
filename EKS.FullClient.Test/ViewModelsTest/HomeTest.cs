using EKS.BackEnd.DAL.Repositories;
using EKS.BackEnd.Models;
using EKS.FullClient.Framework.Navigation;
using EKS.FullClient.Framework.TempData;
using EKS.FullClient.Framework.UserDialog;
using EKS.FullClient.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EKS.FullClient.Test.ViewModelsTest
{
    [TestClass]
    public class HomeTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            INavigationService navigationService = mockNavigationService.Object;

            var mockTempDataService = new Mock<ITempDataService>();
            ITempDataService tempDataService = mockTempDataService.Object;

            var mockUserDialogService = new Mock<IUserDialogService>();
            IUserDialogService userDialogService = mockUserDialogService.Object;

            var mockXmlRepository = new Mock<IXmlRepository>();
            IXmlRepository xmlRepository = mockXmlRepository.Object;

            //Act
            HomeVM viewModel = new HomeVM(navigationService, tempDataService,
                userDialogService, xmlRepository);
            PrivateObject privateViewModel = new PrivateObject(viewModel);

            //Assert
            Assert.AreSame(navigationService, privateViewModel.GetField("_navigationService"));
            Assert.AreSame(tempDataService, privateViewModel.GetField("_tempDataService"));
            Assert.AreSame(userDialogService, privateViewModel.GetField("_userDialogService"));
            Assert.AreSame(xmlRepository, privateViewModel.GetField("_xmlRepository"));
        }

        [TestMethod]
        public void GoToNewCarControlCommandTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.NewCarControl));
            INavigationService navigationService = mockNavigationService.Object;
            HomeVM viewModel = new HomeVM(navigationService, null, null, null);

            //Act
            viewModel.GoToNewCarControlCommand.Execute(null);

            //Assert
            mockNavigationService.Verify(ns => ns.NavigateToControl(ControlsRegister.NewCarControl), Times.Once);
        }

        [TestMethod]
        public void OpenCarCommandTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.MainCarControl));

            ITempDataService tempDataService = new TempDataService();

            var mockUserDialogService = new Mock<IUserDialogService>();
            mockUserDialogService.Setup(uds => uds.OpenFile()).Returns("test file path");

            var mockXmlRepository = new Mock<IXmlRepository>();
            mockXmlRepository.Setup(xr => xr.LoadCar("test file path")).
                Returns(new Car("testname", "testplate").ToEntity);

            HomeVM viewModel = new HomeVM(mockNavigationService.Object, tempDataService,
                mockUserDialogService.Object, mockXmlRepository.Object);

            //Act
            viewModel.OpenCarCommand.Execute(null);

            //Assert
            mockNavigationService.Verify(ns => ns.NavigateToControl(ControlsRegister.MainCarControl), Times.Once);
            Assert.AreEqual(new Car("testname", "testplate"), tempDataService.LoadCar());
        }
    }
}
