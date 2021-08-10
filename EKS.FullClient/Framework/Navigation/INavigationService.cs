using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EKS.FullClient.Framework.Navigation
{
    public interface INavigationService
    {
        event EventHandler<UserControl> ControlChange;

        void NavigateToControl(ControlsRegister controlName);
    }
}
