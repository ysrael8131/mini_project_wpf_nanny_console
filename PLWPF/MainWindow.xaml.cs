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
using BE;
using BL;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BL.IBL bl;
        public MainWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBl.getBl();
            Mother a1= new Mother();
            a1.id = 123456789;
            a1.FirstName = "sara";
            a1.LastName = "cohen";
            a1.PhoneNumber = "0504145678";
            a1.arr[1].day_work = true;
            a1.arr[1].start= TimeSpan.Parse("8:30");
            a1.arr[1].end= TimeSpan.Parse("10:30");

            Mother a2 = new Mother();

            a2.id = 111111111;
            a2.FirstName = "efrat";
            a2.LastName = "amzaleg";
            a2.PhoneNumber = "0506134678";
            a2.arr[2].day_work = true;
            a2.arr[2].start = TimeSpan.Parse("6:30");
            a2.arr[2].end = TimeSpan.Parse("11:30");

            a2.arr[3].day_work = true;
            a2.arr[3].start = TimeSpan.Parse("3:30");
            a2.arr[3].end = TimeSpan.Parse("12:30");

            bl.addMother(a1);
            bl.addMother(a2);

            Child a3 = new Child();
            a3.id = 999999999;
            a3.MotherID = 111111111;
            a3.birthDay=DateTime.Parse("12.01.2000");
            a3.FirstName = "simen";

            Child a4 = new Child();
            
            a4.id = 888888888;
            a4.MotherID = 111111111;
            a4.birthDay = DateTime.Parse("14.02.2011");
            a4.FirstName = "reoven";

            Child a5 = new Child();
            a5.id = 777777777;
            a5.MotherID = 123456789;
            a5.birthDay = DateTime.Parse("26.07.2000");
            a5.FirstName = "levy";

            Child a6 = new Child();

            a6.id = 666666666;
            a6.MotherID = 123456789;
            a6.birthDay = DateTime.Parse("23.02.2014");
            a6.FirstName = "gaya";
            bl.addChild(a3);
            bl.addChild(a4);
            bl.addChild(a5);
            bl.addChild(a6);

            Nanny a7 = new Nanny();
            a7.FirstName="chya";
            a7.LastName = "cakz";
            a7.id = 123123123;
            a7.maxChilds = 3;
            a7.per_hour_able = true;
            a7.salaryPerHour = 34;
            a7.work[3].day_work = true;
            a7.work[3].start = TimeSpan.Parse("6:30");
            a7.work[3].end = TimeSpan.Parse("8:30");
            a7.addres = "asf";
            a7.age_child_min = 10;
            a7.age_child_max = 15;
            a7.birthDay = DateTime.Parse("15.03.1999");

            Nanny a8 = new Nanny();
            a8.FirstName = "chya";
            a8.LastName = "cakz";
            a8.id = 151515151;
            a8.maxChilds = 5;
            a8.per_hour_able = false;
            a8.salaryPerMonth = 4000;
            a8.work[2].day_work = true;
            a8.work[2].start = TimeSpan.Parse("6:30");
            a8.work[2].end = TimeSpan.Parse("8:30");
            a8.addres = "ooopp";
            a8.age_child_min = 12;
            a8.age_child_max = 15;
            a8.birthDay = DateTime.Parse("15.03.1999");


            bl.addNanny(a7);
            bl.addNanny(a8);




        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new add_mother().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new add_child().Show();
        }

        private void Button_Click_remove(object sender, RoutedEventArgs e)
        {
            new Remove(1).Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window w = new AddNanny();
                w.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
         
        }


        //    private void mother_log_in_MouseEnter(object sender, MouseEventArgs e)
        //    {
        //        new_mother_button.Visibility = Visibility.Visible;
        //        update_mother_button.Visibility = Visibility.Visible;
        //    }

        //    private void mother_log_in_MouseLeave(object sender, MouseEventArgs e)
        //    {
        //        new_mother_button.Visibility = Visibility.Collapsed;
        //        update_mother_button.Visibility = Visibility.Collapsed;
        //    }

        //    private void nanny_log_in_MouseEnter(object sender, MouseEventArgs e)
        //    {
        //        // nanny_log_in.Visibility = Visibility.Hidden;
        //        new_nanny_button.Visibility = Visibility.Visible;
        //        update_nanny_button.Visibility = Visibility.Visible;
        //    }

        //    private void nanny_log_in_MouseLeave(object sender, MouseEventArgs e)
        //    {
        //        //  nanny_log_in.Visibility = Visibility.Visible;
        //        new_nanny_button.Visibility = Visibility.Collapsed;
        //        update_nanny_button.Visibility = Visibility.Collapsed;
        //    }

        //    private void new_mother_button_Click(object sender, RoutedEventArgs e)
        //    {
        //        Window add_mother = new add_mother();
        //        add_mother.Show();
        //    }

        //    private void update_mother_button_Click(object sender, RoutedEventArgs e)
        //    {
        //        list_box_mother.Visibility = Visibility.Visible;
        //    }

        //    private void mother_exist_MouseLeave(object sender, MouseEventArgs e)
        //    {
        //        list_box_mother.Visibility = Visibility.Collapsed;
        //    }


        //    private void list_box_mother_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //    {

        //        switch (list_box_mother.SelectedItem.ToString())
        //        {
        //            case "Add child":
        //                new add_child().Show();
        //                break;
        //            case "Remove mother":
        //                break;


        //            case "Update mother":
        //                break;


        //            default:
        //                break;
        //        }

        //    }

        //    private void newNany(object sender, RoutedEventArgs e)
        //    {
        //        new AddNanny().Show();
        //    }
        //}
    }
}
