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
        public MainVM MainVM
        {
            get { return IocKernel.Get<MainVM>(); }
        }

        public HomeVM HomeVM
        {
            get { return IocKernel.Get<HomeVM>(); }
        }

        public NewCarVM NewCarVM
        {
            get { return IocKernel.Get<NewCarVM>(); }
        }

        public MainCarVM MainCarVM
        {
            get { return IocKernel.Get<MainCarVM>(); }
        }

        public NewRepairVM NewRepairVM
        {
            get { return IocKernel.Get<NewRepairVM>(); }
        }

        public EditCarVM EditCarVM
        {
            get { return IocKernel.Get<EditCarVM>(); }
        }

        public EditRepairVM EditRepairVM
        {
            get { return IocKernel.Get<EditRepairVM>(); }
        }
    }
}
