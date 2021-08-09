using EKS.FullClient.Services.EventAggregatorService;
using EKS.FullClient.ViewModels;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EKS.FullClient.Views
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private HomePageViewModel _viewModel;
        
        public HomePage()
        {
            InitializeComponent();

            _viewModel = new HomePageViewModel(EventAggregatorService.GetInstance);

            DataContext = _viewModel;
        }
    }
}
