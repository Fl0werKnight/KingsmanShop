using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KingsmanShop.Windows
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            cbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            cbGender.DisplayMemberPath = "Title";
            cbGender.SelectedIndex = 1;
        }

        private void tbReg_GotFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text.Length != 0)
            {
                ((TextBox)sender).Text = "";
            }
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            // валидация
            if (string.IsNullOrEmpty(tbLastName.Text) || string.IsNullOrEmpty(tbFirstName.Text) || string.IsNullOrEmpty(tbPatronymic.Text) ||
                string.IsNullOrEmpty(tbEmail.Text) || string.IsNullOrEmpty(tbPhone.Text) || string.IsNullOrEmpty(tbLogin.Text) ||
                string.IsNullOrEmpty(tbPassword.Text) || string.IsNullOrEmpty(tbPasswordRe.Text))
            {
                MessageBox.Show("Нельзя оставлять поля пустыми!");
                return;
            }

            if (tbPassword.Text != tbPasswordRe.Text)
            {
                MessageBox.Show("Пароли должны совпадать!");
                return;
            }

            // добавление 
            Databases.Client addClient = new Databases.Client();
            addClient.LastName = tbLastName.Text;
            addClient.FirstName = tbFirstName.Text;
            addClient.Patronymic = tbPatronymic.Text;
            addClient.IdGender = (cbGender.SelectedItem as Databases.Gender).Code;
            addClient.Email = tbEmail.Text;
            addClient.Phone = tbPhone.Text;
            addClient.Login = tbLogin.Text;
            addClient.Password = tbPassword.Text;

            // Добавление в базу нового пользователя
            ClassHelper.EF.Context.Client.Add(addClient);
            // Сохранение в базе нового пользователя
            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Вы успешно зарегистрировались");

            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }
    }
}
