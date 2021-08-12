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
            CurrentCar = DesignDataService.CreateCarWithRepairs();
        }

        public CarMainScreenControlVM(INavigationService navigationService, ITempDataService tempDataService)
        {
            _navigationService = navigationService;
            _tempDataService = tempDataService;

            //CurrentCar = _tempDataService.LoadCar();
            CurrentCar = DesignDataService.CreateCarWithRepairs();

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
