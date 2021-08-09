using EKS.FullClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.FullClient.Framework.Other
{
    public class BaseViewModel
    {
        public MainWindowViewModel MainWindowViewModel { get; }

        public HomePageViewModel HomePageViewModel { get; }

        public NewCarViewModel NewCarViewModel { get; }
    }
}
