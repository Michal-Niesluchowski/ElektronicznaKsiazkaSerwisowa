using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.FullClient.Framework.Navigation
{
    public interface INavigationService
    {   
        void NavigateToControl(ControlsRegister controlName);
    }
}
