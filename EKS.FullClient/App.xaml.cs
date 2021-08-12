using EKS.FullClient.Framework.Ioc;
using EKS.FullClient.Views;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace EKS.FullClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //Beware that there is static class 'IocKernel'
            //which provides ioc functionality across application
            IocKernel.Initialize(new IocConfiguration());

            //Set Polish to default language
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pl-PL");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pl-PL");
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(
            XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            base.OnStartup(e);
        }
    }
}
