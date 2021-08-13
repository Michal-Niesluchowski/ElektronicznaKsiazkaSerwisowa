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
        public MainVM MainWindowViewModel
        {
            get { return IocKernel.Get<MainVM>(); }
        }

        public HomeVM HomePageViewModel
        {
            get { return IocKernel.Get<HomeVM>(); }
        }

        public NewCarVM NewCarViewModel
        {
            get { return IocKernel.Get<NewCarVM>(); }
        }

        public MainCarVM CarMainScreenViewModel
        {
            get { return IocKernel.Get<MainCarVM>(); }
        }
    }
}
