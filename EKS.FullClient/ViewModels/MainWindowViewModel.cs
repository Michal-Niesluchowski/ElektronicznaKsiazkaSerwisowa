using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;
using EKS.FullClient.Framework.Navigation;

namespace EKS.FullClient.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region fields
        private UserControl _currentControl;
        #endregion

        #region constructors
        public MainWindowViewModel(INavigationService navigationService)
        {
            navigationService.ControlChange += new EventHandler<UserControl>(UpdateCurrentControl);
            navigationService.NavigateToControl(ControlsRegister.HomeControl);
            //navigationService.NavigateToControl(ControlsRegister.CarMainScreenControl);
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
