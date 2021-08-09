using EKS.FullClient.Framework.Ioc;
using EKS.FullClient.ViewModels;
using EKS.FullClient.Views;
using Ninject;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EKS.FullClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel _iocKernel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _iocKernel = new StandardKernel();

            _iocKernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            _iocKernel.Bind<MainWindowViewModel>().ToSelf().InTransientScope();
            _iocKernel.Bind<HomePageViewModel>().ToSelf().InTransientScope();
            _iocKernel.Bind<NewCarViewModel>().ToSelf().InTransientScope();

            Current.MainWindow = _iocKernel.Get<MainWindow>();
            Current.MainWindow.Show();
        }
    }
}
