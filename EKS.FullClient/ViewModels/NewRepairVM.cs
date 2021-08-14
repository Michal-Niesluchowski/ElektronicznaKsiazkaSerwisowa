using EKS.BackEnd.Models;
using EKS.FullClient.Framework;
using EKS.FullClient.Framework.DesignData;
using EKS.FullClient.Framework.Navigation;
using EKS.FullClient.Framework.TempData;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace EKS.FullClient.ViewModels
{
    public class NewRepairVM : INotifyPropertyChanged
    {
        #region fields
        private DateTime _repairDate = DateTime.Today;
        private string _repairDescription = "...";
        private decimal _repairCost = 0;
        private string _repairWorkshopName = "...";
        private INavigationService _navigationService;
        private ITempDataService _tempDataService;
        #endregion

        #region constructors
        //Parameterless constructor used solely for designing in xaml
        public NewRepairVM()
        {
            Repair newRepair = DesignDataService.CreateRepair();
            RepairDescription = newRepair.Description;
            RepairWorkshopName = newRepair.WorkshopName;
        }

        public NewRepairVM(INavigationService navigationService,
                           ITempDataService tempDataService)
        {
            _navigationService = navigationService;
            _tempDataService = tempDataService;

            CancelCommand = new RelayCommand(action => Cancel());
            AddRepairCommand = new RelayCommand(
                action => AddRepair(),
                enable => CanAddCar());
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
        public DateTime RepairDate
        {
            get
            {
                return _repairDate;
            }
            set
            {
                _repairDate = value;
                OnPropertyChanged();
            }
        }
        public string RepairDescription
        {
            get
            {
                return _repairDescription;
            }
            set
            {
                _repairDescription = value;
                OnPropertyChanged();
            }
        }
        public decimal RepairCost
        {
            get
            {
                return _repairCost;
            }
            set
            {
                _repairCost = value;
                OnPropertyChanged();
            }
        }
        public string RepairWorkshopName
        {
            get
            {
                return _repairWorkshopName;
            }
            set
            {
                _repairWorkshopName = value;
                OnPropertyChanged();
            }
        }

        public ICommand CancelCommand { get; private set; }
        public ICommand AddRepairCommand { get; private set; }
        #endregion

        #region methods
        private void Cancel()
        {
            _navigationService.NavigateToControl(ControlsRegister.MainCarControl);
        }

        private void AddRepair()
        {
            Repair newRepair = new Repair(
                RepairDate, RepairDescription, RepairCost, RepairWorkshopName);
            
            Car currentCar = _tempDataService.LoadCar();

            currentCar?.AddRepair(newRepair);

            _navigationService.NavigateToControl(ControlsRegister.MainCarControl);
        }

        private bool CanAddCar()
        {
            //Check Cost
            try
            {
                Convert.ToDecimal(RepairCost);
            }
            catch (Exception)
            {

                return false;
            }

            //Check date
            try
            {
                Convert.ToDateTime(RepairDate);
            }
            catch (Exception)
            {

                return false;
            }

            //Check Workshopname
            if (RepairWorkshopName == "..." || String.IsNullOrWhiteSpace(RepairWorkshopName))
            {
                return false;
            }

            //Check Description
            if (RepairDescription == "..." || String.IsNullOrWhiteSpace(RepairDescription))
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
