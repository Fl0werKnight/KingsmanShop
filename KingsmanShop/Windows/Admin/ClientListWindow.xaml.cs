using System.Linq;
using System.Windows;

namespace KingsmanShop.Windows.Admin
{
    /// <summary>
    /// Interaction logic for ClientListWindow.xaml
    /// </summary>
    public partial class ClientListWindow : Window
    {
        public ClientListWindow()
        {
            InitializeComponent();

            dgClient.ItemsSource = ClassHelper.EF.Context.Client.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
