using EKS.FullClient.Services.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.FullClient.ViewModels
{
    class BaseViewModel
    {
        public MainWindowViewModel MainWindowViewModel
        {
            get { return IocKernel.Get<MainWindowViewModel>(); }
        }

        public HomePageViewModel HomePageViewModel
        {
            get { return IocKernel.Get<HomePageViewModel>(); }
        }

        public NewCarViewModel NewCarViewModel
        {
            get { return IocKernel.Get<NewCarViewModel>(); }
        }
    }
}
