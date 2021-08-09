using EKS.FullClient.Framework.Ioc;
using EKS.FullClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.FullClient.Framework
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel
        {
            get { return IocKernel.Get<MainWindowViewModel>(); }
        }

        public HomeViewModel HomePageViewModel
        {
            get { return IocKernel.Get<HomeViewModel>(); }
        }

        public NewCarViewModel NewCarViewModel
        {
            get { return IocKernel.Get<NewCarViewModel>(); }
        }

        public CarMainScreenViewModel CarMainScreenViewModel
        {
            get { return IocKernel.Get<CarMainScreenViewModel>(); }
        }
    }
}
