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

namespace UI
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        Class1 b;
        public Welcome()
        {
            InitializeComponent();
     
        }
        private void ButtonEmployee_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }

        private void ButtonCandidate_Click(object sender, RoutedEventArgs e)
        {
            FindCandidate findCandidate = new FindCandidate();
            findCandidate.ShowDialog();
        }
    }
}
