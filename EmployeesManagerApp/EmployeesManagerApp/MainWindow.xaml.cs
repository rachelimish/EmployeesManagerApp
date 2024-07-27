using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
using DAL.Models;


namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=InterviewsManager;Integrated Security=True;";
        Class1 b = new Class1(connectionString);
        private bool isUpdating = false;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Employee> Employees1 { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            // קריאה לפעולה שמחזירה את נתוני העובדים
            var res = b.GetAllEmployees();
            Employees1 = new ObservableCollection<Employee>(res);
            DataContext = this;
            // הצגת הנתונים ב-DATAGRID
            Employees.ItemsSource = res;
            ComboBoxFilterCategory.ItemsSource = b.GetRole();
            OnPropertyChanged(nameof(Employees1));

        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool Refras(Employee employee)
        {
            Employees1 = new ObservableCollection<Employee>(b.GetAllEmployees());
            OnPropertyChanged(nameof(Employees1));
            return true;
        }

        private void ComboBoxFilterCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // קריאה לפונקציה ב-DAL והצגת התוצאה ב-DATAGRID
            string selectedCategory = ComboBoxFilterCategory.SelectedValue.ToString();
            Employees.ItemsSource = b.GetCategoryRole(selectedCategory);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployeeWin = new AddEmployee();
            addEmployeeWin.ShowDialog();
        }

    }
}
