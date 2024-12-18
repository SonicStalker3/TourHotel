using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Hotel;

namespace HotelApp
{
    public partial class AddEditTourPage : Page
    {
        private Туры _tour;

        public AddEditTourPage(Туры tour = null)
        {
            InitializeComponent();

            if (tour != null ) {
                _tour = tour;
            }
        }

        private void LoadTourData()
        {
            TitleField.Text = _tour.Название;
            DescriptionField.Text = _tour.Описание;
            PriceField.Text = _tour.Цена.ToString();
            StartDateField.SelectedDate = _tour.ДатаНачала;
            EndDateField.SelectedDate = _tour.ДатаОкончания;
            IsActiveField.IsChecked = _tour.Актуален;

            // Загрузка данных для ComboBox (отели, страны, типы туров)
            HotelList.ItemsSource = HotelEntities.GetContext().Отель.ToList();
            CountryList.ItemsSource = HotelEntities.GetContext().Страны.ToList();
            //TourTypeList.Items = HotelEntities.GetContext().ТипыТуров.ToList();

            // Установка выбранных значений для ComboBox
            if (_tour.HotelID.HasValue)
                HotelList.SelectedValue = _tour.HotelID.Value;

            if (_tour.CountryID.HasValue)
                CountryList.SelectedValue = _tour.CountryID.Value;

            /*if (_tour.TourTypesID.HasValue)
                TourTypeList.SelectedValue = _tour.TourTypesID.Value;*/
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика для возврата на предыдущую страницу
            NavigationService.GoBack();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            // Сохранение данных из полей в объект тура
            _tour.Название = TitleField.Text;
            _tour.Описание = DescriptionField.Text;
            _tour.Цена = decimal.TryParse(PriceField.Text, out var price) ? price : 0;
            _tour.ДатаНачала = StartDateField.SelectedDate;
            _tour.ДатаОкончания = EndDateField.SelectedDate;
            _tour.Актуален = IsActiveField.IsChecked;

            // Установка выбранных значений для ComboBox
            _tour.HotelID = (int?)HotelList.SelectedValue;
            _tour.CountryID = (int?)CountryList.SelectedValue;
            /*_tour.TourTypesID = (int?)TourTypeList.SelectedValue;*/

            if (_tour.TourID == 0) // Если это новый тур
            {
                HotelEntities.GetContext().Туры.Add(_tour);
                MessageBox.Show("Тур успешно добавлен!");
            }
            else // Если это редактирование существующего тура
            {
                HotelEntities.GetContext().Туры.AddOrUpdate(_tour);
                MessageBox.Show("Тур успешно отредактирован!");
            }

            // Сохранение изменений в базе данных
            HotelEntities.GetContext().SaveChanges();

            // Возврат на предыдущую страницу
            NavigationService.GoBack();
        }
    }
}