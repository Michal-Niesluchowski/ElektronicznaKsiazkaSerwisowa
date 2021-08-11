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
        public MainWindowVM MainWindowViewModel
        {
            get { return IocKernel.Get<MainWindowVM>(); }
        }

        public HomeControlVM HomePageViewModel
        {
            get { return IocKernel.Get<HomeControlVM>(); }
        }

        public NewCarControlVM NewCarViewModel
        {
            get { return IocKernel.Get<NewCarControlVM>(); }
        }

        public CarMainScreenControlVM CarMainScreenViewModel
        {
            get { return IocKernel.Get<CarMainScreenControlVM>(); }
        }
    }
}
