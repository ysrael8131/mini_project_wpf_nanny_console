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
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Mother a1 = new Mother();
            a1.id = 123456789;
            a1.FirstName = "sara";
            a1.LastName = "cohen";
            a1.PhoneNumber = "0504145678";
            a1.Addres = "קאסוטו 24 ירושלים ישראל";
            a1.arr[1].day_work = true;
            a1.arr[1].start = TimeSpan.Parse("09:30");
            a1.arr[1].end = TimeSpan.Parse("10:30");
            Mother a2 = new Mother
            {
                id = 111111111,
                FirstName = "efrat",
                LastName = "amzaleg",
                PhoneNumber = "0506134678",
                Addres = "יחזקאל 28 ירושלים ישראל",
                elevators = true,
            };

            for (int i = 0; i < 6; i++)
            {
                a2.arr[i].day_work = true;
                a2.arr[i].start = TimeSpan.Parse("15:30");
                a2.arr[i].end = TimeSpan.Parse("19:30");
            }
            //   bl.addMother(a1);
            bl.addMother(a2);

            Child a3 = new Child();
            a3.id = 999999999;
            a3.MotherID = 111111111;
            a3.birthDay = DateTime.Parse("12.01.2000");
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
            a7.FirstName = "orit";
            a7.LastName = "cakz";
            a7.id = 123123123;
            a7.maxChilds = 3;
            a7.per_hour_able = true;
            a7.salaryPerHour = 34;
            a7.work[3].day_work = true;
            a7.work[3].start = TimeSpan.Parse("06:30");
            a7.work[3].end = TimeSpan.Parse("08:30");
            a7.addres = "קוממיות 10 קריית גת ישראל";
            a7.age_child_min = 10;
            a7.age_child_max = 15;
            a7.floor = 9;
            a7.birthDay = DateTime.Parse("15.03.1999");

            Nanny a8 = new Nanny
            {
                FirstName = "chya",
                LastName = "cakz",
                id = 151515151,
                maxChilds = 5,
                per_hour_able = false,
                salaryPerMonth = 4000,
                PhoneNumber = "527129013",
                floor = 10,
                addres = "אוהב ישראל 3 ביתר עילית ישראל",
                age_child_min = 12,
                age_child_max = 15,
                birthDay = DateTime.Parse("15.03.1999"),
                elevators = true,
                recommendation = "very nice nanny",
                vacation_kind = true,
                years_of_experience = "8",

            };
            for (int i = 0; i < 6; i++)
            {

                a8.work[i].day_work = true;
                a8.work[i].start = TimeSpan.Parse("00:00");
                a8.work[i].end = TimeSpan.Parse("23:00");
            }

            a8.addres = "אוהב ישראל 3 ביתר עילית ישראל";
            a8.age_child_min = 12;
            a8.age_child_max = 15;
            a8.birthDay = DateTime.Parse("15.03.1999");

            Nanny a9 = new Nanny();
            a9.FirstName = "leah";
            a9.LastName = "cakz";
            a9.id = 125837412;
            a9.maxChilds = 5;
            a9.per_hour_able = false;
            a9.salaryPerMonth = 4000;
            for (int i = 0; i < 6; i++)
            {

                a9.work[i].day_work = true;
                a9.work[i].start = TimeSpan.Parse("4:30");
                a9.work[i].end = TimeSpan.Parse("12:30");
            }

            a9.addres = "אילת ישראל";
            a9.age_child_min = 12;
            a9.age_child_max = 15;
            a9.birthDay = DateTime.Parse("15.03.1999");
            a9.floor = 8;



            Nanny a10 = new Nanny();
            a10.FirstName = "rivka";
            a10.LastName = "cakz";
            a10.id = 125837411;
            a10.maxChilds = 7;
            a10.per_hour_able = false;
            a10.salaryPerMonth = 4000;
            for (int i = 0; i < 6; i++)
            {

                a10.work[i].day_work = true;
                a10.work[i].start = TimeSpan.Parse("4:30");
                a10.work[i].end = TimeSpan.Parse("12:30");
            }
            a10.addres = "אילת ישראל";
            a10.age_child_min = 1;
            a10.age_child_max = 10;
            a10.birthDay = DateTime.Parse("15.03.1999");
            a10.floor = 7;

            Nanny a11 = new Nanny();
            a11.FirstName = "ester";
            a11.LastName = "cakz";
            a11.id = 125837415;
            a11.maxChilds = 5;
            a11.per_hour_able = false;
            a11.salaryPerMonth = 4000;
            a11.floor = 8;
            for (int i = 0; i < 6; i++)
            {

                a11.work[i].day_work = true;
                a11.work[i].start = TimeSpan.Parse("4:30");
                a11.work[i].end = TimeSpan.Parse("9:30");
            }

            a11.addres = "אילת ישראל";
            a11.age_child_min = 12;
            a11.age_child_max = 15;
            a11.birthDay = DateTime.Parse("15.03.1999");

            bl.addNanny(a7);
            bl.addNanny(a8);
            bl.addNanny(a9);
            bl.addNanny(a10);
            bl.addNanny(a11);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new add_mother().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new add_child().Show();
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window w = new AddNanny();
                w.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window w = new update();
            w.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window w = new search_nanny();
            w.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //Window w = new GroopingWindow();
            //w.Show();
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
