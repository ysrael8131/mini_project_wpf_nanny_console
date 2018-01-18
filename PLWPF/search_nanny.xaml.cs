using System;
using System.Collections.Generic;
using System.IO;
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
using System.Threading;
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
            bll = new Bl_imp();
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
            //try
            //{
            int floor = int.Parse(floor_textbox.Text);
            int max = int.Parse(coomoBoxMaxChild.SelectedIndex.ToString());
            List<Nanny> findNannies = new List<Nanny>();
            Mother mother = select_mother_combobox.SelectedItem as Mother;
            Child child = select_child_combobox.SelectedItem as Child;
           
            new Thread(() =>
            {
                    // findNannies = bll.rangeNanny(mother.id).ToList();
                    findNannies = allReq(mother, floor, max,child);

                    //if (findNannies == null)
                    //    throw new Exception("ma nishma");
                    Dispatcher.Invoke(new Action(() => { nannyDataGrid.ItemsSource = findNannies; }));
            }).Start();
            //}
            //catch (Exception exception)
            //{
            //    System.Windows.MessageBox.Show(exception.Message);
            //}


        }

        List<Nanny> allReq(Mother mother, int floor, int max,Child child)
        {

            List<Nanny> nanny2 = new List<Nanny>();
            List<Nanny> nanny = new List<Nanny>();
            List<Nanny> nanny1 = new List<Nanny>();
            nanny = bll.rangeNanny(mother.id).ToList();
            nanny1 = bll.requiredMother(mother).ToList();
            if (nanny.Count != 0 && nanny1.Count != 0)
            {
                foreach (var item1 in nanny)
                {
                    foreach (var item2 in nanny1)
                    {
                        if (item1.id == item2.id)
                        {
                            nanny2.Add(item1);
                            //break;
                        }
                    }
                }
                if (nanny2.Count != 0)
                {
                    nanny2 = nanny2.FindAll(item => (item.floor <= floor)
                      && item.maxChilds <= max && ((child.birthDay<DateTime.Now.AddMonths(item.age_child_min)&& child.birthDay > DateTime.Now.AddMonths(item.age_child_max)))

                      );
                }
            }
            return nanny;



        }
    }
}
