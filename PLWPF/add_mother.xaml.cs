using BE;
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
using BL;
using Xceed.Wpf.Toolkit;

using System.Threading;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for add_mother.xaml
    /// </summary>
    public partial class add_mother : Window
    {
        BE.Mother mother;
        BL.IBL bl;
        public add_mother()
        {

            InitializeComponent();
            bl = FactoryBl.getBl();
            mother = new Mother();
            DataContext = mother;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //System.Windows.Data.CollectionViewSource motherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("motherViewSource")));
            //Load data by setting the CollectionViewSource.Source property:
            // motherViewSource.Source = [generic data source]
            //System.Windows.Data.CollectionViewSource motherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("motherViewSource")));
            //Load data by setting the CollectionViewSource.Source property:
            // motherViewSource.Source = [generic data source]
        }

        //private void textChange(object sender, TextChangedEventArgs e)
        //{
        //    if (phoneNumberTextBox.ToString() != "")
        //   //     mother.PhoneNumber = comboBoxPhone.SelectedItem.ToString() + phoneNumberTextBox.ToString();
        //}











        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            first_grid_mother.Visibility = Visibility.Collapsed;
            second_grid_mother.Visibility = Visibility.Visible;
        }


        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            first_grid_mother.Visibility = Visibility.Visible;
            second_grid_mother.Visibility = Visibility.Collapsed;
        }

        private void Button_create_Click(object sender, RoutedEventArgs e)
        {


            try
            {


                if (idTextBox.Text.Count() != 9)
                {
                    errorMesseg2.Visibility = Visibility.Visible;
                }
                List<TimePicker> timeStart = new List<TimePicker>() { start1, startMondayTime, startTuesdayTime, startWednesdayTime, startThursdayTime, startFridayTime };
                List<TimePicker> timeEnd = new List<TimePicker>() { end1, endMondayTime, endTuesdayTime, endWednesdayTime, endThursdayTime, endFridayTime };
                List<CheckBox> check = new List<CheckBox>() { sundayCheckBox, mondayCheckBox, tuesdayCheckBox, wednesdayCheckBox, thursdayCheckBox, fridayCheckBox };
                for (int i = 0; i < 6; i++)
                {
                    if (check[i].IsChecked == true && (timeStart[i].Value == null || timeEnd[i].Value == null))
                    {
                        errorMessegHours.Visibility = Visibility.Visible;
                        return;
                    }
                    if(check[i].IsChecked == true && timeStart[i].Value.Value.TimeOfDay> timeEnd[i].Value.Value.TimeOfDay)
                    {
                        errorMessegTime.Visibility = Visibility.Visible;
                        return;
                    }
                    if (check[i].IsChecked == true)
                    {
                        mother.arr[i].start = timeStart[i].Value.Value.TimeOfDay;
                        mother.arr[i].end = timeStart[i].Value.Value.TimeOfDay;
                    }
                }

                bl.addMother(mother);
                second_grid_mother.Visibility = Visibility.Collapsed;
                third_grid_mother.Visibility = Visibility.Visible;
                //Thread.Sleep(3000);
                // this.Close();
                new add_child(mother).Show();

            }
            catch (Exception a)
            {

                System.Windows.MessageBox.Show(a.Message);
            }

        }

        private void SizeStart1(object sender, SizeChangedEventArgs e)
        {
            errorMessegHours.Visibility = Visibility.Collapsed;
        }

        private void textChanged1(object sender, TextChangedEventArgs e)
        {
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
    }   


}





