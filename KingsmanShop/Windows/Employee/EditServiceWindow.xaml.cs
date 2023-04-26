using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace KingsmanShop.Windows.Employee
{
    /// <summary>
    /// Interaction logic for EditServiceWindow.xaml
    /// </summary>
    public partial class EditServiceWindow : Window
    {
        Databases.Service editService = null;
        private bool isEdit = false;

        public EditServiceWindow()
        {
            InitializeComponent();
            isEdit = false;
        }

        public EditServiceWindow(Databases.Service service)
        {
            InitializeComponent();

            isEdit = true;
            editService = service;

            // Заполнение типа услуги

            CmbTypeService.ItemsSource = ClassHelper.EF.Context.CategoryService.ToList();
            CmbTypeService.DisplayMemberPath = "Title";

            // выгрузка изображения 
            ImgImageService.Source = new BitmapImage(new Uri(service.ImagePath));

            // заполнение полей
            TbNameService.Text = service.Title;
            TbDiscService.Text = service.Description;
            TbPriceService.Text = Convert.ToString(service.Cost);

            // заполнение типа услуги
            CmbTypeService.SelectedItem = ClassHelper.EF.Context.CategoryService.Where(i => i.Id == service.IdCategory).FirstOrDefault();
        }

        private void btnEditService_Click(object sender, RoutedEventArgs e)
        {
            // валидация
            editService.Title = TbNameService.Text;
            editService.Description = TbDiscService.Text;
            editService.Cost = Convert.ToDecimal(TbPriceService.Text);
            editService.IdCategory = ((Databases.CategoryService)CmbTypeService.SelectedItem).Id;

            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Данные успешно сохранны");

            this.Close();
        }
    }
}
