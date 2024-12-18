﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для AddEditHotelsPage.xaml
    /// </summary>
    public partial class AddEditHotelsPage : Page
    {
        private Отель currentHotel;

        public AddEditHotelsPage()
        {
            InitializeComponent();
            var countries = HotelEntities.GetContext().Страны.OrderBy(x => Name).ToList();

            var noSelection = new Страны
            {
                CountryID = 0,
                ИмяСтраны = "Не выбрано" 
            };

            countries.Insert(0, noSelection);

            CountryList.ItemsSource = countries;

            CountryList.SelectedItem = noSelection;
        }

        public AddEditHotelsPage(Отель hotel) : this() 
        {
            if (hotel != null)
            {
                currentHotel = hotel;
            }
            this.DataContext = currentHotel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleField.Text))
            {
                MessageBox.Show("Название не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (StarsField.Value < 1 || StarsField.Value > 5)
            {
                MessageBox.Show("Рейтинг должен быть от 1 до 5.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (CountryList.SelectedItem == null || (CountryList.SelectedItem as Страны)?.CountryID == 0)
            {
                MessageBox.Show("Пожалуйста, выберите страну.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (currentHotel == null)
            {
                var selectedCountry = CountryList.SelectedItem as Страны;

                if (selectedCountry == null)
                {
                    MessageBox.Show("Пожалуйста, выберите страну.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var newHotel = new Отель()
                {
                    Название = TitleField.Text,
                    Рейтинг = StarsField.Value,
                    Адрес = AddressField.Text.Trim(),
                    Страны = selectedCountry
                };

                HotelEntities.GetContext().Отель.Add(newHotel);

                try
                {
                    HotelEntities.GetContext().SaveChanges();
                    MessageBox.Show($"Hotel{newHotel.HotelID} {newHotel.Название}");
                    MessageBox.Show("Отель успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.GoBack();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            MessageBox.Show($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}", "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении отеля: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                try
                {
                    HotelEntities.GetContext().SaveChanges();
                    MessageBox.Show("Изменения сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении отеля: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            HotelEntities.GetContext();
            NavigationService.GoBack();
        }
    }

}
