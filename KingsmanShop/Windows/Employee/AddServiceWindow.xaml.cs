using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace KingsmanShop.Windows.Employee
{
    /// <summary>
    /// Interaction logic for AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    {
        private string pathImage = null;

        public AddServiceWindow()
        {
            InitializeComponent();

            cmbTypeService.ItemsSource = ClassHelper.EF.Context.CategoryService.ToList();
            cmbTypeService.DisplayMemberPath = "Title";
            cmbTypeService.SelectedIndex = 0;
        }

        private void btnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgImageService.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                pathImage = openFileDialog.FileName;
            }
        }

        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {
            //валидация
            if (string.IsNullOrEmpty(tbTitleService.Text) || string.IsNullOrEmpty(tbMoreOfService.Text) || string.IsNullOrEmpty(tbCostService.Text))
            {
                MessageBox.Show("Поля должны быть заполнены!");
                return;
            }

            if (pathImage == null)
            {
                MessageBox.Show("Вы забыли выбрать изображение!");
                return;
            }

            // добавление услуги
            Databases.Service newService = new Databases.Service();

            newService.Title = tbTitleService.Text;
            newService.Cost = Convert.ToDecimal(tbCostService.Text);
            newService.Description = tbMoreOfService.Text;
            newService.IdCategory = (cmbTypeService.SelectedItem as Databases.CategoryService).Id;
            newService.ImagePath = pathImage;
            try
            {
                Convert.ToDecimal(tbCostService.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Введите десятичное число!");
                return;
            }

            ClassHelper.EF.Context.Service.Add(newService);
            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Услуга добавлена");

            this.Close();
        }

    }
}
