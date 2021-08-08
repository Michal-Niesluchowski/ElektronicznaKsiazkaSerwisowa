using EKS.FullClient.Services.EventAggregatorService;
using EKS.FullClient.Views;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EKS.FullClient.ViewModels
{
    public class HomePageViewModel 
    {
        #region fields
        private IEventAggregator _eventAggregator;
        #endregion

        #region constructors
        public HomePageViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            this.GoToNewCarPageCommand = new RelayCommand(
                action => GoToNewCarPage());
        }
        #endregion

        #region properites
        public ICommand GoToNewCarPageCommand { get; private set; }
        #endregion

        #region methods
        private void GoToNewCarPage()
        {
            _eventAggregator.GetEvent<PageChangedEvent>().Publish(new NewCarPage());
        }
        #endregion
    }
}
