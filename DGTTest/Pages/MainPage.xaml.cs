using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using DGTTest.Models;

namespace DGTTest
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private void ListBox_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListBox.SelectedItem != null)
            {
                NavigationService?.Navigate(
                    new InfoPage() { DataContext = new InfoPageVM(ListBox.SelectedItem as Currency) });
            }
        }
    }
}