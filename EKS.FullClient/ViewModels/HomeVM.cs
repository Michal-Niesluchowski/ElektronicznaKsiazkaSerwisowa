using EKS.BackEnd.DAL.Entities;
using EKS.BackEnd.DAL.Repositories;
using EKS.BackEnd.Models;
using EKS.FullClient.Framework;
using EKS.FullClient.Framework.Navigation;
using EKS.FullClient.Framework.TempData;
using EKS.FullClient.Framework.UserDialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EKS.FullClient.ViewModels
{
    public class HomeVM 
    {
        #region fields
        private INavigationService _navigationService;
        private ITempDataService _tempDataService;
        private IUserDialogService _userDialogService;
        private IXmlRepository _xmlRepository;
        #endregion

        #region constructors
        public HomeVM(INavigationService navigationService,
                      ITempDataService tempDataService,
                      IUserDialogService userDialogService,
                      IXmlRepository xmlRepository)
        {
            _navigationService = navigationService;
            _tempDataService = tempDataService;
            _userDialogService = userDialogService;
            _xmlRepository = xmlRepository;

            GoToNewCarControlCommand = new RelayCommand(action => GoToNewCarControl());
            OpenCarCommand = new RelayCommand(action => OpenCar());
        }
        #endregion

        #region properites
        public ICommand GoToNewCarControlCommand { get; private set; }
        public ICommand OpenCarCommand { get; private set; }
        #endregion

        #region methods
        private void GoToNewCarControl()
        {
            _navigationService.NavigateToControl(ControlsRegister.NewCarControl);
        }

        private void OpenCar()
        {
            string fullFilePath = _userDialogService.OpenFile();

            if (fullFilePath == "")
            {
                return;
            }
            else
            {
                CarEntity newCarEntity = _xmlRepository.LoadCar(fullFilePath);

                if (newCarEntity != null)
                {
                    Car newCar = Car.FromEntity(newCarEntity);

                    _tempDataService.SaveCar(newCar);

                    _navigationService.NavigateToControl(ControlsRegister.MainCarControl);
                }
            }
        }
        #endregion
    }
}
