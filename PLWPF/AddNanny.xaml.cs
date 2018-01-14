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
using BE;
using Xceed.Wpf.Toolkit;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddNanny.xaml
    /// </summary>
    public partial class AddNanny : Window
    {
        Nanny nanny;
        BL.IBL bl;
        public AddNanny()
        {
            InitializeComponent();
            bl = BL.FactoryBl.getBl();
            nanny = new Nanny();
            
            this.DataContext = nanny;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //System.Windows.Data.CollectionViewSource nannyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("nannyViewSource")));
            //// Load data by setting the CollectionViewSource.Source property:
            //// nannyViewSource.Source = [generic data source]
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            first_grid_nanny.Visibility = Visibility.Collapsed;
            second_grid_nanny.Visibility = Visibility.Visible;
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            first_grid_nanny.Visibility = Visibility.Visible;
            second_grid_nanny.Visibility = Visibility.Collapsed;
        }

        private void add_nanny_button_Click(object sender, RoutedEventArgs e)
        {
            bl.addNanny(nanny);
        }
    }
}
