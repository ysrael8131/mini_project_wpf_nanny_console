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
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for add_child.xaml
    /// </summary>
    public partial class add_child : Window
    {
        BL.IBL bl;
        Child child;

        public add_child(Mother a = null)
        {

            InitializeComponent();
            bl = BL.FactoryBl.getBl();

            child = new Child();
            if (a != null)
            {
                idTextBoxMother.Text = a.id.ToString();
                idTextBoxMother.IsEnabled = false;
            }
            this.DataContext = child;

            //motherIDComBox.ItemsSource = bl.getListMothers().ToArray()[0].id.ToString();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }




        private void textChange(object sender, TextChangedEventArgs e)
        {
            //TextBlock text = sender as TextBlock;

            errorMesseg1.Visibility = Visibility.Collapsed;
            errorMesseg2.Visibility = Visibility.Collapsed;
            errorMesseg3.Visibility = Visibility.Collapsed;

            long x;
            if (!long.TryParse(idTextBox.Text, out x) && idTextBox.Text != "")
            {
                
                errorMesseg1.Visibility = Visibility.Visible;
                return;
            }
            if (idTextBox.Text != "" && long.Parse(idTextBox.Text) < 0 )
            {
                errorMesseg3.Visibility = Visibility.Visible; 
            }



        }

        private void Button_Click_Add_Child(object sender, RoutedEventArgs e)
        {
            if (idTextBox.Text.Count() != 9)
            {
                
                errorMesseg2.Visibility = Visibility.Visible;
                return;
            }
            try
            {
                bl.addChild(child);
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
    }
}
