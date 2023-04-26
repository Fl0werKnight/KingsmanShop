using KingsmanShop.Windows.Client;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KingsmanShop.Windows.Employee
{
    /// <summary>
    /// Interaction logic for ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        public ServiceWindow()
        {
            InitializeComponent();
            GetListService();
        }

        // получиние списка услуг
        private void GetListService()
        {
            lvServices.ItemsSource = ClassHelper.EF.Context.Service.ToList();
        }

        // Добавление услуги
        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {
            AddServiceWindow addServiceWindow = new AddServiceWindow();
            addServiceWindow.ShowDialog();

            // Обновляем лист
            GetListService();
        }

        // Редактирование услуги
        private void btnEditService_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as Databases.Service; // получаем выбранную запись

            EditServiceWindow editServiceWindow = new EditServiceWindow(service);
            editServiceWindow.ShowDialog();

            GetListService();
        }

        // Добавление услуги в корзину 
        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as Databases.Service; // получаем выбранную запись
            service.Count++;

            ClassHelper.CartService.ServiceCart.Add(service);

            MessageBox.Show($"{service.Title} добавлена в корзину!");
        }

        // Переход в корзину
        private void btnGoToCart_Click(object sender, RoutedEventArgs e)
        {
            ServiceCartWindow serviceCartWindow = new ServiceCartWindow();
            serviceCartWindow.Show();
        }
    }
}
