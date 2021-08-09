using EKS.FullClient.Framework.Navigation;
using EKS.FullClient.Framework.TempData;
using EKS.FullClient.ViewModels;
using Ninject.Modules;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.FullClient.Framework.Ioc
{
    internal class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            //Services
            Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            Bind<INavigationService>().To<NavigationService>().InSingletonScope();
            Bind<ITempDataService>().To<TempDataService>().InSingletonScope();

            //View models
            Bind<MainWindowViewModel>().ToSelf().InTransientScope();
            Bind<HomeViewModel>().ToSelf().InTransientScope();
            Bind<NewCarViewModel>().ToSelf().InTransientScope();
            Bind<CarMainScreenViewModel>().ToSelf().InTransientScope();
        }
    }
}
