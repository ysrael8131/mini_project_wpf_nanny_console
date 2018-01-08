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


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Remove.xaml
    /// </summary>
    public partial class Remove : Window
    {
        private int choice;
        BL.IBL bl;
        public Remove(int numChoice)
        {
            InitializeComponent();
            if (numChoice == 4)
            {
                TextId.Visibility = Visibility.Collapsed;
                TextContract.Visibility = Visibility.Visible;
            }
            bl = FactoryBl.getBl();
            choice = numChoice;
        }

        private void Button_Click_Remove(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(RemoveElement.Text);
            switch (choice)
            {
                //delete Mother
                case 1:
                    bl.deleteMother(id);
                    break;
                //delete Nanny
                case 2:
                    bl.deleteNanny(id);
                    break;
                //delete Child
                case 3:
                    bl.deleteChild(id);
                    break;
                //delete Contract
                case 4:
                    bl.deleteContract(id);
                    break;
                default:
                    break;
            }
        }

       
    }
}
