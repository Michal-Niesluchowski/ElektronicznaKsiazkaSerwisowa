using EKS.FullClient.Framework.Events;
using EKS.FullClient.Views;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EKS.FullClient.Framework.Navigation
{
    public class NavigationService : INavigationService
    {
        private IEventAggregator _eventAggregator;
        
        public NavigationService(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
        
        public void NavigateToControl(ControlsRegister controlName)
        {
            switch (controlName)
            {
                case ControlsRegister.HomeControl:
                    _eventAggregator.GetEvent<ControlChangedEvent>().Publish(new HomeControl());
                    break;
                case ControlsRegister.NewCarControl:
                    _eventAggregator.GetEvent<ControlChangedEvent>().Publish(new NewCarControl());
                    break;
                case ControlsRegister.CarMainScreenControl:
                    _eventAggregator.GetEvent<ControlChangedEvent>().Publish(new CarMainScreenControl());
                    break;
                default:
                    throw new Exception("Control not registered in NavigationService");
            }
        }
    }
}
