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
    /// Interaction logic for AddNannyWindow.xaml
    /// </summary>
    public partial class AddNannyWindow : Window
    {
        Nanny nanny;
        IBL bl;
        public AddNannyWindow()
        {
            InitializeComponent();
            nanny = new Nanny();
            bl = FactoryBL.getInstance();
            this.NannyDetailsGrid.DataContext = nanny;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource nannyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("nannyViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // nannyViewSource.Source = [generic data source]
        }

        private void addNannyButton_click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addNanny(nanny);
                nanny = new Nanny();
                this.NannyDetailsGrid.DataContext = nanny;
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }
        }

    }
}
