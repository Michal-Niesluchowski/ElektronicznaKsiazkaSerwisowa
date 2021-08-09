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

namespace EKS.FullClient.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region fields
        private Page _currentPage = new HomePage();
        #endregion

        #region constructors
        public MainWindowViewModel(IEventAggregator eventAggregator, Page homePage)
        {
            CurrentPage = homePage;
            eventAggregator.GetEvent<PageChangedEvent>().Subscribe(UpdateCurrentPage);
        }

        private void UpdateCurrentPage(Page newPage)
        {
            CurrentPage = newPage;
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
        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set 
            {
                _currentPage = value;
                OnPropertyChanged(); 
            }
        }
        #endregion
    }
}
