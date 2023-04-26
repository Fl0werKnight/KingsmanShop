using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KingsmanShop.Windows.Client
{
    /// <summary>
    /// Interaction logic for ServiceCartWindow.xaml
    /// </summary>
    public partial class ServiceCartWindow : Window
    {
        public ServiceCartWindow()
        {
            InitializeComponent();
            GetListServise();
        }

        private void GetListServise()
        {
            ObservableCollection<Databases.Service> listCart = new ObservableCollection<Databases.Service>(ClassHelper.CartService.ServiceCart);
            lvCartService.ItemsSource = listCart.Distinct();
        }

        private void btnRomoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as Databases.Service; // получаем выбранную запись

            ClassHelper.CartService.ServiceCart.Remove(service);
            service.Count = 0;

            GetListServise();
        }

        private void btnSubstract_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as Databases.Service;

            if (service.Count > 1)
            {
                service.Count--;
                GetListServise();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as Databases.Service;

            if (service.Count < 10)
            {
                service.Count++;
                GetListServise();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            if (ClassHelper.CartService.ServiceCart.Count != 0)
            {
                Databases.Order newOrder = new Databases.Order();

                if (ClassHelper.UserData.Employee != null)
                {
                    newOrder.IdClient = 1; // По умолчанию
                    newOrder.IdEmployee = ClassHelper.UserData.Employee.Id;
                }
                else
                {
                    newOrder.IdClient = 1; // По умолчанию
                    newOrder.IdEmployee = 1; // По умолчанию
                }
                newOrder.DateOrder = DateTime.Now;

                ClassHelper.EF.Context.Order.Add(newOrder);
                ClassHelper.EF.Context.SaveChanges();

                foreach (Databases.Service item in ClassHelper.CartService.ServiceCart.Distinct())
                {
                    Databases.ServiceOrder newOrderService = new Databases.ServiceOrder();
                    newOrderService.IdOrder = newOrder.Id;
                    newOrderService.IdService = item.Id;
                    newOrderService.Quantity = item.Count;

                    ClassHelper.EF.Context.ServiceOrder.Add(newOrderService);
                    ClassHelper.EF.Context.SaveChanges();
                }

                MessageBox.Show("Заказ успешно оформлен!");
            }
            else
            {
                MessageBox.Show("Корзина пуста");
            }

            this.Close();

        }
    }
}
