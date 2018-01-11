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
    /// Interaction logic for AddChildWindow.xaml
    /// </summary>
    public partial class AddChildWindow : Window
    {
        Child child;
        IBL bl;

        public AddChildWindow()
        {
            InitializeComponent();
            child = new Child();
            this.ChildDetailsGrid.DataContext = child;
            bl = FactoryBL.getInstance();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource childViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("childViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // childViewSource.Source = [generic data source]
        }
        private void addChildButton_click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addChild(child);
                child = new Child();
                this.ChildDetailsGrid.DataContext = child;
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }
        }
    }
}
