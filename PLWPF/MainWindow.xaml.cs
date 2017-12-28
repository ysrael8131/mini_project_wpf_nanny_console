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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void mother_log_in_MouseEnter(object sender, MouseEventArgs e)
        {
            new_mother_button.Visibility = Visibility.Visible;
            update_mother_button.Visibility = Visibility.Visible;
        }

        private void mother_log_in_MouseLeave(object sender, MouseEventArgs e)
        {
            new_mother_button.Visibility = Visibility.Collapsed;
            update_mother_button.Visibility = Visibility.Collapsed;
        }

        private void nanny_log_in_MouseEnter(object sender, MouseEventArgs e)
        {
           // nanny_log_in.Visibility = Visibility.Hidden;
            new_nanny_button.Visibility = Visibility.Visible;
            update_nanny_button.Visibility = Visibility.Visible;
        }

        private void nanny_log_in_MouseLeave(object sender, MouseEventArgs e)
        {
          //  nanny_log_in.Visibility = Visibility.Visible;
            new_nanny_button.Visibility = Visibility.Collapsed;
            update_nanny_button.Visibility = Visibility.Collapsed;
        }

        private void new_mother_button_Click(object sender, RoutedEventArgs e)
        {
            Window add_mother = new add_mother();
            add_mother.Show();
        }

        
    }
}
