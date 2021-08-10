using EKS.FullClient.Views;
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
        public event EventHandler<UserControl> ControlChange;

        public void NavigateToControl(ControlsRegister controlName)
        {
            UserControl userControl;
            
            switch (controlName)
            {
                case ControlsRegister.HomeControl:
                    userControl = new HomeControl();
                    break;
                case ControlsRegister.NewCarControl:
                    userControl = new NewCarControl();
                    break;
                case ControlsRegister.CarMainScreenControl:
                    userControl = new CarMainScreenControl();
                    break;
                default:
                    throw new Exception("Control not registered in NavigationService");
            }

            ControlChange?.Invoke(this, userControl);
        }
    }
}
