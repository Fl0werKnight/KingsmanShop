using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KingsmanShop.Windows
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        // При фокусе на текстбокс обнулять его
        private void tbAuth_GotFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text.Length != 0)
            {
                ((TextBox)sender).Text = "";
            }
        }

        // Кнопка входа
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var employeeAuth = ClassHelper.EF.Context.Employee.ToList().Where(i => i.Email == tbLogin.Text || i.Login == tbLogin.Text || i.Phone == tbLogin.Text && i.Password == tbPassword.Text).FirstOrDefault();
            var clientAuth = ClassHelper.EF.Context.Client.ToList().Where(i => i.Email == tbLogin.Text || i.Login == tbLogin.Text || i.Phone == tbLogin.Text && i.Password == tbPassword.Text).FirstOrDefault();
            MainWindow mainWindow = new MainWindow();

            if (employeeAuth != null)
            {
                mainWindow.Show();
                ClassHelper.UserData.Employee = employeeAuth;
                this.Close();
            }
            else if (clientAuth != null)
            {
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Попробуйте ещё раз!");
            }
        }

        private void tbkRegistration_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }
    }
}
