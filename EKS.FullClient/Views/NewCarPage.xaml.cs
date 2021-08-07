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
        NewCarViewModel viewModel;
        
        public NewCarPage()
        {
            InitializeComponent();

            this.viewModel = new NewCarViewModel();
            this.DataContext = this.viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage newPage = new HomePage();
            NavigationService.Navigate(newPage);
        }
    }
}
