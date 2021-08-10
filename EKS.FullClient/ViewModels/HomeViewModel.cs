using EKS.FullClient.Framework;
using EKS.FullClient.Framework.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EKS.FullClient.ViewModels
{
    public class HomeViewModel 
    {
        #region fields
        private INavigationService _navigationService;
        #endregion

        #region constructors
        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            this.GoToNewCarControlCommand = new RelayCommand(
                action => GoToNewCarControl());
        }
        #endregion

        #region properites
        public ICommand GoToNewCarControlCommand { get; private set; }
        #endregion

        #region methods
        private void GoToNewCarControl()
        {
            _navigationService.NavigateToControl(ControlsRegister.NewCarControl);
        }
        #endregion
    }
}
