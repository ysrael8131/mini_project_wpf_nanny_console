
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
         
            // arrListView.DataContext = mother.arr;



            string[] str = new string[] { "050", "052", "053", "054", "055", "058" };
            //  comboBoxPhone.ItemsSource = str;



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









        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            try
            {
                List<TimePicker> timeStart = new List<TimePicker>() { start1, startMondayTime, startTuesdayTime, startWednesdayTime, startThursdayTime, startFridayTime };
                List<TimePicker> timeEnd = new List<TimePicker>() { end1, endMondayTime, endTuesdayTime, endWednesdayTime, endThursdayTime, endFridayTime };
                List<CheckBox> check = new List<CheckBox>() { sundayCheckBox, mondayCheckBox, tuesdayCheckBox, wednesdayCheckBox, thursdayCheckBox, fridayCheckBox };
                for (int i = 0; i < 6; i++)
                {
                    if(check[i].IsChecked==true)
                    {
                        mother.arr[i].start = timeStart[i].Value.Value.TimeOfDay;
                        mother.arr[i].end = timeEnd[i].Value.Value.TimeOfDay;
                    }
                }

                bl.addMother(mother);
                System.Windows.MessageBox.Show(mother.FirstName + " " + mother.LastName + " Successfully added");
                this.Close();
                new add_child().Show();

            }
            catch (Exception a)
            {

                System.Windows.MessageBox.Show(a.Message);
            }

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }


}





