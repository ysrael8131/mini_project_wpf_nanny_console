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
            
            for (int i = 1; i < 49; i++)
            {
                age_child_minComboBox.Items.Add(i);
                age_child_maxComboBox.Items.Add(i);
            }
             

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
            if (idTextBox.Text.Count() != 9)
            {

                errorMesseg2.Visibility = Visibility.Visible;
                return;
            }
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
            try
            {
                if (idTextBox.Text.Count() != 9)
                {

                    errorMesseg2.Visibility = Visibility.Visible;
                    return;
                }


                List<TimePicker> timeStart = new List<TimePicker>() { start1, startMondayTime, startTuesdayTime, startWednesdayTime, startThursdayTime, startFridayTime };
                List<TimePicker> timeEnd = new List<TimePicker>() { end1, endMondayTime, endTuesdayTime, endWednesdayTime, endThursdayTime, endFridayTime };
                List<CheckBox> check = new List<CheckBox>() { sundayCheckBox, mondayCheckBox, tuesdayCheckBox, wednesdayCheckBox, thursdayCheckBox, fridayCheckBox };
                for (int i = 0; i < 6; i++)
                {
                    //if (check[i].IsChecked == true && (timeStart[i].Value == null || timeEnd[i].Value == null))
                    //{
                        //errorMessegHours.Visibility = Visibility.Visible;
                        //return;
                    //}
                    //if (check[i].IsChecked == true && timeStart[i].Value.Value.TimeOfDay > timeEnd[i].Value.Value.TimeOfDay)
                    //{
                        //errorMessegTime.Visibility = Visibility.Visible;
                        //return;
                    //}
                    if (check[i].IsChecked == true)
                    {
                        nanny.work[i].start = timeStart[i].Value.Value.TimeOfDay;
                        nanny.work[i].end = timeStart[i].Value.Value.TimeOfDay;
                    }
                }

                bl.addNanny(nanny);
                second_grid_nanny.Visibility = Visibility.Collapsed;
                
                //Thread.Sleep(3000);
                // this.Close();
               

            }
            catch (Exception a)
            {

                System.Windows.MessageBox.Show(a.Message);
            }

        }

        private void textChanged(object sender, TextChangedEventArgs e)
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


        private void years_MouseEnter(object sender, MouseEventArgs e)
        {
            ComboBox com = sender as ComboBox;
            com.ToolTip = "choose years";
        }

        private void month_MouseEnter(object sender, MouseEventArgs e)
        {
            ComboBox com = sender as ComboBox;
            com.ToolTip = "choose months";

        }
    }
}
