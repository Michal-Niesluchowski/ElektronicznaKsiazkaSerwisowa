using EKS.FullClient.Services.PageNavaigationService;
using EKS.FullClient.ViewModels;
using Ninject.Modules;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.FullClient.Services.DependencyInjection
{
    internal class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();

            Bind<IPageNavigation>().To<PageNavigation>().InTransientScope();

            Bind<MainWindowViewModel>().ToSelf().InTransientScope();

            Bind<HomePageViewModel>().ToSelf().InTransientScope();

            Bind<NewCarViewModel>().ToSelf().InTransientScope();
        }
    }
}
