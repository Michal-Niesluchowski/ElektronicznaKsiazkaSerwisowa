using EKS.BackEnd.Models;
using EKS.FullClient.Framework;
using EKS.FullClient.Framework.Navigation;
using EKS.FullClient.Framework.TempData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EKS.FullClient.ViewModels
{
    public class EditCarVM : INotifyPropertyChanged
    {
        #region fields
        private string _carName = "...";
        private string _carPlate = "...";
        private INavigationService _navigationService;
        private ITempDataService _tempDataService;
        #endregion

        #region constructors
        public EditCarVM(INavigationService navigationService, ITempDataService tempDataService)
        {
            _navigationService = navigationService;
            _tempDataService = tempDataService;

            Car currentCar = _tempDataService.LoadCar();
            CarName = currentCar.Name;
            CarPlate = currentCar.Plate;

            this.SaveCarCommand = new RelayCommand(
                action => SaveCar(),
                enable => CanSaveCar()); ;

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

        public ICommand SaveCarCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        #endregion

        #region methods
        private void SaveCar()
        {
            Car currentCar = _tempDataService.LoadCar();
            currentCar.EditCar(CarName, CarPlate);

            _navigationService.NavigateToControl(ControlsRegister.MainCarControl);
        }

        private bool CanSaveCar()
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
            _navigationService.NavigateToControl(ControlsRegister.MainCarControl);
        }
        #endregion
    }
}
