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
using System.Text.RegularExpressions;
using DAL.Models;
using BL;


namespace UI
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public delegate bool AddEmployeeDelegate(Employee employee);
    public partial class AddEmployee : Window
    {

        public event AddEmployeeDelegate EventAddEmployee;
        



        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=InterviewsManager;Integrated Security=True;";
        Class1 b = new Class1(connectionString);





        public AddEmployee()
        {
            InitializeComponent();
            JobTitleTextBox.ItemsSource = b.GetRole();

        }
        public bool EmployeeAdd(Employee employee)
        {
            return EventAddEmployee?.Invoke(employee) ?? false;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs())
            {
                // Add employee to the database
                var employee = new Employee
                {
                    Id = int.Parse(IdTextBox.Text),
                    FirstName = FirstNameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    Age = int.Parse(AgeTextBox.Text),
                    StartOfWorkYear = int.Parse(StartOfWorkingYearTextBox.Text),
                    City = CityAddressTextBox.Text,
                    Street = StreetAddressTextBox.Text,
                    RoleInCompany = JobTitleTextBox.Text,
                    PhoneNumber = PhoneNumberTextBox.Text,
                    Email = MailAddressTextBox.Text

                };

                try
                {
                    b.Add(employee);
                    if(EmployeeAdd(employee))
                           MessageBox.Show("The employee added successfully!");
                    else
                        MessageBox.Show("Failed to add employee");
                }
                catch (ArgumentException ex) 
                { 
                    MessageBox.Show(ex.ToString());

                }
                IdTextBox.Text = "";
                FirstNameTextBox.Text = "";
                LastNameTextBox.Text = "";
                AgeTextBox.Text = "";
                StartOfWorkingYearTextBox.Text = "";
                CityAddressTextBox.Text = "";
                StreetAddressTextBox.Text = "";
                JobTitleTextBox.Text = "";
                PhoneNumberTextBox.Text = "";
                MailAddressTextBox.Text = "";

            }

        }
        private bool ValidateInputs()
        {
            if (!Regex.IsMatch(IdTextBox.Text, @"^\d{9}$"))
            {
                MessageBox.Show("Validation failed for field – Id");
                return false;
            }
            if (!Regex.IsMatch(FirstNameTextBox.Text, @"^[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Validation failed for field – First Name");
                return false;
            }
            if (!Regex.IsMatch(LastNameTextBox.Text, @"^[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Validation failed for field – Last Name");
                return false;
            }
            if (!int.TryParse(AgeTextBox.Text, out int age) || age < 18 || age > 67)
            {
                MessageBox.Show("Validation failed for field - Age");
                return false;
            }
            if (!int.TryParse(StartOfWorkingYearTextBox.Text, out int startYear) || startYear < 1900 || startYear > DateTime.Now.Year)
            {
                MessageBox.Show("Validation failed for field - Start Year");
                return false;
            }
            if (!Regex.IsMatch(CityAddressTextBox.Text, @"^[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Validation failed for field - City");
                return false;
            }
            if (!Regex.IsMatch(StreetAddressTextBox.Text, @"^[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Validation failed for field - Street");
                return false;
            }
             if (JobTitleTextBox.SelectedItem == null)
            {
                MessageBox.Show("Validation failed for field - Role");
                return false;
            }

            if (!Regex.IsMatch(PhoneNumberTextBox.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Validation failed for field - Phone");
                return false;
            }
            if (!Regex.IsMatch(MailAddressTextBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Validation failed for field - Email");
                return false;
            }

            return true;
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
