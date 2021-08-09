using EKS.FullClient.Framework.Ioc;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            IocKernel.Initialize(new IocConfiguration());

            //Beware that there is static class IocKernel
            //which provides ioc functionality across application

            base.OnStartup(e);
        }
    }
}
