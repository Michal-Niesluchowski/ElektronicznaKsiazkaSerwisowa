using EKS.BackEnd.Models;
using EKS.FullClient.Framework;
using EKS.FullClient.Framework.Navigation;
using EKS.FullClient.Framework.TempData;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace EKS.FullClient.ViewModels
{
    public class EditRepairVM
    {
        #region fields
        private DateTime _repairDate ;
        private string _repairDescription;
        private decimal _repairCost;
        private string _repairWorkshopName;
        private INavigationService _navigationService;
        private ITempDataService _tempDataService;
        #endregion

        #region constructors
        public EditRepairVM(INavigationService navigationService,
                           ITempDataService tempDataService)
        {
            _navigationService = navigationService;
            _tempDataService = tempDataService;

            Repair repair = _tempDataService.LoadRepair();
            RepairCost = repair.Cost;
            RepairDate = repair.Date;
            RepairDescription = repair.Description;
            RepairWorkshopName = repair.WorkshopName;

            CancelCommand = new RelayCommand(action => Cancel());
            EditRepairCommand = new RelayCommand(
                action => EditRepair(),
                enable => CanEditRepair());
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
        public ICommand EditRepairCommand { get; private set; }
        #endregion

        #region methods
        private void Cancel()
        {
            _navigationService.NavigateToControl(ControlsRegister.MainCarControl);
            _tempDataService.ClearRepair();
        }

        private void EditRepair()
        {
            //Get reference to repair for editing
            Guid selectedRepairId = _tempDataService.LoadRepair().Id;
            Car currentCar = _tempDataService.LoadCar();
            Repair selectedRepair = currentCar.Repairs.Where(r => r.Id == selectedRepairId).FirstOrDefault();

            //Edit repair
            selectedRepair?.EditRepair(RepairDate, RepairDescription, RepairCost, RepairWorkshopName);

            //Finalize
            _tempDataService.ClearRepair();
            _navigationService.NavigateToControl(ControlsRegister.MainCarControl);
        }

        private bool CanEditRepair()
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
