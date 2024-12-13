using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
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
    /// Логика взаимодействия для ToursViewPage.xaml
    /// </summary>
    public partial class ToursViewPage : Page
    {
        public ObservableCollection<Туры> Туры { get; set; }

        public ToursViewPage()
        {
            InitializeComponent();

            var tours = HotelEntities.GetContext().Туры.OrderBy(x => x.Название).ToList();
            Туры = new ObservableCollection<Туры>(tours);

            DataContext = this;
        }

/*        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Image image)
            {
                BitmapImage errorImage = BitmapToBitmapImage(Properties.Resources.ErrorImage);
                image.Source = errorImage;
                //image.Source = new BitmapImage(new Uri("pack://application:.../HotelApp;Resources/ErrorImage.jpg"));
            }
        }*/ 

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Image image && 
                (image.Source == null ||
                string.IsNullOrWhiteSpace((image.Source as BitmapImage).UriSource?.ToString()
                )))
            {
                BitmapImage errorImage = BitmapToBitmapImage(Properties.Resources.ErrorImage);
                image.Source = errorImage;
            }
        }

        public BitmapImage ByteArrayToBitmapImage(byte[] byteArray)
        {
            using (var stream = new MemoryStream(byteArray))
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad; // Загружает изображение в память
                bitmapImage.EndInit();
                bitmapImage.Freeze(); // Замораживает объект для использования в других потоках
                return bitmapImage;
            }
        }
        private BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                memoryStream.Position = 0;

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze(); // Замораживаем объект для использования в других потоках
                return bitmapImage;
            }
        }
    }
}
