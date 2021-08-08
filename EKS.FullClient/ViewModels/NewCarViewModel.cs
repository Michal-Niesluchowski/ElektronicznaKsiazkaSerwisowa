using EKS.FullClient.Services.EventAggregatorService;
using EKS.FullClient.Views;
using EKS.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EKS.FullClient.ViewModels
{
    public class NewCarViewModel : INotifyPropertyChanged
    {
        #region fields
        private string _carName = "...";
        private string _carPlate = "...";
        private string _carDescription = "...";
        IEventAggregator _eventAggregator;
        #endregion

        #region constructors
        public NewCarViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

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

        public string CarDescription
        {
            get { return _carDescription; }
            set { _carDescription = value; }
        }

        public ICommand NewCarCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }
        #endregion

        #region methods
        private void CreateNewCar()
        {
            Car newCar = new Car(CarName, CarPlate, CarDescription);
            _eventAggregator.GetEvent<NewCarEvent>().Publish(newCar);
            MessageBox.Show(newCar.ToString());
        }

        private bool CanCreateNewCar()
        {
            if (CarPlate == "..." || String.IsNullOrWhiteSpace(CarPlate))
            {
                return false;
            };

            if (CarName == "..." || String.IsNullOrWhiteSpace(CarPlate))
            {
                return false;
            };

            if (CarDescription == "..." || String.IsNullOrWhiteSpace(CarPlate))
            {
                return false;
            };

            return true;
        }

        private void Cancel()
        {
            _eventAggregator.GetEvent<PageChangedEvent>().Publish(new HomePage());
        }
        #endregion
    }
}
