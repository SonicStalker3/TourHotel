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
using Hotel;

namespace HotelApp
{
    /// <summary>
    /// Логика взаимодействия для EditViewChoice.xaml
    /// </summary>
    public partial class EditViewChoicePage : Page
    {
        public Пользователи user;

        public EditViewChoicePage(Пользователи user)
        {
            InitializeComponent();
            switch (user.RoleID)
            {
                case 0:
                    EditHotelBtn.IsEnabled = false;
                    EditTourBtn.IsEnabled = false;
                    ViewTourBtn.IsEnabled = true;
                    break;
                case 1:
                    EditHotelBtn.IsEnabled = true;
                    EditTourBtn.IsEnabled = true;
                    ViewTourBtn.IsEnabled = true;
                    break;
                case 2:
                    EditHotelBtn.IsEnabled = true;
                    EditTourBtn.IsEnabled = false;
                    ViewTourBtn.IsEnabled = true;
                    break;
                default:
                    EditHotelBtn.IsEnabled = true;
                    EditTourBtn.IsEnabled = false;
                    ViewTourBtn.IsEnabled = true;
                    break;
            }
        }

        private void EditHotelBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HotelPage());
        }

        private void EditTourBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TourPage());
        }

        private void ViewTourBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ToursViewPage());
        }

    }
}
