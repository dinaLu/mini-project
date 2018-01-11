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
    /// Interaction logic for AddMotherWindow.xaml
    /// </summary>
    public partial class AddMotherWindow : Window
    {
        Mother mother;
        IBL bl;

        public AddMotherWindow()
        {
            InitializeComponent();
            mother = new Mother();
            bl = FactoryBL.getInstance();
            this.MotherDetailsGrid.DataContext = mother;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource motherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("motherViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // motherViewSource.Source = [generic data source]
        }

        private void addMotherButton_click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addMother(mother);
                mother = new Mother();
                this.MotherDetailsGrid.DataContext = mother;
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }
        }

    }
}
