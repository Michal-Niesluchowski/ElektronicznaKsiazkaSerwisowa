using EKS.FullClient.Framework.Navigation;
using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace EKS.FullClient.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        #region fields
        private UserControl _currentControl;
        #endregion

        #region constructors
        public MainVM(INavigationService navigationService)
        {
            //Subscripe to page navigation service
            navigationService.ControlChange += new EventHandler<UserControl>(UpdateCurrentControl);

            //Use navigation service to go to home control (home page)
            navigationService.NavigateToControl(ControlsRegister.HomeControl);
        }
        #endregion

        #region #region interfaces
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(
            [System.Runtime.CompilerServices.CallerMemberName]
            string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region properties
        public UserControl CurrentControl
        {
            get
            {
                return _currentControl;
            }
            set 
            {
                _currentControl = value;
                OnPropertyChanged(); 
            }
        }
        #endregion

        #region methods
        private void UpdateCurrentControl(object sender, UserControl userControl)
        {
            CurrentControl = userControl;
        }
        #endregion
    }
}
