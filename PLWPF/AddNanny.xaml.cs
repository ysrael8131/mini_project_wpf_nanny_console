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

        private void add_nanny_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<TimePicker> timeStart = new List<TimePicker>() { start1, startMondayTime, startTuesdayTime, startWednesdayTime, startThursdayTime, startFridayTime };
                List<TimePicker> timeEnd = new List<TimePicker>() { end1, endMondayTime, endTuesdayTime, endWednesdayTime, endThursdayTime, endFridayTime };
                List<CheckBox> check = new List<CheckBox>() { sundayCheckBox, mondayCheckBox, tuesdayCheckBox, wednesdayCheckBox, thursdayCheckBox, fridayCheckBox };
                for (int i = 0; i < 6; i++)
                {
                    if (check[i].IsChecked == true)
                    {
                        nanny.work[i].start = timeStart[i].Value.Value.TimeOfDay;
                        nanny.work[i].end = timeEnd[i].Value.Value.TimeOfDay;
                    }
                }

                bl.addNanny(nanny);
                System.Windows.MessageBox.Show(nanny.FirstName + " " + nanny.LastName + " Successfully added");
                this.Close();
            }
            catch (Exception a)
            {

                System.Windows.MessageBox.Show(a.Message);
            }


        }
    }
}
