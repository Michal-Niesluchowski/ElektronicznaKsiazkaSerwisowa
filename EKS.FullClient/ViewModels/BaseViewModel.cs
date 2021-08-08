using EKS.FullClient.Services.DependencyInjection;
using EKS.FullClient.Services.PageNavaigationService;
using EKS.FullClient.ViewModels;
using EKS.FullClient.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EKS.FullClient.ViewModels
{
    public class BaseViewModel 
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
