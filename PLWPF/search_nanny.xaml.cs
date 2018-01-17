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
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for search_nanny.xaml
    /// </summary>
    public partial class search_nanny : Window
    {
        BL.IBL bl;
        private BL.Bl_imp bll;

        public search_nanny()
        {
            bl = BL.FactoryBl.getBl();
            bll=new Bl_imp();
            InitializeComponent();
            select_mother_combobox.ItemsSource = bl.getListMothers();
          //  nannyDataGrid.ItemsSource = bl.getListNannys();
            
        }

        private void select_mother_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            select_child_combobox.ItemsSource = bl.getListChilds(select_mother_combobox.SelectedItem as Mother);
            Constraints.DataContext = select_mother_combobox.SelectedItem as Mother;
        }

        private void select_child_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

      

        private void nannyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource nannyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("nannyViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // nannyViewSource.Source = [generic data source]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            nannyDataGrid.ItemsSource = bll.rangeNanny((select_mother_combobox.SelectedItem as Mother).id);
        }
    }
}
