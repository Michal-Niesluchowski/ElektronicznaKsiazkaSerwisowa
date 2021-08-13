using EKS.FullClient.Framework.Navigation;
using EKS.FullClient.Framework.TempData;
using EKS.FullClient.ViewModels;
using Ninject.Modules;
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
            Bind<INavigationService>().To<NavigationService>().InSingletonScope();
            Bind<ITempDataService>().To<TempDataService>().InSingletonScope();

            //View models
            Bind<MainVM>().ToSelf().InTransientScope();
            Bind<HomeVM>().ToSelf().InTransientScope();
            Bind<NewCarVM>().ToSelf().InTransientScope();
            Bind<MainCarVM>().ToSelf().InTransientScope();
            Bind<NewRepairVM>().ToSelf().InTransientScope();
        }
    }
}
