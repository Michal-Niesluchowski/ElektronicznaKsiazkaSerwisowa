using EKS.FullClient.ViewModels;
using EKS.FullClient.Services.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Prism.Events;

namespace EKS.Test
{
    [TestClass]
    public class MainWindowViewModelTest
    {
        [TestMethod]
        public void NewMainWindowTest()
        {
            //Arrange
            var mock = new Mock<IEventAggregator>();

            //Act
            MainWindowViewModel viewModel = new MainWindowViewModel(mock.Object);

            //Assert
            viewModel.CurrentPage =
        }
    }
}
