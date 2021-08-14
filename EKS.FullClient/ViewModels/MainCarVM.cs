using EKS.BackEnd.Models;
using EKS.FullClient.Framework;
using EKS.FullClient.Framework.Navigation;
using EKS.FullClient.Framework.TempData;
using EKS.FullClient.Framework.DesignData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using EKS.FullClient.Framework.UserDialog;
using EKS.BackEnd.DAL.Repositories;
using EKS.BackEnd.DAL.Entities;

namespace EKS.FullClient.ViewModels
{
    public class MainCarVM : INotifyPropertyChanged
    {
        #region fields
        private Car _currentCar;
        private INavigationService _navigationService;
        private ITempDataService _tempDataService;
        private IUserDialogService _userDialogService;
        private IXmlRepository _xmlRepository;
        #endregion

        #region constructors
        //Parameterless constructor used solely for designing in xaml
        public MainCarVM()
        {
            CurrentCar = DesignDataService.CreateCarWithRepairs();
        }

        public MainCarVM(INavigationService navigationService,
                         ITempDataService tempDataService,
                         IUserDialogService fileDialogService,
                         IXmlRepository xmlRepository)
        {
            _navigationService = navigationService;
            _tempDataService = tempDataService;
            _userDialogService = fileDialogService;
            _xmlRepository = xmlRepository;

            CurrentCar = _tempDataService.LoadCar();

            this.BackToMenuCommand = new RelayCommand(action => GoToMenu());
            this.AddNewRepairCommand = new RelayCommand(action => GotoAddNewRepair());
            this.EditCarCommand = new RelayCommand(action => EditCar());
            this.SaveCarToDriveCommand = new RelayCommand(action => SaveCarToDrive());
        }
        #endregion

        #region interfaces
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(
            [System.Runtime.CompilerServices.CallerMemberName]
            string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region properties
        public Car CurrentCar
        {
            get
            {
                return _currentCar;
            }
            set
            {
                _currentCar = value;
                OnPropertyChanged();
            }
        }

        public ICommand BackToMenuCommand { get; private set; }
        public ICommand AddNewRepairCommand { get; private set; }
        public ICommand EditCarCommand { get; private set; }
        public ICommand SaveCarToDriveCommand { get; private set; }
        #endregion

        #region methods
        private void GoToMenu()
        {
            _navigationService.NavigateToControl(ControlsRegister.HomeControl);
        }

        private void GotoAddNewRepair()
        {
            _navigationService.NavigateToControl(ControlsRegister.NewRepairControl);
        }

        private void EditCar()
        {
            _navigationService.NavigateToControl(ControlsRegister.EditCarControl);
        }

        private void SaveCarToDrive()
        {
            string fullFilePath = _userDialogService.SaveFile(CurrentCar.Name);
            
            if (fullFilePath == "")
            {
                return;
            }
            else
            {
                CarEntity newCarEntity = CurrentCar.ToEntity();

                bool outcome = _xmlRepository.SaveCar(newCarEntity, fullFilePath);

                if (outcome == true)
                {
                    _userDialogService.InformUser("Plik z Twoim autem został zapisany.");
                }
                else
                {
                    _userDialogService.InformUser("Nie udało się zapisać pliku.");
                }
            }
        }
        #endregion
    }
}
