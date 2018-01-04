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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Remove.xaml
    /// </summary>
    public partial class Remove : Window
    {
        BL.IBL bl;
        public Remove(int choice)
        {
            InitializeComponent();
            bl = BL.FactoryBl.getBl();

        }
       
        private void Remove_Click(object sender, RoutedEventArgs e)
        {

            //switch (choice)
            //{
            //    case 1:

            //        bl.deleteMother(int.Parse(remove_textbox.Text));
            //    default:
            //        break;
            //}
        }
    }
}
