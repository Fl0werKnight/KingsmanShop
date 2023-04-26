using KingsmanShop.Windows.Admin;
using KingsmanShop.Windows.Employee;
using System.Windows;

namespace KingsmanShop.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnService_Click(object sender, RoutedEventArgs e)
        {
            ServiceWindow serviceWindow = new ServiceWindow();
            serviceWindow.Show();
            this.Close();
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            ClientListWindow clientWindow = new ClientListWindow();
            clientWindow.Show();
            this.Close();
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeListWindow employeeWindow = new EmployeeListWindow();
            employeeWindow.Show();
            this.Close();
        }
    }
}
