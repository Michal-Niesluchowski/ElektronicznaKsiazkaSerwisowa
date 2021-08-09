﻿using EKS.FullClient.Framework.Navigation;
using EKS.FullClient.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Events;
using System;
using System.Windows.Input;

namespace EKS.FullClient.Test.ViewModelsTest
{
    [TestClass]
    public class HomeViewModelTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            INavigationService navigationService = mockNavigationService.Object;

            //Act
            HomeViewModel viewModel = new HomeViewModel(navigationService);
            PrivateObject privateViewModel = new PrivateObject(viewModel);

            //Assert
            Assert.AreSame(navigationService, privateViewModel.GetField("_navigationService"));
        }

        [TestMethod]
        public void GoToNewCarControlCommandTest()
        {
            //Arrange
            var mockNavigationService = new Mock<INavigationService>();
            mockNavigationService.Setup(ns => ns.NavigateToControl(ControlsRegister.NewCarControl));
            INavigationService navigationService = mockNavigationService.Object;
            HomeViewModel viewModel = new HomeViewModel(navigationService);

            //Act
            viewModel.GoToNewCarControlCommand.Execute(null);

            //Assert
            mockNavigationService.Verify(ns => ns.NavigateToControl(ControlsRegister.NewCarControl), Times.Once);
        }
    }
}
