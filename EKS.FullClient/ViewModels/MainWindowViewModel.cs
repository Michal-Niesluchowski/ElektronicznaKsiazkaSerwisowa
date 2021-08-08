using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;
using EKS.FullClient.Views;
using Prism.Events;
using EKS.FullClient.Services.EventAggregatorService;
using EKS.FullClient.Services.PageNavaigationService;

namespace EKS.FullClient.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region fields
        private Page _selectedPage;
        #endregion

        #region constructors
        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            _selectedPage = new HomePage();
            eventAggregator.GetEvent<PageChangedEvent>().Subscribe(ChangePage);
        }

        private void ChangePage(Page newPage)
        {
            SelectedPage = newPage;
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
        public Page SelectedPage
        {
            get
            {
                return _selectedPage;
            }
            set 
            {
                _selectedPage = value;
                OnPropertyChanged(); 
            }
        }
        #endregion
    }
}
