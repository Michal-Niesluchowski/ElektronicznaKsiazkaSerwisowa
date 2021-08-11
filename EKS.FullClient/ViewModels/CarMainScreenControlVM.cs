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
    public class CarMainScreenControlVM : INotifyPropertyChanged
    {
        #region fields
        private Car _currentCar;
        private INavigationService _navigationService;
        private ITempDataService _tempDataService;
        #endregion

        #region constructors
        //ONLY FOR DESIGN TIME
        public CarMainScreenControlVM()
        {
            Car newTestCar = new Car("Renault Clio", "WH 34822");
            newTestCar.AddRepair(new DateTime(2021, 5, 20), "Wymiana oleju", "Olej Castrol 5w30, filtr oleju, płukanka",
                500, "Marcin Głowice");
            newTestCar.AddRepair(new DateTime(2021, 6, 19), "Naprawa klimatyzacji", "Wymiana sprężarki na regenerowaną",
                1200, "Magic Mechanik");
            newTestCar.AddRepair(new DateTime(2021, 7, 29), "Pierdolety", "Wymiana paska alternatowa + filtr paliwa",
                100, "Marcin Głowice");
            this.CurrentCar = newTestCar;
        }

        public CarMainScreenControlVM(INavigationService navigationService, ITempDataService tempDataService)
        {
            _navigationService = navigationService;
            _tempDataService = tempDataService;

            CurrentCar = _tempDataService.LoadCar();

            this.BackToMenuCommand = new RelayCommand(
                action => GoToMenu());
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
        #endregion

        #region methods
        private void GoToMenu()
        {
            _navigationService.NavigateToControl(ControlsRegister.HomeControl);
        }
        #endregion
    }
}
