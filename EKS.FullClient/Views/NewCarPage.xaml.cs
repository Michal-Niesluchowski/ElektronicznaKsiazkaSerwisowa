using EKS.FullClient.Services.EventAggregatorService;
using EKS.FullClient.ViewModels;
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
    /// Interaction logic for NewCarPage.xaml
    /// </summary>
    public partial class NewCarPage : Page
    {
        private NewCarViewModel _viewModel;

        public NewCarPage()
        {
            InitializeComponent();

            _viewModel = new NewCarViewModel(EventAggregatorService.GetInstance);

            DataContext = _viewModel;
        }
    }
}
