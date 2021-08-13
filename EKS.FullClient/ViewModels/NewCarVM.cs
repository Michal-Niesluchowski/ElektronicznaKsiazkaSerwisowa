using EKS.BackEnd.Models;
using EKS.FullClient.Framework.Navigation;
using EKS.FullClient.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using EKS.FullClient.Framework.TempData;

namespace EKS.FullClient.ViewModels
{
    public class NewCarVM : INotifyPropertyChanged
    {
        #region fields
        private string _carName = "...";
        private string _carPlate = "...";
        private INavigationService _navigationService;
        private ITempDataService _tempDataService;
        #endregion

        #region constructors
        public NewCarVM(INavigationService navigationService, ITempDataService tempDataService)
        {
            _navigationService = navigationService;
            _tempDataService = tempDataService;

            this.NewCarCommand = new RelayCommand(
                action => CreateNewCar(),
                enable => CanCreateNewCar()); ;

            this.CancelCommand = new RelayCommand(
                action => Cancel());
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
        public string CarName
        {
            get { return _carName; }
            set { _carName = value; }
        }
        public string CarPlate
        {
            get { return _carPlate; }
            set { _carPlate = value; }
        }

        public ICommand NewCarCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        #endregion

        #region methods
        private void CreateNewCar()
        {
            Car newCar = new Car(CarName, CarPlate);
            _tempDataService.SaveCar(newCar);
            _navigationService.NavigateToControl(ControlsRegister.MainCarControl);
        }

        private bool CanCreateNewCar()
        {
            if (CarPlate == "..." || String.IsNullOrWhiteSpace(CarPlate))
            {
                return false;
            };

            if (CarName == "..." || String.IsNullOrWhiteSpace(CarName))
            {
                return false;
            };

            return true;
        }

        private void Cancel()
        {
            _navigationService.NavigateToControl(ControlsRegister.HomeControl);
        }
        #endregion
    }
}
