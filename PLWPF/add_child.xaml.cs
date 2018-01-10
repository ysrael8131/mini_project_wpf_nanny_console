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
                child.MotherID = a.id;
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
            //TextBox text = sender as TextBox;

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
            if(idTextBoxMother.Text.Count()!=9)
            {
                errorMesseg5.Visibility = Visibility.Visible;
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

        private void textChange1(object sender, TextChangedEventArgs e)
        {
            errorMesseg4.Visibility = Visibility.Collapsed;
            errorMesseg5.Visibility = Visibility.Collapsed;
            errorMesseg6.Visibility = Visibility.Collapsed;


            long x;
            if (!long.TryParse(idTextBoxMother.Text, out x) && idTextBoxMother.Text != "")
            {

                errorMesseg4.Visibility = Visibility.Visible;

                return;
            }
            if (idTextBoxMother.Text != "" && long.Parse(idTextBoxMother.Text) < 0)
            {
                errorMesseg6.Visibility = Visibility.Visible;
            }


        }

        private void textChnge2(object sender, TextChangedEventArgs e)
        {
            errorMesseg7.Visibility = Visibility.Collapsed;
            long x;
            if(long.TryParse(firstNameTextBox.Text,out x))
            {
                errorMesseg7.Visibility = Visibility.Visible;
            }
        }
    }
}
