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
            Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();

            Bind<MainWindowViewModel>().ToSelf().InTransientScope();

            Bind<HomePageViewModel>().ToSelf().InTransientScope();

            Bind<NewCarViewModel>().ToSelf().InTransientScope();
        }
    }
}
