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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Отель currentHotel = new Отель();
        private int star;

        public int Star
        {
            get => star;
            set
            {
                star = Math.Min(Math.Max(value, 0), 5);
            }
        }
        public AddEditPage()
        {
            InitializeComponent();
        }

        public AddEditPage(Отель hotel) : base() 
        {
            if (hotel != null)
            {
                currentHotel = hotel;
                MessageBox.Show(hotel.Название);
            }
        }
    }
}
