using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;
using Prism.Events;
using EKS.FullClient.Framework.Events;
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
        public MainWindowViewModel(IEventAggregator eventAggregator, INavigationService navigationService)
        {
            eventAggregator.GetEvent<ControlChangedEvent>().Subscribe(UpdateCurrentControl);
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
        private void UpdateCurrentControl(UserControl newControl)
        {
            CurrentControl = newControl;
        }
        #endregion
    }
}
