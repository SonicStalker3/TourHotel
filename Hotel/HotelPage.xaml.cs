using Hotel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelApp
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class HotelPage : Page
    {
        public HotelPage()
        {
            InitializeComponent();
            HotelEntities.GetContext().Отель.ToList();//.Include(o => o.Страны).ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedHotel = DGridHotel.SelectedItem as Отель;
            NavigationService.Navigate(new AddEditPage(null));
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedHotel = (sender as Button).DataContext as Отель;
            NavigationService.Navigate(new AddEditPage(selectedHotel));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedHotel = DGridHotel.SelectedItem as Отель;
            HotelEntities.GetContext().Отель.Remove(selectedHotel);
            HotelEntities.GetContext().SaveChanges();
        }
    }
}
