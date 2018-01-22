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
        private Mother selectedMother;
        private Child selectedChild;
        private Nanny selectedNanny;
        private Contract selectedContract;
        public search_nanny()
        {
            bl = BL.FactoryBl.getBl();
            bll = new Bl_imp();
            selectedMother = new Mother();
            selectedChild = new Child();
            selectedNanny = new Nanny();
            selectedContract = new Contract();
            InitializeComponent();
            select_mother_combobox.ItemsSource = bl.getListMothers();
            //  nannyDataGrid.ItemsSource = bl.getListNannys();

        }

        private void select_mother_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedMother = select_mother_combobox.SelectedItem as Mother;
            select_child_combobox.ItemsSource = bl.getListChilds(select_mother_combobox.SelectedItem as Mother);
            Constraints_grid.DataContext = select_mother_combobox.SelectedItem as Mother;
        }

        private void select_child_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedChild = select_child_combobox.SelectedItem as Child;
        }



        private void nannyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedNanny = nannyDataGrid.SelectedItem as Nanny;
        }
        private void select_nanny_button_Click(object sender, RoutedEventArgs e)
        {
            selectedContract.MotherID = selectedMother.id;
            selectedContract.childID = selectedChild.id;
            selectedContract.NannyID = selectedNanny.id;
            selectedContract.ContracPer = selectedNanny.per_hour_able;
            selectedContract.salaryPerHour = selectedNanny.salaryPerHour;
            selectedContract.salaryPerMonth = selectedNanny.salaryPerMonth;
            add_contruct_grid.DataContext = selectedContract;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource nannyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("nannyViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // nannyViewSource.Source = [generic data source]
        }

        private void search_nannys_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int floor = int.Parse(floor_textbox.Text);
                int max = int.Parse(coomoBoxMaxChild.SelectedIndex.ToString());
                List<Nanny> findNannies = new List<Nanny>();
                search_nannys_button.IsEnabled = false;
                vizibilityes();
                loading.Visibility = Visibility.Visible;
                new Thread(() =>
                {

                // findNannies = bll.rangeNanny(mother.id).ToList();
                try
                    {
                        findNannies = allReq(selectedMother, floor, max, selectedChild);

                    }
                    catch (Exception exception)
                    {
                        System.Windows.MessageBox.Show(exception.Message);
                    }
                //if (findNannies == null)
                //    throw new Exception("ma nishma");
                Dispatcher.Invoke(new Action(() => { nannyDataGrid.ItemsSource = findNannies;
                    search_nannys_button.IsEnabled = true;
                    mother_child_stackpanel.Visibility = Visibility.Visible;
                    Constraints_grid.Visibility = Visibility.Visible;
                    nannyDataGrid.Visibility = Visibility.Visible;
                    select_nanny_button.Visibility = Visibility.Visible;
                    loading.Visibility = Visibility.Collapsed;
                }));
                    if (findNannies.Count == 0)
                        MessageBox.Show("No nannys was found by the data", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }).Start();
            }
            catch (Exception exception)
            {
                System.Windows.MessageBox.Show(exception.Message);
            }




        }

        List<Nanny> allReq(Mother mother, int floor, int max, Child child)
        {

            List<Nanny> nanny2 = new List<Nanny>();
            List<Nanny> nanny = new List<Nanny>();
            List<Nanny> nanny1 = new List<Nanny>();
            
            nanny = bl.rangeNanny(mother.id).ToList();
            nanny1 = bl.requiredMother(mother).ToList();
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
                    && item.maxChilds <= max

                    );
                }
            }
            return nanny2;

            //&& ((child.birthDay < DateTime.Now.AddMonths(-item.age_child_min) && child.birthDay > DateTime.Now.AddMonths(-item.age_child_max)))

        }



        private void select_mothr_and_child_button_Click(object sender, RoutedEventArgs e)
        {
            Constraints_grid.Visibility = Visibility.Visible;
        }

        private void add_contract_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void payment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void vizibilityes()
        {
            mother_child_stackpanel.Visibility = Visibility.Collapsed;
            Constraints_grid.Visibility = Visibility.Collapsed;
            nannyDataGrid.Visibility = Visibility.Collapsed;
            add_contruct_grid.Visibility = Visibility.Collapsed;
            select_nanny_button.Visibility = Visibility.Collapsed;
            loading.Visibility = Visibility.Collapsed;
        }
    }
}
