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
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //IBL bl;
        public MainWindow()
        {
            InitializeComponent();
            //bl = FactoryBL.getInstance();

        }
        //add
        private void addMotherButton_click(object sender, RoutedEventArgs e)
        {
            Window addMotherWindow = new AddMotherWindow();
            addMotherWindow.Show();
        }
        private void addChildButton_click(object sender, RoutedEventArgs e)
        {
            Window addChildWindow = new AddMotherWindow();
            addChildWindow.Show();
        }
        private void addNannyButton_click(object sender, RoutedEventArgs e)
        {
            Window addNannyWindow = new AddMotherWindow();
            addNannyWindow.Show();
        }
        private void addContractButton_click(object sender, RoutedEventArgs e)
        {
            Window addContractWindow = new AddMotherWindow();
            addContractWindow.Show();
        }
        //update
        private void updateMotherButton_click(object sender, RoutedEventArgs e)
        {
            Window updateMotherWindow = new UpdateMotherWindow();
            updateMotherWindow.Show();
        }
        private void updateChildButton_click(object sender, RoutedEventArgs e)
        {
            Window updateChildWindow = new UpdateMotherWindow();
            updateChildWindow.Show();
        }
        private void updateNannyButton_click(object sender, RoutedEventArgs e)
        {
            Window updateNannyWindow = new UpdateMotherWindow();
            updateNannyWindow.Show();
        }
        private void updateContractButton_click(object sender, RoutedEventArgs e)
        {
            Window updateContractWindow = new UpdateMotherWindow();
            updateContractWindow.Show();
        }

        //remove
        private void removeMotherButton_click(object sender, RoutedEventArgs e)
        {
            Window removeMotherWindow = new RemoveMotherWindow();
            removeMotherWindow.Show();
        }
        private void removeChildButton_click(object sender, RoutedEventArgs e)
        {
            Window removeChildWindow = new RemoveMotherWindow();
            removeChildWindow.Show();
        }
        private void removeNannyButton_click(object sender, RoutedEventArgs e)
        {
            Window removeNannyWindow = new RemoveMotherWindow();
            removeNannyWindow.Show();
        }
        private void removeContractButton_click(object sender, RoutedEventArgs e)
        {
            Window removeContractWindow = new RemoveMotherWindow();
            removeContractWindow.Show();
        }


    }
}
