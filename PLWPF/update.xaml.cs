using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PLWPF
{


   
    /// <summary>
    /// Interaction logic for update.xaml
    /// </summary>
    public partial class update : Window
    {

     //   private  ObservableCollection<BE.Mother> ff = new ObservableCollection<BE.Mother>();
        BL.IBL bl;
        public update()
        {

           
            bl = BL.FactoryBl.getBl();

            InitializeComponent();

            BE.Mother mother = new BE.Mother();
            BE.Child child = new BE.Child();
            BE.Nanny nanny = new BE.Nanny();
            List<string> lst = new List<string>
            {
                "Mother",
                "Child",
                "Nanny"
            };
            select_item_combobox.ItemsSource = lst;
            var mothers = from item in bl.getListMothers()
                          select item.id;
            select_mother_conbobox.ItemsSource = mothers;

        }

        private void select_item_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            select_mother_conbobox.ItemsSource = null;
            select_child_conbobox.ItemsSource = null;
            select_nanny_conbobox.ItemsSource = null;

            switch (select_item_combobox.SelectedItem.ToString())
            {
                case "Mother":
                    mother_stackpanel.Visibility = Visibility.Visible;
                    child_stackpanel.Visibility = Visibility.Collapsed;
                    nanny_stackpanel.Visibility = Visibility.Collapsed;

                    first_grid_mother.Visibility = Visibility.Collapsed;
                    child_grid.Visibility = Visibility.Collapsed;
                    first_grid_nanny.Visibility = Visibility.Collapsed;

                    var mothers = from item in bl.getListMothers()
                                  select item.id;

                    select_mother_conbobox.ItemsSource = mothers;
                    break;
                case "Child":
                    mother_stackpanel.Visibility = Visibility.Visible;
                    child_stackpanel.Visibility = Visibility.Visible;
                    nanny_stackpanel.Visibility = Visibility.Collapsed;

                    mothers = from item in bl.getListMothers()
                              select item.id;
                    select_mother_conbobox.ItemsSource = mothers;


                    child_grid.Visibility = Visibility.Collapsed;
                    first_grid_mother.Visibility = Visibility.Collapsed;
                    first_grid_nanny.Visibility = Visibility.Collapsed;

                    break;
                case "Nanny":
                    nanny_stackpanel.Visibility = Visibility.Visible;
                    child_stackpanel.Visibility = Visibility.Collapsed;
                    mother_stackpanel.Visibility = Visibility.Collapsed;

                    first_grid_mother.Visibility = Visibility.Collapsed;
                    child_grid.Visibility = Visibility.Collapsed;
                    first_grid_nanny.Visibility = Visibility.Collapsed;

                    var nannys = from item in bl.getListNannys()
                                 select item.id;
                   // select_nanny_conbobox.ItemsSource = null;
                    select_nanny_conbobox.ItemsSource = nannys;
                    break;
                default:
                    break;
            }
        }

        private void select_mother_conbobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (select_mother_conbobox.ItemsSource != null)
            {
                switch (select_item_combobox.SelectedItem.ToString())
                {
                    case "Mother":
                        if (select_mother_conbobox.SelectedItem != null)
                        {
                            first_grid_mother.DataContext = bl.getMother(int.Parse(select_mother_conbobox.SelectedItem.ToString()));
                            first_grid_mother.Visibility = Visibility.Visible;
                        }
                            

                        

                        break;
                    case "Child":
                        var childs = from item in bl.getListChilds(bl.getMother(int.Parse(select_mother_conbobox.SelectedItem.ToString())))
                                     select item.id;
                        select_child_conbobox.ItemsSource = null;
                        select_child_conbobox.ItemsSource = childs;
                        break;
                    default:
                        break;
                }
            }
        }

        private void select_child_conbobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (select_mother_conbobox.ItemsSource!=null)
            {
                child_grid.DataContext = bl.getChild(int.Parse(select_child_conbobox.SelectedItem.ToString()));

            }
            child_grid.Visibility = Visibility.Visible;
            first_grid_mother.Visibility = Visibility.Collapsed;
        }



        private void select_nanny_conbobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            first_grid_nanny.Visibility = Visibility.Visible;
            first_grid_mother.Visibility = Visibility.Collapsed;
            child_grid.Visibility = Visibility.Collapsed;
        }



        private void delete_mother_button_Click(object sender, RoutedEventArgs e)
        {
            bl.deleteMother(int.Parse(select_mother_conbobox.SelectedItem.ToString()));
            select_mother_conbobox.SelectedItem = null;
            first_grid_mother.Visibility = Visibility.Collapsed;
            select_mother_conbobox.ItemsSource = null;

        }






        private void SizeStart1(object sender, SizeChangedEventArgs e)
        {
            errorMessegHours.Visibility = Visibility.Collapsed;
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
            if (idTextBox.Text != "" && long.Parse(idTextBox.Text) < 0)
            {
                errorMesseg3.Visibility = Visibility.Visible;
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
            if (long.TryParse(firstNameTextBox.Text, out x))
            {
                errorMesseg7.Visibility = Visibility.Visible;
            }
        }

     



        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            first_grid_nanny.Visibility = Visibility.Collapsed;
           // second_grid_nanny.Visibility = Visibility.Visible;
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            first_grid_nanny.Visibility = Visibility.Visible;
         //   second_grid_nanny.Visibility = Visibility.Collapsed;
        }

       
    }
}